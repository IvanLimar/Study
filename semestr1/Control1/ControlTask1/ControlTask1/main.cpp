#include <iostream>
#include "binaryNumber.h"

using namespace std;

//������� ������� ������ ������ length
bool *create(int length)
{
	bool *result = new bool[length];
	for (int i = 0; i < length; ++i)
	{
		result[i] = false;
	}
	return result;
}

int main()
{
	cout << "Enter the first number (positive):";
	int number1 = 0;
	cin >> number1;
	int const size = 32;
	bool *binaryNumber1 = create(size);
	convertToBinary(number1, binaryNumber1, size);

	cout << "Enter the second number (positive):";
	int number2 = 0;
	cin >> number2;
	bool *binaryNumber2 = create(size);
	convertToBinary(number2, binaryNumber2, size);

	int const result = compare(binaryNumber1, binaryNumber2, size);
	if (result == 1)
	{
		cout << number1 << " > " << number2 << endl;
	}
	else
	{
		if (result == -1)
		cout << number1 << " < " << number2 << endl;
		else
		{
			cout << number1 << " = " << number2 << endl;
		}
	}
	delete[] binaryNumber1;
	delete[] binaryNumber2;
	return 0;
}
/*
���� 1:
����:
�����1: 0
00000000 00000000 00000000 00000000
�����2: 0
00000000 00000000 00000000 00000000
�����: 0 = 0

���� 2:
����:
�����1: 10
00000000 00000000 00000000 00001010
�����2: 5
00000000 00000000 00000000 00000101
�����: 10 > 5

���� 3:
����:
�����1: 5
00000000 00000000 00000000 00000101
�����2: 10
00000000 00000000 00000000 00001010
�����: 5 < 10
*/