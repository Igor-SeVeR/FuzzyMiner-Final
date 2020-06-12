#pragma once
#include <fstream>
#include <string>
#include "graph.h"

class dotfile
{
	public:

		void create_dot(std::string name, graph model);

	private:
		std::ofstream fout;
};

