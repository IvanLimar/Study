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

// Функция, не нарушая сортированности, добавляет в список list элемент number
void addToList(List *list, int number)
{
	if (list->head == nullptr)
	{
		ListElement *newListElement = new ListElement();
		list->head = newListElement;
		newListElement->next = nullptr;
		newListElement->number = number;
		cout << number << " was added" << endl << endl;
		return;
	}
	
	ListElement *newListElement = new ListElement();
	newListElement->number = number;
	newListElement->next = list->head;
	if (number <= list->head->number)
	{
		list->head = newListElement;
		cout << number << " was added" << endl << endl;
		return;
	}

	newListElement->next = list->head->next;
	if (newListElement->next == nullptr)
	{
		list->head->next = newListElement;
		cout << number << " was added" << endl << endl;
		return;
	}
	List *temp = new List();
	temp->head = list->head;
	while (newListElement->next != nullptr && number > newListElement->next->number)
	{
		temp->head = newListElement->next;
		newListElement->next = newListElement->next->next;
	}
	
	temp->head->next = newListElement;
	cout << number << " was added" << endl << endl;
	temp->head = nullptr;
	delete temp;
	return;
}

//Функция удаляет в list все элеметы number
void deleteNumbers(List *list, int number)
{
	if (list->head == nullptr)
	{
		cout << "List is empty." << endl << endl;
		return;
	}
	
	if (number == list->head->number)
	{
		while (list->head != nullptr && number == list->head->number)
		{
			List *temp = new List();
			temp->head = list->head;
			list->head = list->head->next;
			temp->head->next = nullptr;
			delete temp->head;
			temp->head = nullptr;
			delete temp;
		}
		cout << "All " << number << " were deleted." << endl << endl;
		return;
	}
		
	List *previousElement = new List();
	previousElement->head = list->head;
	List *currentElement = new List();
	currentElement->head = list->head->next;
	if (currentElement->head == nullptr)
	{
		cout << number << " is not in list." << endl << endl;
		return;
	}

	bool isNumberInList = false;
	while (currentElement->head != nullptr)
	{
		if (currentElement->head->number == number)
		{
			previousElement->head->next = currentElement->head->next;
			currentElement->head->next = nullptr;
			delete currentElement->head;
			currentElement->head = previousElement->head->next;
			isNumberInList = true;
		}
		else
		{
			previousElement->head = currentElement->head;
			currentElement->head = currentElement->head->next;
		}
	}
	if (isNumberInList)
	{
		cout << "All " << number << " were deleted." << endl << endl;
	}
	else
	{
		cout << number << " is not in list." << endl << endl;
	}
	previousElement->head = nullptr;
	currentElement->head = nullptr;
	delete currentElement;
	delete previousElement;
}

//Вывод списка list
void printList(List *list)
{
	if (list->head == nullptr)
	{
		cout << "List is empty." << endl << endl;
		return;
	}
	cout << "Printing list:" << endl;
	List *temp = new List();
	temp->head = list->head;
	while (temp->head != nullptr)
	{
		cout << temp->head->number << endl;
		temp->head = temp->head->next;
	}
	delete temp;
	
}

// Удаление списка List
void deleteList(List *list)
{
	List *temp = new List();
	temp->head = list->head;
	while (temp->head != nullptr)
	{
		list->head = list->head->next;
		temp->head = nullptr;
		delete temp->head;
		temp->head = list->head;
	}
	temp->head = nullptr;
	delete temp;
	list->head = nullptr;
	delete list;
	return;
}

// Вывод инструкции
void instruction()
{
	cout << "Press 0 and enter to exit." << endl;
	cout << "Press 1 and enter to add a number to the list." << endl << "Press 2 and enter to delete numbers from list" << endl;
	cout << "Press 3 and enter to print the list." << endl << endl;
	return;
}

void main()
{
	List *list = new List();
	list->head = nullptr;
	char key = '5';
	while (key != '0')
	{
		instruction();
		cin >> key;
		if (key != '0' && key != '1' && key != '2' && key != '3')
		{
			cout << "Your command is wrong!" << endl;
		}
		else
		{
			if (key == '1')
			{
				cout << "Enter the number: ";
				int number = 0;
				cin >> number;
				addToList(list, number);
			}

			if (key == '2')
			{
				cout << "Enter the number: ";
				int number = 0;
				cin >> number;
				deleteNumbers(list, number);
			}
			if (key == '3')
			{
				printList(list);
			}
		}
	}
	deleteList(list);
	return;
}