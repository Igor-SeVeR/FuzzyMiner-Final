#include "stdafx.h"
#include "unary_metric.h"

unary_metric::unary_metric()
{
	unary_metric::normalized_frequncy = 0;
	unary_metric::normalized_routing = 0;
	unary_significance = 0;
	aggregate = 0;
	user_frequency = 0;
	user_routing = 0;
}

void unary_metric::count_frequency(int frequency, int maximum) {
	unary_metric::normalized_frequncy = (double)frequency / (double)maximum;
}

double unary_metric::get_normalized_frequency()
{
	return normalized_frequncy;
}

double unary_metric::get_normalized_routing()
{
	return normalized_routing;
}

void unary_metric::count_unary_routing(double val)
{
	normalized_routing = val;
}

void unary_metric::normalize_unary_routing(double maximum)
{
	if (maximum != 0) {
		normalized_routing /= maximum;
	}
}

void unary_metric::count_aggregate()
{
	aggregate = normalized_frequncy + normalized_routing;
}

double unary_metric::get_aggregate()
{
	return aggregate;
}

void unary_metric::normalize_aggregate(double maximum)
{
	if (maximum != 0)
		aggregate = aggregate / maximum;
}

void unary_metric::count_unary_significance()
{
	//Here must be coef
	unary_significance = user_frequency * normalized_frequncy + user_routing * normalized_routing;
}

double unary_metric::get_unary_significance()
{
	return unary_significance;
}

void unary_metric::normalize_unary_significance(double maximum)
{
	if (maximum != 0) {
		unary_significance = unary_significance / maximum;
	}
}

void unary_metric::set_user_values(double frequency, double routing)
{
	user_frequency = frequency;
	user_routing = routing;
}
