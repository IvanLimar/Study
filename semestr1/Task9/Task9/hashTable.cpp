#include "hashTable.h"
#include <iostream>

struct HashElement
{
	std::string word;
	int quantity;
};

struct HashTable
{
	int size;
	HashElement *table;
};

int hashFunction(std::string const &line, int number)
{
	int result = 0;
	for (unsigned int i = 0; i < line.size(); ++i)
	{
		result = result + static_cast<int>(line[i]) * static_cast<int>(line[i]) * static_cast<int>(line[i]) % number;
	}
	return result;
}

void addToHashTable(HashTable *hashTable, int number, std::string const &line)
{
	int value = hashFunction(line, number);
	while (true)
	{
		if (value < hashTable->size - 1 && (hashTable->table[value].quantity == 0 || line == hashTable->table[value].word))
		{
			++hashTable->table[value].quantity;
			hashTable->table[value].word = line;
			return;
		}

		while (value < hashTable->size - 1)
		{
			++value;
			if (line == hashTable->table[value].word || hashTable->table[value].quantity == 0)
			{
				++hashTable->table[value].quantity;
				hashTable->table[value].word = line;
				return;
			}

		}
		int oldSize = hashTable->size;
		HashElement *temp = hashTable->table;
		hashTable->size *= 2;
		hashTable->table = new HashElement[hashTable->size];
		for (int i = 0; i < oldSize; ++i)
		{
			hashTable->table[i] = temp[i];
		}
		delete[] temp;
		for (int i = oldSize; i < hashTable->size; ++i)
		{
			hashTable->table[i].quantity = 0;
		}

		while (value < hashTable->size - 1)
		{
			if (line == hashTable->table[value].word || hashTable->table[value].quantity == 0)
			{
				++hashTable->table[value].quantity;
				hashTable->table[value].word = line;
				return;
			}
			++value;
		}
	}
}

HashTable *createHashTable(int size)
{
	HashTable *hashTable = new HashTable;
	hashTable->size = size;
	hashTable->table = new HashElement[size];
	for (int i = 0; i < size; ++i)
	{
		hashTable->table[i].quantity = 0;
	}
	return hashTable;
}

bool isElementEmpty(HashTable *hashTable, int position)
{
	return hashTable->table[position].quantity == 0;
}

void print(HashTable *hashTable)
{
	for (int i = 0; i < hashTable->size; ++i)
	{
		if (!isElementEmpty(hashTable, i))
		{
			std::cout << hashTable->table[i].word << ": " << hashTable->table[i].quantity << " times." << std::endl;
		}
	}
}

void deleteTable(HashTable *hashTable)
{
	delete[] hashTable->table;
	delete hashTable;
}