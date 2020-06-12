#include "stdafx.h"
#include "stdafx.h"
#include "node.h"
#include <vector>
#include <string>
#include "binary_metric.h"


node::node() {
	node::frequency = 0;
	node::name = "";
	node::visible = true;
}

node::node(int _frequency, std::string _name) {
	node::frequency = _frequency;
	node::amount_of_edges_in = 0;
	node::amount_of_edges_out = 0;
	node::name = _name;
	node::visible = true;
	unary;
}

void node::push_relation(int num) {
	for (int i = 0; i < (int)node::relations.size(); i++) {
		if (node::relations[i].first == num) {
			node::relations[i].second++;
			node::visible_relations[i] = true;
			return;
		}
	}
	node::relations.push_back(std::make_pair(num, 1));
	visible_relations.push_back(true);
}

void node::push_relation_in(int num)
{
	for (int i = 0; i < (int)node::relations_in.size(); i++) {
		if (node::relations_in[i] == num) {
			return;
		}
	}
	node::relations_in.push_back(num);
}

int node::get_relation(int num) {
	return node::relations[num].first;
}

int node::get_number_of_relations() {
	return (int)node::relations.size();
}

double node::get_unary_significanse()
{
	return unary.get_unary_significance();
}

void node::count_unary_frequency(int maximum)
{
	node::unary.count_frequency(node::frequency, maximum);
}

double node::get_unary_frequency()
{
	return unary.get_normalized_frequency();
}

void node::count_binary_frequency(int maximum)
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].count_binary_frequency(relations[i].second, maximum);
	}
}

double node::get_binary_frequency(int pos)
{
	return binary[pos].get_binary_frequency();
}

bool node::get_visible()
{
	return visible;
}

void node::set_visible(bool val)
{
	visible = val;
}

void node::count_name_similarity(graph *fuzzy)
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].count_name_similarity(name, (*fuzzy).get_node(relations[i].first).get_name());
	}
}

void node::count_unary_routing(graph* fuzzy, int num)
{
	double outVal = 0;
	for (int i = 0; i < relations.size(); i++) {
		double binSig = binary[i].get_binary_frequency();
		double binCor = binary[i].get_name_similarity();
		outVal += binCor * binSig;
	}
	double inVal = 0;
	for (int i = 0; i < relations_in.size(); i++) {
		node q = (*fuzzy).get_node(relations_in[i]);
		double binSig = 0;
		double binCor = 0;
		for (int j = 0; j < q.get_number_of_relations(); j++) {
			if (q.relations[j].first == num) {
				binSig = q.binary[j].get_binary_frequency();
				binCor = q.binary[j].get_name_similarity();
			}
		}
		inVal += binCor * binSig;
	}
	if (inVal == 0 && outVal == 0) {
		unary.count_unary_routing(0);
	}
	else {
		double res = ((inVal - outVal) / (inVal + outVal));
		if (res < 0.0) {
			res = -res;
		}
		unary.count_unary_routing(res);
	}
}

double node::get_unary_routing()
{
	return unary.get_normalized_routing();
}

void node::normalize_unary_routing(double maximum)
{
	unary.normalize_unary_routing(maximum);
}

void node::normalize_binary_distance(double maximum)
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].normalize_binary_distance(maximum);
	}
}

void node::count_binary_distance(graph* fuzzy, int num)
{
	double our_agg = get_unary_aggregate();
	for (int i = 0; i < relations.size(); i++) {
		double rel_agg = (*fuzzy).get_node(relations[i].first).get_unary_aggregate();
		double bin_agg = binary[i].get_aggregate();
		binary[i].count_binary_distance(our_agg, rel_agg, bin_agg);
	}
}

void node::count_aggregate()
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].count_aggregate();
	}
}

double node::get_max_aggregate()
{
	double maximum = 0;
	for (int i = 0; i < relations.size(); i++) {
		if (binary[i].get_aggregate() > maximum) {
			maximum = binary[i].get_aggregate();
		}
	}
	return maximum;
}

void node::normalize_aggregate(double maximum)
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].normalize_aggregate(maximum);
	}
}

void node::count_unary_aggregate()
{
	unary.count_aggregate();
}

double node::get_unary_aggregate()
{
	return unary.get_aggregate();
}

void node::normalize_unary_aggregate(double maximum)
{
	unary.normalize_aggregate(maximum);
}

double node::get_max_distance()
{
	double maximum = 0;
	for (int i = 0; i < relations.size(); i++) {
		if (binary[i].get_binary_distance() > maximum) {
			maximum = binary[i].get_binary_distance();
		}
	}
	return maximum;
}

void node::normalize_distance(double maximum)
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].normalize_binary_distance(maximum);
	}
}

void node::count_binary_significance()
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].count_binary_significance();
	}
}

double node::get_max_binary_significance()
{
	double maximum = 0;
	for (int i = 0; i < relations.size(); i++) {
		if (binary[i].get_binary_significance() > maximum) {
			maximum = binary[i].get_binary_significance();
		}
	}
	return maximum;
}

void node::normalize_binary_significance(double maximum)
{
	for (int i = 0; i < relations.size(); i++) {
		binary[i].normalize_binary_significance(maximum);
	}
}

void node::count_unary_significance()
{
	unary.count_unary_significance();
}

void node::normalize_unary_significance(double maximum)
{
	unary.normalize_unary_significance(maximum);
}

int node::get_number_of_in_relations()
{
	return relations_in.size();
}

int node::get_in_relation(int num)
{
	return relations_in[num];
}

double node::get_binary_significance(int num)
{
	return binary[num].get_binary_significance();
}

void node::set_rel_visible(int num, bool val)
{
	for (int i = 0; i < relations.size(); i++) {
		if (relations[i].first == num) {
			visible_relations[i] = val;
			return;
		}
	}
}

bool node::get_relation_visible(int num)
{
	return visible_relations[num];
}

void node::push_user_values(double binFrequency, double unFrequency, double routingSig, double distanceSig, double nameSig)
{
	binary.resize(relations.size());
	unary.set_user_values(unFrequency, routingSig);
	for (int i = 0; i < relations.size(); i++) {
		binary[i].set_user_values(binFrequency, distanceSig, nameSig);
	}
}

int node::get_relation_frequency(int num) {
	return node::relations[num].second;
}

std::string node::get_name() {
	return node::name;
}

int node::get_node_frequency() {
	return node::frequency;
}

void node::inc_frequency() {
	node::frequency++;
}

void node::inc_in_relations()
{
	node::amount_of_edges_in++;
}

void node::inc_out_relations()
{
	node::amount_of_edges_out++;
}
