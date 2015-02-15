#pragma once
/*
���� ������ �� ����������, �� "������������" typedef int List � ��� � array.cpp
���� ������ �� �������, �� "������������" struct List � ��� � pointer.cpp
*/

//struct List;

typedef int List;


//������� ������
List *createList(int length);

//������� ������
void deleteList(List *list);

//���������� � ������
void addToList(List *list, int &length, int element, int position);

//���������� ������� ������ �� �������
int element(List *list, int length, int position);



//����� ������ �� �������
void printList(List *list, int length);