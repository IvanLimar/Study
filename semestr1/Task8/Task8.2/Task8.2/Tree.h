#pragma once
#include <string>

typedef std::string Type;

struct Tree;

// ������� Tree
Tree *plantTree();

// ��������� � Tree element
void addToTree(Tree *tree, Type element);

// ���������, ���� �� � Tree element
bool isInTree(Tree *tree, Type element);

// ������ ������ � ��������� �������
void printUp(Tree *tree);

// ������ ������ � ������������ �������
void printDown(Tree *tree);

// ������� tree
void deleteTree(Tree *tree);

// ������� element �� tree
void deleteElement(Tree *tree, Type element);