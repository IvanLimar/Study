#include <iostream>
#include "stack.h";
#include <string>
#include <fstream>

using namespace std;

// Проверяет, является ли символ цифрой
bool isNumber(char number)
{
	if (number >= '0' && number <= '9')
	{
		return true;
	}
	return false;
}

//Вывод выражения
void writing(string expression)
{
	for (int i = 0; i < expression.length(); ++i)
	{
		cout << expression[i] << " ";
	}
}

//
string pushToPostfixExpression(char operand, Stack *stack, string postfixExpression)
{
	string result = postfixExpression;
	if (operand == '+' || operand == '-')
	{
		while (stack->head != nullptr && stack->head->element != '(')
		{
			result = result + pop(stack);
		}
		push(stack, operand);
		return result;
	}
	if (operand == '*' || operand == '/')
	{
		while (stack->head != nullptr && stack->head->element != '(' && stack->head->element != '+' && stack->head->element != '-')
		{
			result = result + pop(stack);
		}
		push(stack, operand);
		return result;
	}
}

void main()
{
	ifstream file("Text.txt", ios::in);
	string infixExpression;
	if (!file.is_open())
	{
		cout << "File not found!" << endl;
		return;
	}
	while (!file.eof())
	{
		string buffer;
		file >> buffer;
		infixExpression = infixExpression + buffer;
	}
	file.close();
	Stack *stack = new Stack();
	string postfixExpression;
	for (int i = 0; i < infixExpression.length(); ++i)
	{
		if (isNumber(infixExpression[i]))
		{
			postfixExpression = postfixExpression + infixExpression[i];
			continue;
		}
		if (infixExpression[i] == '+' || infixExpression[i] == '-' || infixExpression[i] == '*' || infixExpression[i] == '/')
		{
			postfixExpression = pushToPostfixExpression(infixExpression[i], stack, postfixExpression);
			continue;
		}
		if (infixExpression[i] == '(')
		{
			push(stack, infixExpression[i]);
			continue;
		}
		if (infixExpression[i] == ')')
		{
			while (stack->head != nullptr && stack->head->element != '(')
			{
				postfixExpression = postfixExpression + pop(stack);
			}
			if (stack->head == nullptr)
			{
				cout << "You entered wrong expreession!" << endl;
				deleteStack(stack);
				return;
			}
			const char bracket = pop(stack);
			continue;
		}
	}
	while (stack->head != nullptr)
	{
		if (stack->head->element == '(')
		{
			cout << "You entered wrong expreession!" << endl;
			deleteStack(stack);
			return;	
		}
		postfixExpression = postfixExpression + pop(stack);
	}
	deleteStack(stack);
	writing(infixExpression);
	cout << " = ";
	writing(postfixExpression);
	cout << endl;
}
/*
Tests:
(1+2)*(3+4)+(2+3)/(2+1) = 1 2 + 3 4 + * 2 3 + 2 1 + / +
1 + 2 = 1 2 +
1 + 1 * 2 = 1 1 2 * +
(1 + 1) * 2 = 1 1 + 2 *
(1 + 1 * 2 - you entered wrong expression!
(1 + 1 * 2 - - you entered wrong expression!
*/