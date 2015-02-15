#pragma once
/*
Если список на указателях, то "комментируем" typedef int List и все в array.cpp
Если список на массиве, то "комментируем" struct List и все в pointer.cpp
*/

//struct List;

typedef int List;


//Создаем список
List *createList(int length);

//Удаляем список
void deleteList(List *list);

//Добавление в список
void addToList(List *list, int &length, int element, int position);

//Возвращает элемент списка по позиции
int element(List *list, int length, int position);



//Вывод списка на консоль
void printList(List *list, int length);