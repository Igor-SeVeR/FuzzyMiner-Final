#pragma once
#include <map>
#include <vector>
#include "node.h"
#include <string>

class node;

class graph
{
	public:

		graph(std::vector<std::string> log);

		graph();

		node get_node(int i);

		int get_size();

		void count_binary_frequency();

		void count_unary_frequency();

		void count_unary_routing();

		void cut_nodes(double cut_off);

		void count_all_metrics();

		void count_name_similarity();

		void count_binary_distance();

		void count_aggregate();

		void count_unary_aggregate();

		void count_binary_significance();

		void count_unary_significance();

		void solve_conflicts(double cut_value);

		void solve_conflict(int node1, int node2, double cut_value);

		double count_rel(int node1, int node2, double sig);

		void cut_edges(double cut_value);

		double check_number_of_components();

		void dfs(int num);

		void push_user_values(double binFrequency, double unFrequency, 
			double routingSig, double distanceSig, double nameSig);

	private:
		std::map<std::string, int> all_names;
		int size;
		std::vector<node> nodes;
		std::vector<std::string> parse_line(std::string trace);
		std::vector<bool> node_visited;
};

