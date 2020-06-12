#include "stdafx.h"
#include "binary_metric.h"
#include "name_similarity.h"


binary_metric::binary_metric()
{
	binary_significance = 0;
	binary_frequency = 0;
	name_similar = 0;
	binary_distance = 0;
	aggregate = 0;
	user_distance = 0;
	user_frequency = 0;
	user_nameSig = 0;
}

void binary_metric::count_binary_frequency(int frequency, int maximum)
{
	binary_frequency = (double)frequency / (double)maximum;
}

double binary_metric::get_binary_frequency()
{
	return binary_frequency;
}

double binary_metric::get_binary_significance()
{
	return binary_significance;
}

void binary_metric::count_binary_significance()
{
	//here must be coef
	binary_significance = user_nameSig * name_similar 
		+ user_frequency * binary_frequency 
		+ user_distance * binary_distance;
}

void binary_metric::count_name_similarity(std::string first_name, std::string second_name)
{
	name_similarity name_sim;
	name_similar = name_sim.get_name_similarity(first_name, second_name);
}

double binary_metric::get_name_similarity()
{
	return name_similar;
}

void binary_metric::normalize_binary_distance(double maximum)
{
	if (maximum != 0) {
		binary_distance = binary_distance / maximum;
	}
}

double binary_metric::get_binary_distance()
{
	return binary_distance;
}

void binary_metric::count_aggregate()
{
	aggregate = name_similar + binary_frequency;
}

double binary_metric::get_aggregate()
{
	return aggregate;
}

void binary_metric::normalize_aggregate(double maximum)
{
	if (maximum > 0) {
		aggregate = aggregate / maximum;
	}
}

void binary_metric::normalize_binary_significance(double maximum)
{
	if (maximum != 0) {
		binary_significance = binary_significance / maximum;
	}
}

void binary_metric::set_user_values(double binFrequency, double distanceSig, double nameSig)
{
	user_distance = distanceSig;
	user_frequency = binFrequency;
	user_nameSig = nameSig;
}

void binary_metric::count_binary_distance(double me, double rel, double mid)
{
	if ((me + rel) != 0) {
		binary_distance = ((me - mid) + (rel - mid)) / (me + rel);
		if (binary_distance < 0) {
			binary_distance = -binary_distance;
		}
	}
	else
		binary_distance = 0;
}

