#pragma once

struct List;

//Создаем PhoneBook
List *createList();

//Удаляем PhoneBook
void deleteList(List *list);

//Добавление в list числа
void add(List *list, int number);

//Вывод элементов списка и частоты встреч (список должен быть отсортированным)
void writing(List *list);

// MergeSort list
void mergeSort(List *list);

//Добавляем в list элементы, пока не встретится 0.
void reading(List *list);