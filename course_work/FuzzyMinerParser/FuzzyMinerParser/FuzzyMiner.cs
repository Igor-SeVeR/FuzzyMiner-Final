using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace FuzzyMinerParser
{
    public partial class FuzzyMiner : Form
    {
        const string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        const string imageName = "image.gif";

        string filename_to_cpp;

        bool drawFlagEdges = false;
        bool drawFlagNodes = false;
        bool drawFlagRatio = false;

        string[] linesRead;

        public FuzzyMiner()
        {
            InitializeComponent();
            this.Refresh();
            this.Update();
            FuzzyMiner_Resize(this, new EventArgs());
        }
        
        [DllImport("FuzzyMinerLib.dll", EntryPoint = "Foo", CallingConvention = CallingConvention.StdCall)]
        unsafe static extern void Execute(char* file, int length, double* metrics);

        

        unsafe private void Calculate(object sender, EventArgs e)
        {
            
            if (!buttonCalculate.Enabled)
                return;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            this.Cursor = Cursors.WaitCursor;

            double[] metric = new double[8];
            metric[0] = (double)binFrequencyVal.Value;
            metric[1] = (double)unFrequencyVal.Value;
            metric[2] = (double)routingSigVal.Value;
            metric[3] = (double)distanceSigVal.Value;
            metric[4] = (double)nameSigVal.Value;
            metric[5] = (double)autoParam1.Value / 1000;
            metric[6] = (double)autoParam2.Value / 1000;
            metric[7] = 1 - ((double)autoParam3.Value / 1000);

            int sz = filename_to_cpp.Length;
            try
            {
                fixed (char* file_to_cpp = filename_to_cpp)
                {
                    fixed (double* metrics = metric)
                    {
                        Execute(file_to_cpp, sz, metrics);
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error, while building the model!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"" + Application.StartupPath + "\\GraphViz\\release\\bin\\dot.exe";
                p.StartInfo.Arguments = "-Tgif" + " -o" + Application.StartupPath + "\\" + imageName + ' ' + Application.StartupPath + "\\" + "test.dot";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                while (!p.HasExited) { }
            } catch (Exception ex)
            {
                MessageBox.Show("GraphViz not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = null;
                return;
            }
            SaveFileButton.Enabled = true;
            OpenImage();
            this.Cursor = null;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open execution log...";
            dlg.Filter = "log files(*.log)|*.log";
            dlg.CheckPathExists = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                if (!ParseFile(fileName))
                {
                    MessageBox.Show("The format of file is not correct!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Execution log succesfully opened!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                filename_to_cpp = fileName;
                buttonCalculate.Enabled = true;
                SaveFileButton.Enabled = false;
                autoParam1.Enabled = true;
                autoParam2.Enabled = true;
                autoParam3.Enabled = true;
                binFrequencyVal.Enabled = true;
                unFrequencyVal.Enabled = true;
                distanceSigVal.Enabled = true;
                routingSigVal.Enabled = true;
                nameSigVal.Enabled = true;
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save the visualization of model as...";
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true; 
            dlg.Filter = "Image file(*.gif)|*.gif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bmpSave = (Bitmap)pictureBox1.Image;
                    bmpSave.Save(dlg.FileName, ImageFormat.Gif);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible to save the visualization of model!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("The visualization saved succesfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ParseFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!ParseLine(line))
                    return false;
            }
            linesRead = (string[])lines.Clone();
            return true;
        }

        private bool ParseLine(string line)
        {
            string[] words = line.Split(';');
            if (words.Last().Length != 0)
                return false;
            for (int i = 0; i < words.Length - 1; ++i)
            {
                string word = words[i];
                if ((word.Length == 0) || !ParseWord(word))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ParseWord(string word)
        {
            foreach (char c in word)
            {
                if (!allowedCharacters.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void OpenImage()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(imageName);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Image with visualization of the model not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonCalculate.Enabled = false;
                SaveFileButton.Enabled = false;
                return;
            }
            MessageBox.Show("The visualization of the model build seccesfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void autoParam1_MouseDown(object sender, MouseEventArgs e)
        {
            drawFlagEdges = true;
        }

        private void autoParam1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!drawFlagEdges)
                return;

            drawFlagEdges = false;
            if (pictureBox1.Image != null)
                Calculate(sender, e);
        }

        private void autoParam1_Scroll(object sender, EventArgs e)
        {
            EdgeCutoffValueLabel.Text = ((double)autoParam1.Value / 1000).ToString();
            if (drawFlagEdges)
                return;
            if (pictureBox1.Image != null)
                Calculate(sender, e);
        }

        private void autoParam2_Scroll(object sender, EventArgs e)
        {
            NodeCutoffValueLabel.Text = ((double)autoParam2.Value / 1000).ToString();
            if (drawFlagNodes)
                return;
            if (pictureBox1.Image != null)
                Calculate(sender, e);
        }

        private void autoParam2_MouseDown(object sender, MouseEventArgs e)
        {
            drawFlagNodes = true;
        }

        private void autoParam2_MouseUp(object sender, MouseEventArgs e)
        {
            if (!drawFlagNodes)
                return;

            drawFlagNodes = false;
            if (pictureBox1.Image != null)
                Calculate(sender, e);
        }

        private void FuzzyMiner_Resize(object sender, EventArgs e)
        {
            label9.Location = new Point(label9.Location.X, panel1.Location.Y + panel1.Height + 10);
            label10.Location = new Point(label10.Location.X, label9.Location.Y + label9.Height + 15);
            label6.Location = new Point(label10.Location.X, label10.Location.Y + label10.Height + 15);

            EdgeCutoffValueLabel.Location = new Point(EdgeCutoffValueLabel.Location.X, panel1.Location.Y + panel1.Height + 10);
            NodeCutoffValueLabel.Location = new Point(NodeCutoffValueLabel.Location.X, EdgeCutoffValueLabel.Location.Y + EdgeCutoffValueLabel.Height + 15);
            RatioValueLabel.Location = new Point(RatioValueLabel.Location.X, NodeCutoffValueLabel.Location.Y + NodeCutoffValueLabel.Height + 15);

            autoParam1.Location = new Point(autoParam1.Location.X, panel1.Location.Y + panel1.Height + 2);
            autoParam2.Location = new Point(autoParam2.Location.X, autoParam1.Location.Y + autoParam1.Height + 2);
            autoParam3.Location = new Point(autoParam3.Location.X, autoParam2.Location.Y + autoParam2.Height + 2);
        }

        private void AutoParam3_MouseUp(object sender, MouseEventArgs e)
        {
            if (!drawFlagRatio)
                return;

            drawFlagRatio = false;
            if (pictureBox1.Image != null)
                Calculate(sender, e);
        }

        private void AutoParam3_MouseDown(object sender, MouseEventArgs e)
        {
            drawFlagRatio = true;
        }

        private void AutoParam3_Scroll(object sender, EventArgs e)
        {
            RatioValueLabel.Text = (1 - ((double)autoParam3.Value / 1000)).ToString();
            if (drawFlagRatio)
                return;
            if (pictureBox1.Image != null)
                Calculate(sender, e);
        }

        private void FuzzyMiner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            try
            {
                File.Delete(imageName);
            } catch (Exception ex)
            {

            }
            try
            {
                File.Delete("test.dot");
            } catch (Exception ex)
            {

            }
        }
    }
}
