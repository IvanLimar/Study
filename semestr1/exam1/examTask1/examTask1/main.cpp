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
����: 0
�����: 0 - 1;

����: 10 9 8 7 6 5 4 3 2 1 0
�����: 0 - 1
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

����: -1 -6 -1 0
�����: -6 - 1
	   -1 - 2
	    0 - 1
*/