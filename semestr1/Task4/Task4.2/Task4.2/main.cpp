#include <fstream>
#include "quickSort.h"
#include "frequentNumber.h"

using namespace std;

int main()
{
	//Первое число в файле - размер массива.
	ifstream file("test.txt", ios::in);
	int size = 0;
	file >> size;

	int *numbers = new int[size] {0};
	for (int i = 0; i < size; ++i)
	{
		file >> numbers[i];
	}
	file.close();

	quickSort(numbers, 0, size - 1);

	frequentNumber(numbers, 0, size - 1);

	delete[] numbers;
	return 0;
}