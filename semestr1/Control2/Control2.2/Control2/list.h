#pragma once
#include <string>

struct List;
struct ListElement;

// Создаем список
List *createList();

// Удаляем список
void deleteList(List *list);

// Добавляем элемент в спмсок, сохраняя сортированность
void addToList(List *list, std::string const &element);

//Удаление элемента после listElement
void deleteElement(List *list, ListElement *listElement);

// В List будут удалены все повсторяющиеся строки.
void deleteRepetetiveElements(List *list);

//Вывод списка list
void printList(List *list);