// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <Windows.h>
#include <conio.h>
#include <dos.h>
#include <string>
using namespace std;


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

	int printval()
	{
		return count;
	}



	void operator-- (int) 
	{
		count--;
		if (count != 0) {
			bar.pop_back();
		}
	}

	void operator++ (int)
	{
		count++;
		bar += "-";
	}

};


bool KEY[256];
void GetKEY()
{
	int i = 0;
	while (i < 256)
	{
		if (GetAsyncKeyState(i)) KEY[i] = 1; else KEY[i] = 0;
		i++;
	}
}


int main()
{

	/*int health = 10;
	int hunger = 10;
	int spirit = 10;
	string healthbar;
	string hungerbar;
	string spiritbar;*/
	bool  alive = true;

	Stat health(15);
	Stat hunger(15);
	Stat spirit(15);




	while (alive)
	{



		cout << health.printval() <<" health    " << health.print() << endl;
		cout << hunger.printval() <<" hunger    " << hunger.print() << endl;
		cout << spirit.printval() <<" spirit    " << spirit.print() << endl;



		health--;
		hunger--;
		spirit--;


		if ((health.printval() || hunger.printval() || spirit.printval()) == 0)
		{
			alive = false;
			break;
		}



		cout << "press F to pay respect      press G to fead       presss  H to heal " << endl;

		GetKEY();
		if (KEY[70])
		{
			spirit++;
			cout << "repsect" << endl;
		}
		if (KEY[71])
		{
			hunger++;
			cout << " fead " << endl;
		}

		if (KEY[72])
		{
			health++;
			cout << " Heal " << endl;
		}
		Sleep(1000);

		system("cls");
	}


	if (!alive) {
		cout << "Game over!!" << endl;
	}


	system("pause");
	return 0;
}

