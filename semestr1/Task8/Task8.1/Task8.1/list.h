#pragma once

struct List;
struct ListElement;

// Merge Sort �� List
void listMergeSort(List *list);

// ������� List
List *createList();

//��������� element � list.
void addToList(List *list, int element);

//�������� List�
void deleteList(List *list);

//����� lista �� �������
void writingList(List *list);