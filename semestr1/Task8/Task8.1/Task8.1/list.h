#pragma once

struct List;
struct ListElement;

// Merge Sort на List
void listMergeSort(List *list);

// Создает List
List *createList();

//Добавляет element в list.
void addToList(List *list, int element);

//Удаление Listа
void deleteList(List *list);

//Вывод lista на консоль
void writingList(List *list);