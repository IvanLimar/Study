#include <string>
#include <iostream>
#include "stack.h"

using namespace std;

//Проверяем, корректна ли скобочная последовательность.
bool isCorrect(Stack *stack, string const &line)
{
	for (unsigned int i = 0; i < line.size(); ++i)
	{
		if (line[i] == '(' || line[i] == '{' || line[i] == '[')
		{
			push(stack, line[i]);
			continue;
		}
		char const closedBracket = line[i];
		char openBracket = ' ';
		switch (line[i])
		{
		case '}':
		{
					openBracket = '{';
					break;
		}
		case ']':
		{
					openBracket = '[';
					break;
		}
		case ')':
		{
					openBracket = '(';
					break;
		}
		default:
			break;
		}
		if (head(stack) == openBracket)
		{
			pop(stack);
		}
		else
		{
			return false;
		}
	}
	return isStackEmpty(stack);
}

void main()
{
	cout << "Enter a line without gaps" << endl;
	string line;
	cin >> line;
	Stack *stack = createStack();
	if (isCorrect(stack, line))
	{
		cout << "Line is correct" << endl;
	}
	else
	{
		cout << "Line is not correct" << endl;
	}
	deleteStack(stack);
}
/*Тесты:
()[]{}()[]{} - Line is correct.
[{()}] -  Line is correct.
[(]) - Line is not correct.
[]{()}[](){[]}[] - Line is correct.
*/