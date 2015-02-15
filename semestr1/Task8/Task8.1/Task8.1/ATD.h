#pragma once
#include "array.h"
#include "list.h"

// ��� List � int ����� ������. ����� ����� �� ������ ������ ��������� � ATD.cpp.
typedef int Type;

// ���������� elementa � list �� ������� position
void add(Type *list, int position, int element);

// ������� type ������ length
Type *create(int length);

// ������� list
void deleting(Type *list);

// ����� lista ����� length
void writing(Type *list, int length);

// Merge Sort lista.
void megreSort(Type *list, int length);