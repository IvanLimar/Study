#include <iostream>
#include <string>
#include <fstream>
#include "phoneBook.h"

using namespace std;


void main()
{
	PhoneBook *phoneBook = createPhoneBook();
	ifstream file("Text.txt", ios::in);
	while (!file.eof())
	{
		string name;
		file >> name;
		string number;
		file >> number;
		add(phoneBook, name, number);
	}
	file.close();

	cout << "Prees 1 to sort names in phone book, 2 - numbers " << endl;
	char key = ' ';
	cin >> key;
	while (key != '1' && key != '2')
	{
		cout << "You entered wrong command!" << endl;
		cin >> key;
	}
	mergeSort(phoneBook, key == '1');
	writing(phoneBook);
	deletePhoneBook(phoneBook);
}