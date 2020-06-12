#include "stdafx.h"
#include <vector>
#include <string>
#include "graph.h"
#include "dotfile.h"
#include <fstream>

void build(char* input_log, int n, double* metrics)
{
	//--------------------------------------------------------Here starts checking of correct graph building----------------------------------------------------------------------

	double binFrequency = metrics[0];
	double unFrequency = metrics[1];
	double routingSig = metrics[2];
	double distanceSig = metrics[3];
	double nameSig = metrics[4];
	double edgeCutoff = metrics[5];
	double nodeCutoff = metrics[6];
	double ratioCutoff = metrics[7];

	std::string filename = "";

	n = n * 2;

	for (int i = 0; i < n; i++) {
		if (i % 2 == 0) {
			filename += input_log[i];
		}
	}

	std::ifstream fin(filename);

	std::vector<std::string> log;
	std::string line;
	while (fin >> line) {
		log.push_back(line);
	}

	fin.close();

	graph fuzzygraph(log);

	//--------------------------------------------------------Here it ends--------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------Here starts the count of metrics-------------------------------------------------------------------------------
	fuzzygraph.push_user_values(binFrequency, unFrequency, routingSig, distanceSig, nameSig);
	fuzzygraph.count_all_metrics();

	//--------------------------------------------------------Here it ends--------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------Here starts the first step of grapth simplification-------------------------------------------------------------------------------
	fuzzygraph.solve_conflicts(ratioCutoff);
	//--------------------------------------------------------Here it ends--------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------Here starts the second step of grapth simplification-------------------------------------------------------------------------------
	fuzzygraph.cut_edges(edgeCutoff);
	//--------------------------------------------------------Here it ends--------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------Here starts the third step of grapth simplification-------------------------------------------------------------------------------
	fuzzygraph.cut_nodes(nodeCutoff);
	//--------------------------------------------------------Here it ends--------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------Here starts the convert grapth to dot-------------------------------------------------------------------------------
	dotfile ans;
	ans.create_dot("test.dot", fuzzygraph);
	//--------------------------------------------------------Here it ends--------------------------------------------------------------------------------------------------------

	return;
}
	

extern "C"
{
	__declspec(dllexport) void __stdcall Foo(char* s, int length, double* metrics)
	{

		build(s, length, metrics);
	}
}