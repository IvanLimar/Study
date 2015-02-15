#include "list.h"
#include <iostream>

struct ListElement
{
	int value;
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
	List *list = new List();
	list->head = nullptr;
	list->tail = nullptr;
	list->length = 0;
	return list;
}

void addToList(List *list, int element)
{
	++list->length;
	ListElement *newElement = new ListElement();
	newElement->next = nullptr;
	newElement->value = element;

	if (list->head == nullptr)
	{
		list->head = newElement;
		list->tail = newElement;
	}
	else
	{
		list->tail->next = newElement;
		list->tail = newElement;
	}
}

void deleteList(List *list)
{
	while (list->head != list->tail)
	{
		ListElement *temp = new ListElement();
		temp->next = list->head;
		list ->head = list->head->next;
		temp->next->next = nullptr;
		delete temp->next;
		delete temp;
	}
	delete list->head;
	delete list;
}

//Проверяет отсортированность lista
bool isListSorted(List *list)
{
	if (list->length == 1)
	{
		return true;
	}
	ListElement *temp = new ListElement();
	temp->next = list->head;
	
	while (temp->next->next != nullptr)
	{
		if (temp->next->value > temp->next->next->value)
		{
			delete temp;
			return false;
		}
		temp->next = temp->next->next;
	}
	delete temp;
	return true;
}


//По position находит listElement
ListElement *returnElement(List *list, int position)
{
	ListElement listElement;
	listElement.next = list->head;
	for (int i = 0; i < list->length; ++i)
	{
		if (i == position)
		{
			return listElement.next;
		}
		listElement.next = listElement.next->next;
	}
}

//Делит list пополам на listLeft и listRight
void dividingList(List *list, List *listLeft, List *listRight)
{
	for (int i = 0; i < list->length; ++i)
	{
		if (i < list->length / 2)
		{
			addToList(listLeft, returnElement(list, i)->value);
		}
		else
		{
			addToList(listRight, returnElement(list, i)->value);
		}
	}
}

// Склеивает отсортированные listLeft и listRight в list
void mergingList(List *listLeft, List *listRight, List *list)
{
	ListElement *tempLeft = new ListElement();
	tempLeft->next = listLeft->head;

	ListElement *tempRight = new ListElement();
	tempRight->next = listRight->head;

	ListElement *temp = new ListElement();
	temp->next = list->head;


	while (tempLeft->next != nullptr | tempRight->next != nullptr)
	{
		if (tempLeft->next == nullptr)
		{
			while (tempRight->next != nullptr)
			{
				temp->next->value = tempRight->next->value;
				tempRight->next = tempRight->next->next;
				if (temp->next != nullptr)
				{
					temp->next = temp->next->next;
				}
			}
		}
		if (tempRight->next == nullptr)
		{
			while (tempLeft->next != nullptr)
			{
				temp->next->value = tempLeft->next->value;
				tempLeft->next = tempLeft->next->next;
				if (temp->next != nullptr)
				{
					temp->next = temp->next->next;
				}
			}
		}
		if (tempRight->next != nullptr && tempLeft->next != nullptr)
		{
			if (tempLeft->next->value <= tempRight->next->value)
			{
				temp->next->value = tempLeft->next->value;
				tempLeft->next = tempLeft->next->next;
			}
			else
			{
				temp->next->value = tempRight->next->value;
				tempRight->next = tempRight->next->next;
			}
		}
		if (temp->next != nullptr)
		{
			temp->next = temp->next->next;
		}
	}
	delete temp;
	delete tempRight;
	delete tempLeft;
}

void listMergeSort(List *list)
{
	if (isListSorted(list))
	{
		return;
	}
	List *listLeft = new List();
	listLeft->head = nullptr;
	listLeft->tail = nullptr;

	List *listRight = new List();
	listRight->head = nullptr;
	listRight->tail = nullptr;

	dividingList(list, listLeft, listRight);
	if (isListSorted(listLeft) && isListSorted(listRight))
	{
		mergingList(listLeft, listRight, list);
	}
	else
	{
		if (!isListSorted(listLeft))
		{
			listMergeSort(listLeft);
		}
		if (!isListSorted(listRight))
		{
			listMergeSort(listRight);
		}
		mergingList(listLeft, listRight, list);
	}
	deleteList(listLeft);
	deleteList(listRight);
}

void writingList(List *list)
{
	std::cout << "Your list:" << std::endl;
	ListElement temp;
	temp.next = list->head;
	while (temp.next != nullptr)
	{
		std::cout << temp.next->value << std::endl;
		temp.next = temp.next->next;
	}
}