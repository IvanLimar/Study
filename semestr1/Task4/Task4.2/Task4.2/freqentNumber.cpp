#include "frequentNumber.h"
#include <iostream>

using namespace std;

void frequentNumber(int* array, int leftBorder, int rightBorder)
{
	int frequent = array[leftBorder];
	int numberOfFrequentMeeting = 1;
	int quantity = 1;
	int maxQuantity = 1;
	for (int i = leftBorder; i <= rightBorder; ++i)
	{
		if (i == rightBorder)
		{
			if (quantity == maxQuantity)
			{
				++numberOfFrequentMeeting;
				quantity = 1;
			}
			if (quantity > maxQuantity)
			{
				frequent = array[i];
				numberOfFrequentMeeting = 1;
				maxQuantity = quantity;
				quantity = 1;
			}
		}
		else
		{
			if (array[i] == array[i + 1])
			{
				++quantity;
			}
			else
			{
				if (quantity == maxQuantity)
				{
					++numberOfFrequentMeeting;
					quantity = 1;
				}
				if (quantity > maxQuantity)
				{
					frequent = array[i];
					numberOfFrequentMeeting = 1;
					maxQuantity = quantity;
					quantity = 1;
				}
			}
		}
	}

	if (numberOfFrequentMeeting > 1)
	{
		cout << "nothing" << endl;
		return;
	}

	cout << "Frequent number: " << frequent << endl;
}