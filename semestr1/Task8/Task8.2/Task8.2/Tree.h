#pragma once
#include <string>

typedef std::string Type;

struct Tree;

// Создаем Tree
Tree *plantTree();

// Добавляем в Tree element
void addToTree(Tree *tree, Type element);

// Проверяет, есть ли в Tree element
bool isInTree(Tree *tree, Type element);

// Печать дерева в убывающем порядка
void printUp(Tree *tree);

// Печать дерева в возрастающем порядке
void printDown(Tree *tree);

// Удаляем tree
void deleteTree(Tree *tree);

// Удаляем element из tree
void deleteElement(Tree *tree, Type element);