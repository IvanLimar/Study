#include <iostream>
#include "tree.h"

using namespace std;

struct TreeElement
{
	string value;
	TreeElement *left;
	TreeElement *right;
};

struct Tree
{
	TreeElement *root;
};

Tree *plantTree()
{
	Tree *tree = new Tree;
	tree->root = nullptr;
	return tree;
}

//Вспомогательная функция к deleteTree
void deleteTreeElement(TreeElement *treeElement)
{
	if (treeElement->right != nullptr)
	{
		deleteTreeElement(treeElement->right);
	}
	if (treeElement->left != nullptr)
	{
		deleteTreeElement(treeElement->left);
	}
	delete treeElement;
}

void deleteTree(Tree *tree)
{
	if (tree->root != nullptr)
	{
		deleteTreeElement(tree->root);
	}
	delete tree;
}

// Конвертует строку в число
int toInt(string const &number)
{
	int result = 0;
	int ten = 1;
	for (int i = number.length() - 1; i >= 0; --i)
	{
		int const component = int(number[i]) - int('0');
		result = result + component * ten;
		ten = ten * 10;
	}
	return result;
}

//Вспомогательная функция к readExpression.
void reading(TreeElement *treeElement, string const &expression, unsigned int &position)
{
	for (unsigned int i = position; i < expression.size(); ++i)
	{
		if (expression[i] == ' ' || expression[i] == ')' || expression[i] == '(')
		{
			continue;
		}
		bool const isOperation = expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/';
		if (isOperation)
		{
			treeElement->value = expression[i];
			++i;

			for (int j = 0; j < 2; ++j)
			{
				while (expression[i] == ' ' || expression[i] == ')' || expression[i] == '(')
				{
					++i;
				}
				TreeElement *operand = new TreeElement();
				operand->left = nullptr;
				operand->right = nullptr;
				if (j == 0)
				{
					treeElement->left = operand;
				}
				else
				{
					treeElement->right = operand;
				}
				reading(operand, expression, i);
			}
			position = i;
			return;
		}
		else
		{
			string operand;
			while (expression[i] != ' ' && expression[i] != ')' && expression[i] != '(')
			{
				operand = operand + expression[i];
				++i;
			}
			treeElement->value = operand;
			position = i;
			return;
		}
	}
}

void readExpression(Tree *tree, string const &expression)
{
	if (tree->root == nullptr)
	{
		TreeElement *newElement = new TreeElement;
		newElement->left = nullptr;
		newElement->right = nullptr;
		tree->root = newElement;
	}
	unsigned int startPosition = 0;
	reading(tree->root, expression, startPosition);
}

//Вспомогательная функция к printExpression
void print(TreeElement *treeElement)
{
	bool const isOperation = treeElement->value == "+" || treeElement->value == "-" || treeElement->value == "*" || treeElement->value == "/";

	if (isOperation)
	{
		cout << "( " << treeElement->value << " ";
		print(treeElement->left);
		print(treeElement->right);
		cout << " ) ";
	}
	else
	{
		cout << treeElement->value << " ";
	}
}

void printExpression(Tree *tree)
{
	if (tree->root == nullptr)
	{
		cout << "Tree is empty!" << endl;
	}
	print(tree->root);
}

//Вспомогательная функция к countExpression
int counting(TreeElement *treeElement)
{
	bool const isOperation = treeElement->value == "+" || treeElement->value == "-" || treeElement->value == "*" || treeElement->value == "/";

	if (!isOperation)
	{
		return toInt(treeElement->value);
	}

	int firstOperand = counting(treeElement->left);
	int secondOperand = counting(treeElement->right);

	if (treeElement->value == "+")
	{
		return firstOperand + secondOperand;
	}

	if (treeElement->value == "-")
	{
		return firstOperand - secondOperand;
	}

	if (treeElement->value == "*")
	{
		return firstOperand * secondOperand;
	}

	if (treeElement->value == "/")
	{
		return firstOperand / secondOperand;
	}
}

int countExpression(Tree *tree)
{
	if (tree->root == nullptr)
	{
		cout << "Tree is empty!" << endl;
	}
	return counting(tree->root);
}