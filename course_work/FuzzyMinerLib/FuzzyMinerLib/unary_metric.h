#pragma once
class unary_metric
{
	public:
		unary_metric();

		void count_frequency(int frequency, int maximum);

		double get_normalized_frequency();

		double get_normalized_routing();

		void count_unary_routing(double val);

		void normalize_unary_routing(double maximum);

		void count_aggregate();

		double get_aggregate();

		void normalize_aggregate(double maximum);

		void count_unary_significance();

		double get_unary_significance();

		void normalize_unary_significance(double maximum);

		void set_user_values(double frequency, double routing);

	private:
		double normalized_frequncy;
		double normalized_routing;
		double aggregate;
		double unary_significance;
		double user_frequency;
		double user_routing;

};

