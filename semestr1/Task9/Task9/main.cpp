#include "hashTable.h"
#include <fstream>

using namespace std;

void main()
{
	ifstream file("text.txt");
	int size = 5;
	HashTable *hashTable = createHashTable(size);
	while (!file.eof())
	{
		string line;
		file >> line;
		for (unsigned int i = 0; i < line.size(); ++i)
		{
			bool const isLetterOrNumber = (line[i] >= '0' &&  line[i] <= '9') || (line[i] >= 'a' &&  line[i] <= 'z') || (line[i] >= 'A' &&  line[i] <= 'Z');
			if (!isLetterOrNumber)
			{
				line.erase(i, 1);
				--i;
			}
		}
		if (!line.empty())
		{
			addToHashTable(hashTable, size, line);
		}
		
	}
	file.close();
	print(hashTable);
	deleteTable(hashTable);
}