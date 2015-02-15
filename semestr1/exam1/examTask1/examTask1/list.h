#pragma once

struct List;

//������� PhoneBook
List *createList();

//������� PhoneBook
void deleteList(List *list);

//���������� � list �����
void add(List *list, int number);

//����� ��������� ������ � ������� ������ (������ ������ ���� ���������������)
void writing(List *list);

// MergeSort list
void mergeSort(List *list);

//��������� � list ��������, ���� �� ���������� 0.
void reading(List *list);