#include "mergeSort.h"

bool isListSorted(List *list, int length)
{
	for (int i = 0; i < length - 1; ++i)
	{
		if (element(list, length, i) > element(list, length, i + 1))
		{
			return false;
		}
	}
	return true;
}

void dividing(List *list, int length, List *leftList, int leftLength, List *rightList, int rightLength)
{
	int leftIndex = 0;
	int rightIndex = 0;
	for (int i = 0; i < length; ++i)
	{
		if (i < leftLength)
		{
			addToList(leftList, leftLength, element(list, length, i), leftIndex);
			++leftIndex;
		}
		else
		{
			addToList(rightList, rightLength, element(list, length, i), rightIndex);
			++rightIndex;
		}
	}
}

void merging(List *list, int length, List *leftList, int leftLength, List *rightList, int rightLength)
{
	int leftIndex = 0;
	int rightIndex = 0;
	int index = 0;
	while (leftIndex < leftLength || rightIndex < rightLength)
	{
		if (leftIndex >= leftLength)
		{
			while (rightIndex < rightLength)
			{
				addToList(list, length, element(rightList, rightLength, rightIndex), index);
				++index;
				++rightIndex;
			}
			break;
		}
		if (rightIndex >= rightLength)
		{
			while (leftIndex < leftLength)
			{
				addToList(list, length, element(leftList, leftLength, leftIndex), index);
				++index;
				++leftIndex;
			}
			break;
		}
		if (element(leftList, leftLength, leftIndex) <= element(rightList, rightLength, rightIndex))
		{
			addToList(list, length, element(leftList, leftLength, leftIndex), index);
			++index;
			++leftIndex;
			continue;
		}
		else
		{
			addToList(list, length, element(rightList, rightLength, rightIndex), index);
			++index;
			++rightIndex;
			continue;
		}
	}
}

void mergeSort(List *list, int length)
{
	if (isListSorted(list, length))
	{
		return;
	}
	int const leftLength = length / 2;
	int rightLength = length - leftLength;
	List *leftList = createList(leftLength);
	List *rightList = createList(rightLength);

	dividing(list, length, leftList, leftLength, rightList, rightLength);
	
	if (isListSorted(leftList, leftLength) && isListSorted(rightList, rightLength))
	{
		merging(list, length, leftList, leftLength, rightList, rightLength);
	}
	else
	{
		if (!isListSorted(leftList, leftLength))
		{
			mergeSort(leftList, leftLength);
		}
		if (!isListSorted(rightList, rightLength))
		{
			mergeSort(rightList, rightLength);
		}
		merging(list, length, leftList, leftLength, rightList, rightLength);
	}
	deleteList(leftList);
	deleteList(rightList);
}