#include <string>
#include <iostream>
#include "stack.h"
#include <fstream>

using namespace std;

//Переводит символ number в число, если перевод невозможен, возвращает -1
int charToInt(char number)
{
	if (number >= '0' && number <= '9')
	{
		return number - '0';
	}
	return -1;
}

//Выполняет одну операцию, где operation - знак операции. Если возникает ситуация деления на ноль, то возвращает -999999
int counting(Stack *stack, char operation)
{
	char operandSecond = pop(stack);
	int secondOperand = 0;
	if (charToInt(operandSecond) == -1)
	{
		secondOperand = counting(stack, operandSecond);
	}
	else
	{
		secondOperand = charToInt(operandSecond);
	}
	char operandFirst = pop(stack);
	int firstOperand = 0;
	if (charToInt(operandFirst) == -1)
	{
		firstOperand = counting(stack, operandFirst);
	}
	else
	{
		firstOperand = charToInt(operandFirst);
	}
	if (operation == '/')
	{
		if (secondOperand == 0)
		{
			return -999999;
		}
		return (firstOperand / secondOperand);
	}
	if (operation == '*')
	{
		return (firstOperand * secondOperand);
	}
	if (operation == '+')
	{
		return (firstOperand + secondOperand);
	}
	if (operation == '-')
	{
		return (firstOperand - secondOperand);
	}
}

//Вывод выражения
void writing(string expression)
{
	for (int i = 0; i < expression.length(); ++i)
	{
		cout << expression[i] << " ";
	}
}

void main()
{
	string expression;
	ifstream file("text.txt", ios::in);
	if (!file.is_open())
	{
		cout << "File not found!" << endl;
		return;
	}
	while (!file.eof())
	{
		string buffer;
		file >> buffer;
		expression = expression + buffer;
	}
	file.close();

	Stack *stack = createStack();
	for (int i = 0; i < expression.length(); ++i)
	{
		push(stack, expression[i]);
	}
	int result = 0;

	char operation = pop(stack);
	if (charToInt(operation) >= 0)
	{
		writing(expression);
		cout << " - wrong expression!" << endl;
		deleteStack(stack);
		return;
	}
	result = counting(stack, operation);
	deleteStack(stack);
	writing(expression);
	cout << " = " << result << endl;
}
/*
Тесты:
9 6 - 1 2 + * = 9
1 1 + 2 - 5 / = -999999
1 + 1 - wrong expression!
1 1 + 2 * = 4
*/