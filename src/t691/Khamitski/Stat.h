#pragma once
#include <string>
class Stat
{
	int count;
	string bar;
public:
	Stat(int val)
	{
		count = val;

		for (int i = 0; i < val; i++)
		{
			bar += "-";
		}
	}

	string print()
	{
		return bar;
	}

	int val()
	{
		return count;
	}



	void operator-- (int)
	{
		if (count > 0) {
			count--;
			bar.pop_back();
		}
	}

	void operator++ (int)
	{
		count++;
		bar += "-";
	}

};


