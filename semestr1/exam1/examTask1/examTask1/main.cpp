#include "list.h"

void main()
{
	List *list = createList();
	reading(list);
	mergeSort(list);
	writing(list);
	deleteList(list);
}

/*
Ввод: 0
Вывод: 0 - 1;

Ввод: 10 9 8 7 6 5 4 3 2 1 0
Вывод: 0 - 1
	   1 - 1
	   2 - 1
	   3 - 1
	   4 - 1
	   5 - 1
	   6 - 1 
	   7 - 1
	   8 - 1
	   9 - 1
	   10 - 1

Ввод: -1 -6 -1 0
Вывод: -6 - 1
	   -1 - 2
	    0 - 1
*/