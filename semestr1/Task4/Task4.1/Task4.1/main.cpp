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
	cout << "������� �����: ";
	cin >> number1;
	bool number1Binary[32] = {false};
	convertToBinary(number1, number1Binary);
	cout << "����� � �������� ������������� (������ ���):" << endl;
	printingBinary(number1Binary);

	cout << "������� �����: ";
	int number2 = 0;
	cin >> number2;
	
	bool number2Binary[32] = {false};
	convertToBinary(number2, number2Binary);
	cout << "����� � �������� ������������� (������ ���):" << endl;
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
	
	cout << "����� ���� ����� � �������� �������������:" << endl;
	printingBinary(sum);

	cout << "����� ���� ����� � ���������� �������������:" << endl;
	int const sumDec = convertToDecimal(sum);
	cout << sumDec << endl;
}

/*
�����:

���� 1: 
����� 1: 45645
�������� �������������: 00000000000000001011001001001101
����� 2: -45645
�������� �������������: 10000000000000001011001001001101
�������� ������������� �����: 00000000000000000000000000000000
���������� ������������� �����: 0

���� 2:
����� 1: 16
�������� �������������: 00000000000000000000000000010000
����� 2: -1
�������� �������������: 10000000000000000000000000000001
�������� ������������� �����: 00000000000000000000000000001111
���������� ������������� �����: 15

���� 3:
����� 1: 25
�������� �������������: 00000000000000000000000000011001
����� 2: 14
�������� �������������: 00000000000000000000000000001110
�������� ������������� �����: 00000000000000000000000000100111
���������� ������������� �����: 39


���� 4:
����� 1: -2
�������� �������������: 10000000000000000000000000000010
����� 2: -3
�������� �������������: 10000000000000000000000000000011
�������� ������������� �����:100000000000000000000000000000101
���������� ������������� �����: -5
*/