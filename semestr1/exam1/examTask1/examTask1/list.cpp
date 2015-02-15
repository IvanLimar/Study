#include "list.h"
#include <iostream>

using namespace std;

struct ListElement
{
	int number;
	ListElement *next;
};

struct List
{
	ListElement *head;
	ListElement *tail;
	int length;
};

List *createList()
{
	List *list = new List;
	list->length = 0;
	list->head = nullptr;
	list->tail = nullptr;
	return list;
}

void deleteList(List *list)
{
	while (list->head != list->tail)
	{
		ListElement *temp = list->head;
		list->head = list->head->next;
		temp->next = nullptr;
		delete temp;
	}
	if (list->head != nullptr)
	{
		delete list->head;
	}
	delete list;
}

void add(List *list, int number)
{
	++list->length;
	ListElement *newElement = new ListElement;
	newElement->number = number;
	newElement->next = nullptr;
	if (list->head == nullptr)
	{
		list->head = newElement;
		list->tail = newElement;
		return;
	}
	list->tail->next = newElement;
	list->tail = newElement;
}

// Проверяет, отсортирован ли list
bool isListSorted(List *list)
{
	if (list->length == 1)
	{
		return true;
	}
	ListElement *temp = list->head;
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

//Разделяет list на listLeft и ListRight
void dividing(List *list, List *listLeft, List *listRight)
{
	int const leftLength = list->length / 2;
	int const rightLength = list->length - leftLength;
	ListElement *temp = list->head;
	for (int i = 0; i < leftLength; ++i)
	{
		int number = temp->number;
		add(listLeft, number);
		temp = temp->next;
	}
	for (int i = 0; i < rightLength; ++i)
	{
		int number = temp->number;
		add(listRight, number);
		if (temp->next != nullptr)
		{
			temp = temp->next;
		}
	}
}

//Очищаем list
void clear(List *list)
{
	if (list->head == nullptr)
	{
		return;
	}
	while (list->head != list->tail)
	{
		ListElement *temp = list->head;
		list->head = list->head->next;
		temp->next = nullptr;
		delete temp;
		--list->length;
	}
	ListElement *temp = list->head;
	list->head = nullptr;
	list->tail = nullptr;
	delete temp;
	--list->length;
}

// Склеивает отсортированные phoneBookLeft и phoneBookRight в phoneBook по name (если isName - true) или по number (если isName - false)
void merging(List *listLeft, List *listRight, List *list)
{
	ListElement *tempLeft = listLeft->head;

	ListElement *tempRight = listRight->head;

	clear(list);

	bool isRightEnd = false;
	bool isLeftEnd = false;

	while (!isLeftEnd || !isRightEnd)
	{
		if (isLeftEnd)
		{
			while (!isRightEnd)
			{
				int number = tempRight->number;
				add(list, number);
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
				int number = tempLeft->number;
				add(list, number);
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
			if (tempLeft->number <= tempRight->number)
			{
				int number = tempLeft->number;
				add(list, number);
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
				int number = tempRight->number;
				add(list, number);
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

void writing(List *list)
{
	ListElement *temp = list->head;
	int quantity = 1;
	bool isEnd = false;
	while (!isEnd)
	{
		if (quantity == 1)
		{
			cout << "Number " << temp->number << " was meet ";
		}
		if (temp->next != nullptr)
		{
			if (temp->number == temp->next->number)
			{
				++quantity;
			}
			else
			{
				cout << quantity << " times" << endl;
				quantity = 1;
			}
			temp = temp->next;
		}
		else
		{
			cout << quantity << " times" << endl;
			isEnd = true;
		}
	}
}

void mergeSort(List *list)
{
	if (isListSorted(list))
	{
		return;
	}
	List *listLeft = createList();

	List *listRight = createList();

	dividing(list, listLeft, listRight);
	if (isListSorted(listLeft) && isListSorted(listRight))
	{
		merging(listLeft, listRight, list);
	}
	else
	{
		if (!isListSorted(listLeft))
		{
			mergeSort(listLeft);
		}
		if (!isListSorted(listRight))
		{
			mergeSort(listRight);
		}
		merging(listLeft, listRight, list);
	}
	deleteList(listLeft);
	deleteList(listRight);
}

void reading(List *list)
{
	int number = -1;
	cout << "Enter numbers. If you enter zero, entering will complete." << endl;
	while (number != 0)
	{
		cout << "Enter a number: ";
		cin >> number;
		add(list, number);
	}
}