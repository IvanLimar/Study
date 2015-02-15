#pragma once
#include <string>

struct Tree;

//������ ������.
Tree *plantTree();

//�������� ������
void deleteTree(Tree *tree);

//������ �������� � ������ ������� ��������������� ���������
void readExpression(Tree *tree, std::string const &expression);

// �������� ������
void printExpression(Tree *tree);

//������� ��������� � ������ ������� ��������������� ���������
int countExpression(Tree *tree);