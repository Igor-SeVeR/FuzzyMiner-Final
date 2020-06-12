#include "stdafx.h"
#include "dotfile.h"
#include <iomanip>

void dotfile::create_dot(std::string name, graph model) {
	dotfile::fout.open(name);
	fout << "digraph model {" << '\n';
	fout << "ratio = fill;" << '\n' << "node [style = filled];" << '\n';
	for (int i = 0; i < model.get_size(); i++) {
		if (model.get_node(i).get_visible()) {
			dotfile::fout << model.get_node(i).get_name()
				<< " [label = \"" << std::fixed << std::setprecision(3) << model.get_node(i).get_name()
				<< ':' << model.get_node(i).get_unary_significanse()
				<< "\", color=\"0.650 0.200 1.000\"]" << '\n';
			for (int j = 0; j < model.get_node(i).get_number_of_relations(); j++) {
				if (model.get_node(model.get_node(i).get_relation(j)).get_visible() && model.get_node(i).get_relation_visible(j) && model.get_node(i).get_name() != model.get_node(model.get_node(i).get_relation(j)).get_name()) {
					dotfile::fout << model.get_node(i).get_name() << " -> " <<
						model.get_node(model.get_node(i).get_relation(j)).get_name() << '\n';
				}
			}
		}
	}
	fout << "}";
	fout.close();
}