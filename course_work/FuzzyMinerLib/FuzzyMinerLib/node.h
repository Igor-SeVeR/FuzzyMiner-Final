#pragma once
#include <vector>
#include <string>
#include "unary_metric.h"
#include "binary_metric.h"
#include "graph.h"

class graph;

class node
{
	public:

		node();

		node(int _frequency, std::string _name);

		int get_relation(int num);

		int get_relation_frequency(int num);

		std::string get_name();

		int get_node_frequency();

		void inc_frequency();

		void inc_in_relations();

		void inc_out_relations();

		void push_relation(int num);

		void push_relation_in(int num);

		int get_number_of_relations();

		double get_unary_significanse();

		void count_unary_frequency(int maximum);

		double get_unary_frequency();

		void count_binary_frequency(int maximum);

		double get_binary_frequency(int pos);

		bool get_visible();

		void set_visible(bool val);

		void count_name_similarity(graph *fuzzy);

		void count_unary_routing(graph* fuzzy, int num);

		double get_unary_routing();

		void normalize_unary_routing(double maximum);

		void normalize_binary_distance(double maximum);

		void count_binary_distance(graph* fuzzy, int num);

		void count_aggregate();

		double get_max_aggregate();

		void normalize_aggregate(double maximum);

		void count_unary_aggregate();

		double get_unary_aggregate();

		void normalize_unary_aggregate(double maximum);

		double get_max_distance();

		void normalize_distance(double max);

		void count_binary_significance();

		double get_max_binary_significance();

		void normalize_binary_significance(double maximum);

		void count_unary_significance();

		void normalize_unary_significance(double maximum);

		int get_number_of_in_relations();

		int get_in_relation(int num);

		double get_binary_significance(int num);

		void set_rel_visible(int num, bool val);

		bool get_relation_visible(int num);

		void push_user_values(double binFrequency, double unFrequency,
			double routingSig, double distanceSig, double nameSig);

	private:
		std::vector<std::pair<int, int>> relations;
		std::vector<binary_metric> binary;
		std::vector<int> relations_in;
		std::vector<bool> visible_relations;
		unary_metric unary;
		std::string name;
		bool visible;
		int frequency, amount_of_edges_in, amount_of_edges_out;

};

