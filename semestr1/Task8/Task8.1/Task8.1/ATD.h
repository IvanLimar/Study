#pragma once
#include "array.h"
#include "list.h"

// Тут List и int можно менять. После этого не забыть внести изменения в ATD.cpp.
typedef int Type;

// Добавление elementa в list на позицию position
void add(Type *list, int position, int element);

// Создает type длиной length
Type *create(int length);

// Удаляет list
void deleting(Type *list);

// Вывод lista длины length
void writing(Type *list, int length);

// Merge Sort lista.
void megreSort(Type *list, int length);