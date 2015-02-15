#include "list.h"
#include <iostream>

struct ListElement
{
	std::string value;
	ListElement *next = nullptr;
	ListElement *previous = nullptr;
};

struct List
{
	ListElement *head;
};



List *createList()
{
	List *list = new List();
	list->head = nullptr;
	return list;
}


void deleteList(List *list)
{
	while (list->head->next != nullptr)
	{
		ListElement *temp = list->head;
		list->head = list->head->next;
		temp->next = nullptr;
		list->head->previous = nullptr;
		delete temp;
	}
	if (list->head != nullptr)
	{
		delete list->head;
	}
	delete list;
}

void addToList(List *list, std::string const &element)
{
	ListElement *newElement = new ListElement;
	newElement->value = element;
	if (list->head == nullptr)
	{
		list->head = newElement;
		newElement->next = nullptr;
		newElement->previous = nullptr;
		return;
	}
	list->head->previous = newElement;
	newElement->next = list->head;
	newElement->previous = nullptr;
	list->head = newElement;
	ListElement *temp = newElement;
	while (temp->next != nullptr && temp->value > temp->next->value)
	{
		swap(temp->value, temp->next->value);
		temp = temp->next;
	}

}

void deleteElement(List *list, ListElement *listElement)
{
	ListElement *temp = listElement->next;
	listElement->next = temp->next;
	if (temp->next != nullptr)
	{
		temp->next->previous = listElement;
	}
	temp->previous = nullptr;
	temp->previous = nullptr;
	delete temp;
}

void deleteRepetetiveElements(List *list)
{
	if (list->head == nullptr || list->head->next == nullptr)
	{
		return;
	}
	ListElement *temp = list->head;
	while (temp->next != nullptr)
	{
		while (temp->next != nullptr && temp->value == temp->next->value)
		{
			deleteElement(list, temp);
		}
		if (temp->next != nullptr)
		{
			temp = temp->next;
		}
	}
}

void printList(List *list)
{
	if (list->head == nullptr)
	{
		std::cout << "List is empty." << std::endl << std::endl;
		return;
	}
	std::cout << "Printing list:" << std::endl;
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		std::cout << temp->value << std::endl;
		temp = temp->next;
	}
	delete temp;

}