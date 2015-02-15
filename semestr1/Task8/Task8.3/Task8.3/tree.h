#pragma once
#include <string>

struct Tree;

//Создаём дерево.
Tree *plantTree();

//Удаление дерева
void deleteTree(Tree *tree);

//Строку помещаем в дерево разбора арифметического выражения
void readExpression(Tree *tree, std::string const &expression);

// Печатаем дерево
void printExpression(Tree *tree);

//Считаем выражение в дереве разбора арифметического выражения
int countExpression(Tree *tree);