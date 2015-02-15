#include "ATD.h"

//���� � ATD.h Type - int, �� ���� �������������� 2 ������� ������ �������, Type -List, �� ������������ 1 �������. 

Type *create(int length)
{	
	return createArray(length);
	//return createList();
}

void add(Type *list, int position, int element)
{
	addToArray(list, position, element);
	//addToList(list, element);
}

void deleting(Type *list)
{
	deleteArray(list);
	//deleteList(list);
}

void writing(Type *list, int length)
{
	writingArray(list, length);
	//writingList(list);
}

void megreSort(Type *list, int length)
{
	arrayMergeSort(list, length);
	//listMergeSort(list);
}