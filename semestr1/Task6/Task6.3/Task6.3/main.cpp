#include <iostream>

using namespace std;

struct List;
struct ListElement;

struct ListElement
{
	int number;
	ListElement *next;
};

struct List
{
	ListElement *head;
};

//Функция создаёт циклический список длины lenght
void createList(List *list ,int length)
{	
	ListElement *temp = list->head;
	for (int i = 0; i < length; ++i)
	{
		ListElement *listElement = new ListElement();
		if (list->head == nullptr)
		{
			list->head = listElement;
		}
		else
		{
			temp->next = listElement;
		}
		temp = listElement;
		listElement->number = i + 1;
		if (i == length - 1)
		{
			listElement->next = list->head;
		}
		else
		{
			listElement->next = nullptr;
		}
	}
}

//Функция удаляет элемент, находящийся после listElement.
void deleteListElement(List *list, ListElement *listElement)
{
	if (listElement->next == listElement)
	{
		list->head = nullptr;
		delete listElement;
		return;
	}
	if (list->head == listElement->next)
	{
		list->head = list->head->next;
	}
	ListElement *temp = listElement->next;
	listElement->next = temp->next;
	temp->next = nullptr;
	delete temp;
}

// Удаление списка List
void deleteList(List *list)
{
	if (list->head == nullptr)
	{
		delete list;
		return;
	}

	while (list->head != list->head->next)
	{
		ListElement *temp = list->head->next;
		list->head->next = temp->next;
		temp->next = nullptr;
		delete temp;
	}
	delete list->head;
	delete list;
}

void main()
{
	int numberOfWarriors = 0;
	cout << "Enter the number of warriors: ";
	cin >> numberOfWarriors;
	while (numberOfWarriors <= 0)
	{
		cout << "You entered not posituve number!" << endl << "Enter the number of warriors again: ";
		cin >> numberOfWarriors;
	}

	List *list = new List();
	list->head = nullptr;
	createList(list, numberOfWarriors);
	int killed = 0;
	cout << "Every m warrior will be killed. Enter m: ";
	cin >> killed;
	while (killed <= 1)
	{
		cout << "You entered wrong number!" << endl << "Enter the number bigger than 1: ";
		cin >> killed;
	}

	ListElement *temp = list->head;
	while (list->head != list->head->next)
	{
		for (int i = 0; i < killed - 2; ++i)
		{
			temp = temp->next;
		}
		deleteListElement(list, temp);
		temp = temp->next;
	}
	cout << "Position of alive warrior: " << list->head->number << endl;
	deleteList(list);
}

/*
Тест 1:
Number of warriors: 41
Killed: 3
Alive: 31

Тест 2:
Number of warriors: 10
Killed: 2
Alive: 5

Тест 3:
Number of warriors: 10
Killed: 11
Alive: 7

*/