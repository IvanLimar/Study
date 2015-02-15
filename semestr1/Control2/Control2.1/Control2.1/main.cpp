#include <iostream>
#include <fstream>
#include "queue.h"

using namespace std;

void main()
{
	cout << "Enter numbers a and b: " << endl;
	int leftNumber = 0;
	cin >> leftNumber;
	int rightNumber = 0;
	cin >> rightNumber;
	if (leftNumber > rightNumber)
	{
		swap(leftNumber, rightNumber);
	}
	fstream file("Text.txt");
	if (!file.is_open())
	{
		cout << "File isn't found" << endl;
		return;
	}
	Queue *leftQueue = createQueue();
	Queue *middleQueue = createQueue();
	Queue *rightQueue = createQueue();
	while (!file.eof())
	{
		int number = 0;
		file >> number;
		if (number < leftNumber)
		{
			enQueue(leftQueue, number);
			continue;
		}
		if (number > rightNumber)
		{
			enQueue(rightQueue, number);
			continue;
		}
		enQueue(middleQueue, number);
	}
	file.close();
	fstream output("output.txt");
	output.clear();
	while (leftQueue->head != nullptr)
	{
		int number = 0;
		number = deQueue(leftQueue);
		output << number;
		output << " ";
	}
	moveQueue(leftQueue);
	while (middleQueue->head != nullptr)
	{
		int number = 0;
		number = deQueue(middleQueue);
		output << number;
		output << " ";
	}
	moveQueue(middleQueue);
	while (rightQueue->head != nullptr)
	{
		int number = 0;
		number = deQueue(rightQueue);
		output << number;
		output << " ";
	}
	moveQueue(rightQueue);
	output.close();
}
/*
Тест:
a, b: 0 10
input: -5 0 4 1 5 8 -3 0 4 2 3 13 0 14 0 15
output: -5 -3 0 4 1 5 8 0 4 2 3 0 0 13 14 15 

Тест:
a, b: 0 0
input: -5 0 4 1 5 8 -3 0 4 2 3 13 0 14 0 15
output: -5 -3 0 0 0 0 4 1 5 8 4 2 3 13 14 15

*/