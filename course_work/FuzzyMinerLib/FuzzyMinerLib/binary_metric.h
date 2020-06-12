#pragma once
#include <string>

class binary_metric
{
	public:

		binary_metric();

		void count_binary_frequency(int frequency, int maximum);

		double get_binary_frequency();

		double get_binary_significance();

		void count_binary_significance();

		void count_name_similarity(std::string first_name, std::string second_name);

		double get_name_similarity();

		void normalize_binary_distance(double maximum);

		double get_binary_distance();

		void count_aggregate();

		void normalize_aggregate(double maximum);

		void count_binary_distance(double me, double rel, double mid);

		double get_aggregate();

		void normalize_binary_significance(double maximum);

		void set_user_values(double binFrequency, double distanceSig, double nameSig);

	private:
		double binary_frequency;
		double binary_distance;
		double binary_significance;
		double name_similar;
		double aggregate;
		double user_frequency;
		double user_distance;
		double user_nameSig;
};

