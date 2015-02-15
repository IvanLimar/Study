#pragma once

// переводит число int в двоичное представление (прямой код - булевый массив из 32 элементов, где true - 1; false - 0;
void convertToBinary(int number, bool* array, int size);

// Сравнивает 2 неотрицательных числа в двоичной записи, возвращает 1, если число 1 > числа 2, 0 - число 1 = число 2, -1 число 1 < числа 2
int compare(bool* array1, bool* array2, int size);

// Вывод двоичного числа
void printingBinary(bool* binary, int size);