#include <iostream>
#include "converts.h"
#include "binarySum.h"

using namespace std;

void printingBinary(bool* binary)
{
	for (int i = 0; i < 32; ++i)
	{
		if (binary[i])
		{
			cout << "1";
		}
		else
		{
			cout << "0";
		}
	}
	cout << endl;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int number1 = 0;
	cout << "Введите число: ";
	cin >> number1;
	bool number1Binary[32] = {false};
	convertToBinary(number1, number1Binary);
	cout << "Число в двоичном представлении (прямой код):" << endl;
	printingBinary(number1Binary);

	cout << "Введите число: ";
	int number2 = 0;
	cin >> number2;
	
	bool number2Binary[32] = {false};
	convertToBinary(number2, number2Binary);
	cout << "Число в двоичном представлении (прямой код):" << endl;
	printingBinary(number2Binary);

	bool sum[32] = {false};
	if (abs(number1) >= abs(number2))
	{
		binarySum(number1Binary, number2Binary, sum);
	}
	else
	{
		binarySum(number2Binary, number1Binary, sum);
	}
	
	cout << "Сумма двух чисел в двоичном представлении:" << endl;
	printingBinary(sum);

	cout << "Сумма двух чисел в десятичном представлении:" << endl;
	int const sumDec = convertToDecimal(sum);
	cout << sumDec << endl;
}

/*
Тесты:

Тест 1: 
Число 1: 45645
Двоичное представление: 00000000000000001011001001001101
Число 2: -45645
Двоичное представление: 10000000000000001011001001001101
Двоичное представление суммы: 00000000000000000000000000000000
Десятичное представление суммы: 0

Тест 2:
Число 1: 16
Двоичное представление: 00000000000000000000000000010000
Число 2: -1
Двоичное представление: 10000000000000000000000000000001
Двоичное представление суммы: 00000000000000000000000000001111
Десятичное представление суммы: 15

Тест 3:
Число 1: 25
Двоичное представление: 00000000000000000000000000011001
Число 2: 14
Двоичное представление: 00000000000000000000000000001110
Двоичное представление суммы: 00000000000000000000000000100111
Десятичное представление суммы: 39


Тест 4:
Число 1: -2
Двоичное представление: 10000000000000000000000000000010
Число 2: -3
Двоичное представление: 10000000000000000000000000000011
Двоичное представление суммы:100000000000000000000000000000101
Десятичное представление суммы: -5
*/