#include "ATD.h"

//Если в ATD.h Type - int, то надо комментировать 2 строчку каждой функции, Type -List, то комментируем 1 строчку. 

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