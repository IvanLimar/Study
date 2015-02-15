#pragma once

// Добавляет element в ourArray на позицию index 
void addToArray(int *ourArray, int index, int element);

int *createArray(int length);

// Удаление ourArray
void deleteArray(int *ourArray);

// Merge Sort на ourArray длины length
void arrayMergeSort(int *ourArray, int length);

// Вывод массива ourArray длины length на консоль
void writingArray(int *ourArray, int length);