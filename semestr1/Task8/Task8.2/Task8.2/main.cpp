#include "Tree.h" 
#include <iostream>

using namespace std;

void instructions()
{
	cout << "Press 0 to exit." << endl << "Press 1 to add element to tree." << endl;
	cout << "Press 2 to check element's belonging to tree." << endl << "Press 3 to delete element from tree." << endl;
	cout << "Press 4 to print tree in increasing order." << endl << "Press 5 to print tree in decreasing order." << endl;
}

void main()
{
	Tree *tree = plantTree();
	while (true)
	{
		string key;
		instructions();
		cin >> key;

		if (key == "0")
		{
			break;
		}

		if (key == "1")
		{
			cout << "Enter the element" << endl;
			Type element;
			cin >> element;
			addToTree(tree, element);
		}

		if (key == "2")
		{
			cout << "Enter the element" << endl;
			Type element;
			cin >> element;
			if (isInTree(tree, element))
			{
				cout << element << " is in tree." << endl;
			}
			else
			{
				cout << element << " isn't in tree." << endl;
			}
		}

		if (key == "3")
		{
			cout << "Enter the element" << endl;
			Type element;
			cin >> element;
			deleteElement(tree, element);
		}

		if (key == "4")
		{
			cout << "Printing in increasing order:" << endl;
			printUp(tree);
		}
		if (key == "5")
		{
			cout << "Printing in decreasing order:" << endl;
			printDown(tree);
		}
	}
	deleteTree(tree);
}