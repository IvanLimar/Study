#include <iostream>
#include "PhoneBook.h"

using namespace std;

struct PhoneBook
{
	string name;
	string number;
};

void addToPhoneBook(PhoneBook *phoneBook, int position)
{
	cout << "Enter the name:" << endl;
	cin >> phoneBook[position].name;
	cout << "Enter the number:" << endl;
	cin >> phoneBook[position].number;
	cout << "The name and number were added" << endl;
}

void findPhoneNumbers(string const &name, PhoneBook *phoneBook, int length)
{
	cout << "Numbers:" << endl;
	bool isCorrect = false;
	for (int i = 0; i < length; ++i)
	{
		if (name == phoneBook[i].name)
		{
			cout << phoneBook[i].number << endl;
			isCorrect = true;
		}
	}
	if (!isCorrect)
	{
		cout << "Can't find numbers, which refers to entered name." << endl;
	}
}

void findPhoneNames(string const &number, PhoneBook *phoneBook, int length)
{
	cout << "Names:" << endl;
	bool isCorrect = false;
	for (int i = 0; i < length; ++i)
	{
		if (number == phoneBook[i].number)
		{
			cout << phoneBook[i].name << endl;
			isCorrect = true;
		}
	}
	if (!isCorrect)
	{
		cout << "Can't find names, which refers to entered number." << endl;
	}
}

void reading(std::fstream &file, PhoneBook *phoneBook, int &position)
{
	if (!file.is_open())
	{
		cout << "File not found! Phone book is empty. " << endl << endl;
	}
	else
	{
		while (!file.eof())
		{
			if (position < 100)
			{
				file >> phoneBook[position].name;
				file >> phoneBook[position].number;
				++position;
			}
			else
			{
				cout << "Phone book is full." << endl << endl;
				break;
			}
		}
		cout << "Names and numbers were read." << endl << endl;
	}
}

PhoneBook *createPhoneBook()
{
	PhoneBook *phoneBook = new PhoneBook[100];
	return phoneBook;
}

void writing(std::fstream &file, PhoneBook *phoneBook, int position)
{
	for (int i = 0; i < position; ++i)
	{
		file << phoneBook[i].name;
		file << " ";
		file << phoneBook[i].number;
		file << endl;
	}
}

void deleteBook(PhoneBook *phoneBook)
{
	delete[] phoneBook;
}