#include "stdafx.h"
#include "graph.h"
#include "node.h"
#include <vector>
#include <map>
#include <algorithm>



std::vector<std::string> graph::parse_line(std::string trace) {
	std::vector<std::string> all;
	int pointer = 0;
	while (pointer < (int)trace.size()) {
		std::string current_name = "";
		while (trace[pointer] != ';') {
			current_name += trace[pointer];
			pointer++;
		}
		pointer++;
		all.push_back(current_name);
	}
	return all;
}

graph::graph(std::vector<std::string> log) {
	graph::size = 0;
	for (int i = 0; i < (int)log.size(); i++) {
		std::vector<std::string> trace = graph::parse_line(log[i]);
		if ((int)trace.size() == 1) {
			if (graph::all_names.count(trace[0]) == 0) {
				graph::all_names[trace[0]] = graph::size;
				graph::size++;
				graph::nodes.push_back(node(0, trace[0]));
			}
			graph::nodes[graph::all_names[trace[0]]].inc_frequency();
		}
		for (int j = 0; j < (int)trace.size() - 1; j++) {
			if (graph::all_names.count(trace[j]) == 0) {
				graph::all_names[trace[j]] = graph::size;
				graph::size++;
				graph::nodes.push_back(node(0, trace[j]));
			}
			if (graph::all_names.count(trace[j + 1]) == 0) {
				graph::all_names[trace[j + 1]] = graph::size;
				graph::size++;
				graph::nodes.push_back(node(0, trace[j + 1]));
			}
			int start = graph::all_names[trace[j]];
			int finish = graph::all_names[trace[j + 1]];
			nodes[start].inc_out_relations();
			nodes[finish].inc_in_relations();
			graph::nodes[start].push_relation(finish);
			graph::nodes[finish].push_relation_in(start);
			if (j == 0) {
				graph::nodes[start].inc_frequency();
				graph::nodes[finish].inc_frequency();
			} else 
				graph::nodes[finish].inc_frequency();
		}
	}
}

graph::graph() {
	graph::size = 0;
}

node graph::get_node(int i) {
	return graph::nodes[i];
}

int graph::get_size() {
	return (int)graph::nodes.size();
}

void graph::count_unary_frequency() {
	int maximum = 0;
	for (int i = 0; i < size; i++) {
		if (nodes[i].get_node_frequency() > maximum) {
			maximum = nodes[i].get_node_frequency();
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].count_unary_frequency(maximum);
	}
}

void graph::count_unary_routing()
{
	for (int i = 0; i < size; i++) {
		nodes[i].count_unary_routing(this, i);
	}
	double maximum = 0;
	for (int i = 0; i < size; i++) {
		if (nodes[i].get_unary_routing() > maximum)
			maximum = nodes[i].get_unary_routing();
	}
	for (int i = 0; i < size; i++) {
		nodes[i].normalize_unary_routing(maximum);
	}
}

void graph::cut_nodes(double cut_off)
{
	for (int i = 0; i < size; i++) {
		if (nodes[i].get_unary_significanse() < cut_off) {
			nodes[i].set_visible(false);
		}
		else {
			int it = 0;
			while (it < nodes[i].get_number_of_relations()) {
				if (nodes[nodes[i].get_relation(it)].get_unary_significanse() < cut_off && nodes[i].get_relation_visible(it)) {
					int to = nodes[i].get_relation(it);
					for (int j = 0; j < nodes[to].get_number_of_relations(); j++) {
						if (nodes[to].get_relation_visible(j))
							nodes[i].push_relation(nodes[to].get_relation(j));
					}
					//nodes[i].set_rel_visible(it, false);
				}
				it++;
			}
		}
	}
}

void graph::count_all_metrics()
{
	count_binary_frequency();
	count_unary_frequency();
	count_name_similarity();
	count_unary_routing();
	count_binary_distance();
	count_binary_significance();
	count_unary_significance();
}

void graph::count_name_similarity()
{
	for (int i = 0; i < size; i++) {
		nodes[i].count_name_similarity(this);
	}
}

void graph::count_binary_distance()
{
	count_aggregate();
	count_unary_aggregate();
	for (int i = 0; i < size; i++) {
		nodes[i].count_binary_distance(this, i);
	}
	double maximum = 0;
	for (int i = 0; i < size; i++) {
		double val = nodes[i].get_max_distance();
		if (val > maximum) {
			maximum = val;
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].normalize_distance(maximum);
	}
}

void graph::count_aggregate()
{
	for (int i = 0; i < size; i++) {
		nodes[i].count_aggregate();
	}
	double maximum = 0;
	for (int i = 0; i < size; i++) {
		double val = nodes[i].get_max_aggregate();
		if (val > maximum) {
			maximum = val;
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].normalize_aggregate(maximum);
	}
}

void graph::count_unary_aggregate()
{
	for (int i = 0; i < size; i++) {
		nodes[i].count_unary_aggregate();
	}
	double maximum = 0;
	for (int i = 0; i < size; i++) {
		if (nodes[i].get_unary_aggregate() > maximum) {
			maximum = nodes[i].get_unary_aggregate();
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].normalize_unary_aggregate(maximum);
	}
}

void graph::count_binary_significance()
{
	for (int i = 0; i < size; i++) {
		nodes[i].count_binary_significance();
	}
	double maximum = 0;
	for (int i = 0; i < size; i++) {
		double val = nodes[i].get_max_binary_significance();
		if (val > maximum) {
			maximum = val;
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].normalize_binary_significance(maximum);
	}
}

void graph::count_unary_significance()
{
	for (int i = 0; i < size; i++) {
		nodes[i].count_unary_significance();
	}
	double maximum = 0;
	for (int i = 0; i < size; i++) {
		if (nodes[i].get_unary_significanse() > maximum) {
			maximum = nodes[i].get_unary_significanse();
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].normalize_unary_significance(maximum);
	}
}

void graph::solve_conflicts(double cut_value)
{
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < nodes[i].get_number_of_relations(); j++) {
			int to = nodes[i].get_relation(j);
			for (int k = 0; k < nodes[i].get_number_of_in_relations(); k++) {
				if (to == nodes[i].get_in_relation(k)) {
					solve_conflict(i, to, cut_value);
				}
			}
		}
	}
}

double graph::count_rel(int node1, int node2, double sig)
{
	double sum_of_out_node1_significances = 0;
	double sum_of_in_node2_significances = 0;
	for (int i = 0; i < nodes[node1].get_number_of_relations(); i++) {
		sum_of_out_node1_significances += nodes[node1].get_binary_significance(i);
	}
	for (int i = 0; i < nodes[node2].get_number_of_in_relations(); i++) {
		int in_rel = nodes[node2].get_in_relation(i);
		for (int j = 0; j < nodes[in_rel].get_number_of_relations(); j++) {
			if (node2 == nodes[in_rel].get_relation(j)) {
				sum_of_in_node2_significances += nodes[in_rel].get_binary_significance(j);
			}
		}
	}
	return 0.5 * (sig / sum_of_out_node1_significances) + 0.5 * (sig / sum_of_in_node2_significances);
}

void graph::cut_edges(double cut_value)
{
	int cnt_at_all = 0;
	node_visited.resize(size);
	node_visited.assign(size, false);
	int cnt = check_number_of_components();
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < nodes[i].get_number_of_relations(); j++) {
			if (nodes[i].get_binary_significance(j) < cut_value && nodes[i].get_relation_visible(j)) {
				nodes[i].set_rel_visible(j, false);
				int cnt2 = check_number_of_components();
				if (cnt != cnt2) {
					nodes[i].set_rel_visible(j, true);
				}
			}
		}
	}
}

double graph::check_number_of_components()
{
	double cnt = 0;
	node_visited.assign(size, false);
	for (int i = 0; i < size; i++) {
		if (!node_visited[i]) {
			dfs(i);
			cnt++;
		}
	}
	return cnt;
}

void graph::dfs(int num)
{
	node_visited[num] = true;
	for (int i = 0; i < nodes[num].get_number_of_relations(); i++) {
		if (!node_visited[nodes[num].get_relation(i)] && nodes[num].get_relation_visible(i)) {
			dfs(nodes[num].get_relation(i));
		}
	}
}

void graph::push_user_values(double binFrequency, double unFrequency, double routingSig, double distanceSig, double nameSig)
{
	for (int i = 0; i < size; i++) {
		nodes[i].push_user_values(binFrequency, unFrequency, routingSig, distanceSig, nameSig);
	}
}

void graph::solve_conflict(int node1, int node2, double cut_value)
{
	double sigA_B = 0;
	for (int i = 0; i < nodes[node1].get_number_of_relations(); i++) {
		if (nodes[node1].get_relation(i) == node2) {
			sigA_B = nodes[node1].get_binary_significance(i);
		}
	}
	double sigB_A = 0;
	for (int i = 0; i < nodes[node2].get_number_of_relations(); i++) {
		if (nodes[node2].get_relation(i) == node1) {
			sigB_A = nodes[node2].get_binary_significance(i);
		}
	}
	double relA_B = (node1, node2, sigA_B);
	double relB_A = (node2, node1, sigB_A);
	if (std::abs(relA_B - relB_A) > cut_value) {
		if (relA_B > relB_A) {
			nodes[node2].set_rel_visible(node1, false);
		}
		else {
			nodes[node1].set_rel_visible(node2, false);
		}
	}
}

void graph::count_binary_frequency()
{
	int maximum = 0;
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < nodes[i].get_number_of_relations(); j++) {
			int cur = nodes[i].get_relation_frequency(j);
			if (cur > maximum)
				maximum = cur;
		}
	}
	for (int i = 0; i < size; i++) {
		nodes[i].count_binary_frequency(maximum);
	}
}