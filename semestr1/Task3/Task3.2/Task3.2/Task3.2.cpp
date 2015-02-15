#include <iostream>

using namespace std;

// Сортировка вставкой
void insertionSort(int* array, int leftBorder, int rightBorder)
{
	for (int i = leftBorder; i <= rightBorder; ++i)
	{
		for (int j = i; j > leftBorder; --j)
		{
			if (array[j] < array[j - 1])
			{
				swap(array[j], array[j - 1]);
			}
		}
	}
}

/* Поиск в массиве "array" с границами "leftBorder" и "rightBorder" числа,
большего первого, и перестановка этого числа с первым */
void searhTheNumberBiggerThanFirst(int* array, int leftBorder, int rightBorder)
{
	for (int i = leftBorder + 1; i <= rightBorder; ++i)
	{
		if (array[i] > array[leftBorder])
		{
			swap(array[i], array[leftBorder]);
			break;
		}
	}
}

/* Элементы, не превосходящие первого, будут слева от него. Справа - превосходящие.
Функция вернет новый индекс этого числа */
int movement(int* array, int leftBorder, int rightBorder)
{
	int firstNumberIndex = leftBorder;
	int rightIndex = rightBorder;
	int leftIndex = leftBorder;
	bool const areIndexesLegal = (leftIndex <= rightBorder) && (rightIndex >= leftBorder);

	while (leftIndex <= rightIndex && areIndexesLegal)
	{
		while (array[firstNumberIndex] < array[rightIndex] && areIndexesLegal)
		{
			--rightIndex;
		}
		if (areIndexesLegal && leftIndex <= rightIndex)
		{
			swap(array[firstNumberIndex], array[rightIndex]);
			firstNumberIndex = rightIndex;
		}

		while (areIndexesLegal && array[firstNumberIndex] >= array[leftIndex])
		{
			++leftIndex;
		}
		if (areIndexesLegal && leftIndex <= rightIndex)
		{
			swap(array[firstNumberIndex], array[leftIndex]);
			firstNumberIndex = leftIndex;
		}

	}
	return firstNumberIndex;
}

// Функция возвращает true, если массив с данными границами отсортирован, в противном сучае - false.
bool isArraySorted(int* array, int leftBorder, int rightBorder)
{
	bool result = true;
	for (int i = leftBorder; i < rightBorder; ++i)
	{
		if (array[i] <= array[i + 1])
		{
			result = true;
		}
		else
		{
			result = false;
			break;
		}
	}
	return result;
}

// Быстрая сортировка
void quickSort(int* array, int leftBorder, int rightBorder)
{
	if (isArraySorted(array, leftBorder, rightBorder))
	{
		return;
	}
	if (rightBorder - leftBorder + 1 <= 10)
	{
		insertionSort(array, leftBorder, rightBorder);
	}
	else
	{
		searhTheNumberBiggerThanFirst(array, leftBorder, rightBorder);
		int border = movement(array, leftBorder, rightBorder);
		quickSort(array, leftBorder, border - 1);
		quickSort(array, border, rightBorder);
	}
}

// Функция возвращает true, если число number есть в массиве array с границами leftBorder и rightBorder
bool isNumberInArray(int* array, int leftBorder, int rightBorder, int number)
{
	bool result = false;
	for (int i = leftBorder; i <= rightBorder; ++i)
	{
		if (array[i] == number)
		{
			result = true;
			break;
		}
	}
	return result;
}

int main()
{
	cout << "Enter the number n (1<=n<=5000): ";
	int length = 0;
	cin >> length;
	cout << "Enter the number k (1<=n<=300000): ";
	int k = 0;
	cin >> k;
	
	int *numbers = new int[length];
	for (int i = 0; i < length; ++i)
	{
		cout << "Enter the number (>=0): ";
		cin >> numbers[i];
	}

	quickSort(numbers, 0, length - 1);

	for (int i = 0; i < k; ++i)
	{
		int number = 0;
		cout << "Enter the number (0<=x<=10^9): ";
		cin >> number;
		if (isNumberInArray(numbers, 0, length - 1, number))
		{
			cout << "The number " << number << " is in the array" << endl;
		}
		else
		{
			cout << "The number " << number << " is not in the array" << endl;
		}
	}

	delete[] numbers;

	return 0;
}