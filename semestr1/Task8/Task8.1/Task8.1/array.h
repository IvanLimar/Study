#pragma once

// ��������� element � ourArray �� ������� index 
void addToArray(int *ourArray, int index, int element);

int *createArray(int length);

// �������� ourArray
void deleteArray(int *ourArray);

// Merge Sort �� ourArray ����� length
void arrayMergeSort(int *ourArray, int length);

// ����� ������� ourArray ����� length �� �������
void writingArray(int *ourArray, int length);