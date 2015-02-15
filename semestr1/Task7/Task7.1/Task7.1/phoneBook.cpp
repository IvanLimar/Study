#include "phoneBook.h"
#include <iostream>

using namespace std;

struct PhoneBookElement
{
	string name;
	string number;
	PhoneBookElement *next;
};

struct PhoneBook
{
	PhoneBookElement *head;
	PhoneBookElement *tail;
	int length;
};

PhoneBook *createPhoneBook()
{
	PhoneBook *phoneBook = new PhoneBook;
	phoneBook->length = 0;
	phoneBook->head = nullptr;
	phoneBook->tail = nullptr;
	return phoneBook;
}

void deletePhoneBook(PhoneBook *phoneBook)
{
	while (phoneBook->head != phoneBook->tail)
	{
		PhoneBookElement *temp = phoneBook->head;
		phoneBook->head = phoneBook->head->next;
		temp->next = nullptr;
		delete temp;
	}
	if (phoneBook->head != nullptr)
	{
		delete phoneBook->head;
	}
	delete phoneBook;
}

//Добавление в хвост
void add(PhoneBook *phoneBook, std::string const &name, std::string const &number)
{
	++phoneBook->length;
	PhoneBookElement *newElement = new PhoneBookElement();
	newElement->name = name;
	newElement->number = number;
	newElement->next = nullptr;
	if (phoneBook->head == nullptr)
	{
		phoneBook->head = newElement;
		phoneBook->tail = newElement;
		return;
	}
	phoneBook->tail->next = newElement;
	phoneBook->tail = newElement;
}

// Проверяет, отсортирован ли phoneBook по name(если isName - true) или по number(если isName - false)
bool isPhoneBookSorted(PhoneBook *phoneBook, bool isName)
{
	if (phoneBook->length == 1)
	{
		return true;
	}
	PhoneBookElement *temp = phoneBook->head;
	if (isName)
	{
		while (temp->next!= nullptr)
		{
			if (temp->name > temp->next->name)
			{
				return false;
			}
			temp = temp->next;
		}
		return true;
	}
	else
	{
		while (temp->next != nullptr)
		{
			if (temp->number > temp->next->number)
			{
				return false;
			}
			temp = temp->next;
		}
		return true;
	}
}

//Разделяет phoneBook на phoneBookLeft и phoneBookRight
void dividing(PhoneBook *phoneBook, PhoneBook *phoneBookLeft, PhoneBook *phoneBookRight)
{
	int const leftLength = phoneBook->length / 2;
	int const rightLength = phoneBook->length - leftLength;
	PhoneBookElement *temp = phoneBook->head;
	for (int i = 0; i < leftLength; ++i)
	{
		string name = temp->name;
		string number = temp->number;
		add(phoneBookLeft, name, number);
		temp = temp->next;
	}
	for (int i = 0; i < rightLength; ++i)
	{
		string name = temp->name;
		string number = temp->number;
		add(phoneBookRight, name, number);
		if (temp->next != nullptr)
		{
			temp = temp->next;
		}	
	}
}

//Очищаем phoneBook
void clear(PhoneBook *phoneBook)
{
	if (phoneBook->head == nullptr)
	{
		return;
	}
	while (phoneBook->head != phoneBook->tail)
	{
		PhoneBookElement *temp = phoneBook->head;
		phoneBook->head = phoneBook->head->next;
		temp->next = nullptr;
		delete temp;
		--phoneBook->length;
	}
	PhoneBookElement *temp = phoneBook->head;
	phoneBook->head = nullptr;
	phoneBook->tail = nullptr;
	delete temp;
	--phoneBook->length;
}

// Склеивает отсортированные phoneBookLeft и phoneBookRight в phoneBook по name (если isName - true) или по number (если isName - false)
void merging(PhoneBook *phoneBookLeft, PhoneBook *phoneBookRight, PhoneBook *phoneBook, bool isName)
{
	PhoneBookElement *tempLeft = phoneBookLeft->head;

	PhoneBookElement *tempRight = phoneBookRight->head;
	
	clear(phoneBook);

	bool isRightEnd = false;
	bool isLeftEnd = false;

	while (!isLeftEnd || !isRightEnd)
	{
		if (isLeftEnd)
		{
			while (!isRightEnd)
			{
				string name = tempRight->name;
				string number = tempRight->number;
				add(phoneBook, name, number);
				if (tempRight->next != nullptr)
				{
					tempRight = tempRight->next;
				}
				else
				{
					isRightEnd = true;
				}
			}
		}
		if (isRightEnd)
		{
			while (!isLeftEnd)
			{
				string name = tempLeft->name;
				string number = tempLeft->number;
				add(phoneBook, name, number);
				if (tempLeft->next != nullptr)
				{
					tempLeft = tempLeft->next;
				}
				else
				{
					isLeftEnd = true;
				}
			}
		}
		if (!isLeftEnd && !isRightEnd)
		{
			if (isName && tempLeft->name <= tempRight->name || !isName && tempLeft->number <= tempRight->number)
			{
				string name = tempLeft->name;
				string number = tempLeft->number;
				add(phoneBook, name, number);
				if (tempLeft->next != nullptr)
				{
					tempLeft = tempLeft->next;
				}
				else
				{
					isLeftEnd = true;
				}
			}
			else
			{
				string name = tempRight->name;
				string number = tempRight->number;
				add(phoneBook, name, number);
				if (tempRight->next != nullptr)
				{
					tempRight = tempRight->next;
				}
				else
				{
					isRightEnd = true;
				}
			}
		}
	}
}

void writing(PhoneBook *phoneBook)
{
	PhoneBookElement *temp = phoneBook->head;
	while (true)
	{
		cout << temp->name << " " << temp->number << endl;
		if (temp->next != nullptr)
		{
			temp = temp->next;
		}
		else
		{
			break;
		}		
	}
}

void mergeSort(PhoneBook *phoneBook, bool isName)
{
	if (isPhoneBookSorted(phoneBook, isName))
	{
		return;
	}
	PhoneBook *phoneBookLeft = createPhoneBook();

	PhoneBook *phoneBookRight = createPhoneBook();

	dividing(phoneBook, phoneBookLeft, phoneBookRight);
	if (isPhoneBookSorted(phoneBookLeft, isName) && isPhoneBookSorted(phoneBookRight, isName))
	{
		merging(phoneBookLeft, phoneBookRight, phoneBook, isName);
	}
	else
	{
		if (!isPhoneBookSorted(phoneBookLeft, isName))
		{
			mergeSort(phoneBookLeft, isName);
		}
		if (!isPhoneBookSorted(phoneBookRight, isName))
		{
			mergeSort(phoneBookRight, isName);
		}
		merging(phoneBookLeft, phoneBookRight, phoneBook, isName);
	}
	deletePhoneBook(phoneBookLeft);
	deletePhoneBook(phoneBookRight);
}