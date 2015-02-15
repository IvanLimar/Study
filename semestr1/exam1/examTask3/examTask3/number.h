#pragma once

//В массиве находим максимальную сумму цифр
int maxSumNumbers(int *numbers, int *amountOfNumbers, int length);

//Выводим числа, у которых сумма цифр наибольшая
void print(int *numbers, int *ammountOfNumbers, int length, int maxSum);

//Считаем сумму цифр в числе
int sumOfNumbers(int number);