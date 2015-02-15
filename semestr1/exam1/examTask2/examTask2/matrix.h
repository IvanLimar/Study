#pragma once

//Создаем двумерный массив (пользователь сам вводит значения)
int **createMatrix(int hight, int length);

//Удаление двумерного массива
void deleteMatrix(int **matrix, int hight);

//Печатаем седловые точки, если они есть.
void printSeddlePoints(int **matrix, int hight, int length);

//Ввод размерности(длина или высота)
int size();