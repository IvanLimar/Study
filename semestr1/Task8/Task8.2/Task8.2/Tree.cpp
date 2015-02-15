#include "Tree.h"
#include <iostream>

using namespace std;

struct TreeElement
{
	Type value;
	TreeElement *left;
	TreeElement *right;
};

struct Tree
{
	TreeElement *root;
};

Tree *plantTree()
{
	Tree *tree = new Tree();
	tree->root = nullptr;
	return tree;
}


// Вспомагательная функция к addToTree
void add(TreeElement *treeElement, Type element)
{

	if (element == treeElement->value)
	{
		cout << "Element " << element << " was added" << endl;
		return;
	}

	if (element > treeElement->value)
	{
		if (treeElement->right == nullptr)
		{
			TreeElement *newElement = new TreeElement();
			treeElement->right = newElement;
			newElement->right = nullptr;
			newElement->left = nullptr;
			newElement->value = element;
			return;
		}
		add(treeElement->right, element);
	}

	if (element < treeElement->value)
	{
		if (treeElement->left == nullptr)
		{
			TreeElement *newElement = new TreeElement();
			treeElement->left = newElement;
			newElement->right = nullptr;
			newElement->left = nullptr;
			newElement->value = element;
			return;
		}
		add(treeElement->left, element);
	}
}

void addToTree(Tree *tree, Type element)
{
	if (tree->root == nullptr)
	{
		TreeElement *newElement = new TreeElement();
		tree->root = newElement;
		newElement->value = element;
		newElement->right = nullptr;
		newElement->left = nullptr;
		cout << "Adding complete." << endl;
		return;
	}
	add(tree->root, element);
	cout << "Adding complete." << endl;
}

// Вспомагательная функция к isInTree
bool isElementHere(TreeElement *treeElement, Type element)
{
	if (treeElement->value == element)
	{
		return true;
	}

	if (element > treeElement->value)
	{
		if (treeElement->right == nullptr)
		{
			return false;
		}
		return isElementHere(treeElement->right, element);
	}

	if (element < treeElement->value)
	{

		if (treeElement->left == nullptr)
		{
			return false;
		}
		return isElementHere(treeElement->left, element);
	}
}

bool isInTree(Tree *tree, Type element)
{
	if (tree->root == nullptr)
	{
		return false;
	}

	return isElementHere(tree->root, element);
}

// Вспомагательная функция к printUp
void printElementUp(TreeElement *treeElement)
{
	if (treeElement->left != nullptr)
	{
		printElementUp(treeElement->left);
	}

	cout << treeElement->value << endl;

	if (treeElement->right != nullptr)
	{
		printElementUp(treeElement->right);
	}
}

void printUp(Tree *tree)
{
	if (tree->root == nullptr)
	{
		cout << "Tree is empty!" << endl;
		return;
	}

	printElementUp(tree->root);
	cout << endl;
}

// Вспомагательная функция к printDown
void printElementDown(TreeElement *treeElement)
{
	if (treeElement->right != nullptr)
	{
		printElementDown(treeElement->right);
	}

	cout << treeElement->value << endl;

	if (treeElement->left != nullptr)
	{
		printElementDown(treeElement->left);
	}
}

void printDown(Tree *tree)
{
	if (tree->root == nullptr)
	{
		cout << "Tree is empty!" << endl;
		return;
	}

	printElementDown(tree->root);
	cout << endl;
}

// Вспомагательная функция к deleteTree
void deletingTreeElement(TreeElement *treeElement)
{
	if (treeElement->left != nullptr)
	{
		deletingTreeElement(treeElement->left);
	}

	if (treeElement->right != nullptr)
	{
		deletingTreeElement(treeElement->right);
	}

	delete treeElement;
}

void deleteTree(Tree *tree)
{
	if (tree->root == nullptr)
	{
		delete tree;
		return;
	}

	deletingTreeElement(tree->root);

	delete tree;
}

// Возвращает самый левый элемент после treeElement
TreeElement *LeftElement(TreeElement *treeElement)
{
	if (treeElement->left != nullptr)
	{
		return LeftElement(treeElement->left);
	}
	return treeElement;
		
}

//// Вспомагательная функция к deleteElement
void deleteTreeElement(TreeElement *treeElement, Type element)
{
	if (treeElement->right != nullptr && element > treeElement->value && element != treeElement->right->value)
	{
		deleteTreeElement(treeElement->right, element);
		return;
	}

	if (treeElement->right != nullptr && element == treeElement->right->value)
	{
		if (treeElement->right->right == nullptr && treeElement->right->left == nullptr)
		{
			TreeElement *temp = treeElement->right;
			treeElement->right = nullptr;
			delete temp;
			return;
		}

		if (treeElement->right->left == nullptr)
		{
			TreeElement *temp = treeElement->right;
			treeElement->right = temp->right;
			temp->right = nullptr;
			delete temp;
			return;
		}

		if (treeElement->right->right == nullptr)
		{
			TreeElement *temp = treeElement->right;
			treeElement->right = temp->left;
			temp->left = nullptr;
			delete temp;
			return;
		}

		TreeElement *temp = treeElement->right;
		TreeElement *leftElement = LeftElement(treeElement->right->right);
		leftElement->left = treeElement->right->left;
		treeElement->right = treeElement->right->right;
		temp->right = nullptr;
		temp->left = nullptr;
		delete temp;
		return;
	}

	if (treeElement->left != nullptr && element < treeElement->value && element != treeElement->left->value)
	{
		deleteTreeElement(treeElement->left, element);
		return;
	}

	if (treeElement->left != nullptr && element == treeElement->left->value)
	{
		if (treeElement->left->right == nullptr && treeElement->left->left == nullptr)
		{
			TreeElement *temp = treeElement->left;
			treeElement->left = nullptr;
			delete temp;
			return;
		}

		if (treeElement->left->left == nullptr)
		{
			TreeElement *temp = treeElement->left;
			temp->left = 
			treeElement->left = temp->right;
			temp->right = nullptr;
			delete temp;
			return;
		}


		if (treeElement->left->right == nullptr)
		{
			TreeElement *temp = treeElement->left;
			treeElement->left = temp->left;
			temp->left = nullptr;
			delete temp;
			return;
		}

		TreeElement *temp = treeElement->left;
		TreeElement *leftElement = LeftElement(treeElement->left->right);
		leftElement->left = treeElement->left->left;
		treeElement->left = treeElement->right->right;
		temp->right = nullptr;
		temp->left = nullptr;
		delete temp;
		return;
	}

	if (treeElement->left == nullptr && treeElement->right == nullptr)
	{
		cout << "Element " << element << " isn't in tree." << endl;
	}
}

void deleteElement(Tree *tree, Type element)
{
	if (tree->root == nullptr)
	{
		cout << "Tree is empty!" << endl;
		return;
	}
	if (tree->root->value == element)
	{
		if (tree->root->right == nullptr && tree->root->left == nullptr)
		{
			delete tree->root;
			tree->root = nullptr;
			cout << "Deleting complete." << endl;
			return;
		}
		if (tree->root->right == nullptr)
		{
			TreeElement *temp = tree->root;
			tree->root = tree->root->left;
			temp->left = nullptr;
			delete temp;
			cout << "Deleting complete." << endl;
			return;
		}

		if (tree->root->left == nullptr)
		{
			TreeElement *temp = tree->root;
			tree->root = tree->root->right;
			temp->right = nullptr;
			delete temp;
			cout << "Deleting complete." << endl;
			return;
		}

		TreeElement *temp = LeftElement(tree->root->right);
		temp->left = tree->root->left;
		TreeElement *deleted = tree->root;
		tree->root = tree->root->right;
		deleted->left = nullptr;
		deleted->right = nullptr;
		delete deleted;
		cout << "Deleting complete." << endl;
		return;
	}
	deleteTreeElement(tree->root, element);
	cout << "Deleting complete." << endl;
}