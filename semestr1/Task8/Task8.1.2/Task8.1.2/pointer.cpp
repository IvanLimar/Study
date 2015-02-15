//#include "list.h"
#include <iostream>

using namespace std;

struct ListElement
{
	int position;
	int element;
	ListElement *next;
};

struct List
{
	ListElement *head;
	ListElement *tail;
};

List *createList(int length)
{
	List *list = new List;
	ListElement *first = new ListElement;
	first->position = 0;
	first->element = 0;
	first->next = nullptr;
	list->head = first;
	list->tail = first;
	for (int i = 1; i < length; ++i)
	{
		ListElement *newElement = new ListElement;
		newElement->position = i;
		newElement->element = 0;
		newElement->next = nullptr;
		list->tail->next = newElement;
		list->tail = newElement;
	}
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

void addToList(List *list, int &length, int number, int position)
{
	if (position < 0)
	{
		cout << "Impossible!" << endl;
		return;
	}
	if (position < length)
	{
		ListElement *temp = list->head;
		while (temp->position < position)
		{
			temp = temp->next;
		}
		temp->element = number;
		return;
	}
	length = position + 1;
	int index = list->tail->position;
	for (int i = index + 1; i < length; ++i)
	{
		ListElement *newElement = new ListElement;
		newElement->position = i;
		if (i == position)
		{
			newElement->element = number;
		}
		newElement->element = 0;
		newElement->next = nullptr;
		list->tail->next = newElement;
		list->tail = newElement;
	}
}

int element(List *list, int length, int position)
{
	if (position >= length || position < 0)
	{
		return -999999;
	}
	ListElement *temp = list->head;
	while (temp->position < position)
	{
		temp = temp->next;
	}
	return temp->element;
}

void printList(List *list, int length)
{
	
	cout << "Printing list:" << endl;
	if (length == 0)
	{
		cout << "List is empty." << endl;
		return;
	}
	ListElement *temp = list->head;
	bool isEnd = false;
	while (!isEnd)
	{
		cout << temp->element << endl;
		if (temp->next == nullptr)
		{
			isEnd = true;
		}
		else
		{
			temp = temp->next;
		}
	}
}