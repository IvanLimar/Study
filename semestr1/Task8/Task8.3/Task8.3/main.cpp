#include <iostream>
#include <fstream>
#include "tree.h"

using namespace std;

void main()
{
	fstream file("Text.txt");
	string expression;
	while (!file.eof())
	{
		string symbol;
		file >> symbol;
		expression = expression + symbol + " ";
	}
	file.close();
	Tree *tree = plantTree();
	readExpression(tree, expression);
	printExpression(tree);
	cout << " = " << countExpression(tree) << endl;
	deleteTree(tree);
}

/*Тесты:
First: ( * ( + 7  18 ) (* 12 ( + 10  178 ) ) ) = 56400
Second: ( * ( + 1 1 ) 2 ) = 4
Third: (* (+ 1 1 ) (- 1 1 ) ) = 0;
*/