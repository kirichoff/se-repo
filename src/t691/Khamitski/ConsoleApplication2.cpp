// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <Windows.h>
#include <conio.h>
#include <dos.h>
#include <string>
#include "Stat.h"
#include "Header.h"
using namespace std;



int main()
{
	setlocale(LC_ALL,"");

	bool  alive = true;
	bool selfkill = false;
	Stat health(25);
	Stat hunger(25);
	Stat spirit(25);




	while (alive)
	{


		cout << health.val() <<" health    " << health.print() << endl;
		cout << hunger.val() <<" hunger    " << hunger.print() << endl;
		cout << spirit.val() <<" spirit    " << spirit.print() << endl;


		if (hunger.val() == 0)
		{
			health--;
		}
		
		hunger--;
		spirit--;


		if (spirit.val() == 0)
		{
			selfkill = true;
			alive = false;
			break;
		}

		if (health.val() == 0)
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
		if (!selfkill)
		{
			cout << "Game over!!" << endl;
		}
		else
		{
			cout << "Game over!! selfkill !!"  << endl;
		}
	}


	system("pause");
	return 0;
}

