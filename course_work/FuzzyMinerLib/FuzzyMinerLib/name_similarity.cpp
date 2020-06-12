#include "stdafx.h"
#include "name_similarity.h"

double name_similarity::get_name_similarity(std::string first, std::string second)
{
	int n = first.length();
	int m = second.length();

	if (n == 0) {
		return m;
	}
	else if (m == 0) {
		return n;
	}
	int MAX_N = n + m;

	int cost;

	std::vector<int> d(MAX_N + 1), p(MAX_N + 1);

	for (int i = 0; i <= n; i++) {
		p[i] = i;
	}

	std::string s, f;

	for (int j = 1; j <= m; j++) {
		s = second[j - 1];
		d[0] = j;
		f = "";
		for (int i = 1; i <= n; i++) {
			f = first[i - 1];
			if (s == f)
				cost = 0;
			else
				cost = 1;
			if (d[i - 1] + 1 < p[i] + 1) {
				d[i] = d[i - 1] + 1;
			}
			else {
				d[i] = p[i] + 1;
			}
			if (d[i] > p[i - 1] + cost) {
				d[i] = p[i - 1] + cost;
			}
		}
		std::swap(p, d);
	}

	return 1.0 - (p[n] / MAX_N);
}
