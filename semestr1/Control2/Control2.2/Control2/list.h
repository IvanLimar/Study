#pragma once
#include <string>

struct List;
struct ListElement;

// ������� ������
List *createList();

// ������� ������
void deleteList(List *list);

// ��������� ������� � ������, �������� ���������������
void addToList(List *list, std::string const &element);

//�������� �������� ����� listElement
void deleteElement(List *list, ListElement *listElement);

// � List ����� ������� ��� �������������� ������.
void deleteRepetetiveElements(List *list);

//����� ������ list
void printList(List *list);