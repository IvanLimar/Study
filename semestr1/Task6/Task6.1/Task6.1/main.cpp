#include <iostream>
#include <fstream>
#include "PhoneBook.h"

using namespace std;


// Вывод инструкции
void instruction()
{
	cout << "Press 0 to exit." << endl;
	cout << "Press 1 to add name and number to phone book." << endl;
	cout << "Press 2 to find numbers after entering the name." << endl;
	cout << "Press 3 to find names after entering the number" << endl;
	cout << "Press 4 to write names and numbers into file." << endl;
}


void main()
{
	PhoneBook *phoneBook = createPhoneBook();

	cout << "Phone book" << endl;
	cout << "Reading names and numbers from file..." << endl;

	int position = 0;
	fstream file("phoneBook.txt");
	reading(file, phoneBook, position);
	file.close();
	--position;
	while (true)
	{
		instruction();
		cout << endl;
		char key = ' ';
		cin >> key;
		cout << endl;

		if (key == '0')
		{
			break;
		}

		if (key == '1')
		{
			if (position < 100)
			{
				addToPhoneBook(phoneBook, position);
				cout << endl;
				++position;
			}
			else
			{
				cout << "Book is full. You can't add new names and numbers." << endl << endl;
			}
			
		}

		if (key == '2')
		{
			cout << "Enter the name:" << endl;
			string name;
			cin >> name;
			findPhoneNumbers(name, phoneBook, 100);
			cout << endl;
		}

		if (key == '3')
		{
			cout << "Enter the number:" << endl;
			string number;
			cin >> number;
			findPhoneNames(number, phoneBook, 100);
			cout << endl;
		}

		if (key == '4')
		{
			fstream file("phoneBook.txt");
			file.clear();
			writing(file, phoneBook, position);
			file.close();
			cout << "Writing complete." << endl << endl;
		}

	}
	deleteBook(phoneBook);
}
/*
Если в исходном txt файле больше 100 записей, то буду прочитаны первые 100.
Если в массиве phoneBook уже есть 100 элементов, то туда не получится добавить новые элементы.
Если исходгого txt файла нет, то массив phoneBook будет пуст.
*/