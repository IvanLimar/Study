#pragma once
#include <string>

struct HashTable;

//��������� �������� � ���-�������
void addToHashTable(HashTable *hashTable, int number, std::string const &line);

//������� ���-������� ������� size
HashTable *createHashTable(int size);

//���������, ���� �� ������� ���-�������
bool isElementEmpty(HashTable *hashTable, int position);

//����� ���������� �� �������
void print(HashTable *hashTable);

//�������� �������
void deleteTable(HashTable *hashTable);