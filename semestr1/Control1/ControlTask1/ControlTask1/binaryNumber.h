#pragma once

// ��������� ����� int � �������� ������������� (������ ��� - ������� ������ �� 32 ���������, ��� true - 1; false - 0;
void convertToBinary(int number, bool* array, int size);

// ���������� 2 ��������������� ����� � �������� ������, ���������� 1, ���� ����� 1 > ����� 2, 0 - ����� 1 = ����� 2, -1 ����� 1 < ����� 2
int compare(bool* array1, bool* array2, int size);

// ����� ��������� �����
void printingBinary(bool* binary, int size);