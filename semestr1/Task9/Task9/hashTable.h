#pragma once
#include <string>

struct HashTable;

//Добавляем значение в хеш-таблицу
void addToHashTable(HashTable *hashTable, int number, std::string const &line);

//Создаем хеш-таблицу размера size
HashTable *createHashTable(int size);

//Проверяет, пкст ли элемент хеш-таблицы
bool isElementEmpty(HashTable *hashTable, int position);

//Вывод результата на консоль
void print(HashTable *hashTable);

//Удаление таблицы
void deleteTable(HashTable *hashTable);