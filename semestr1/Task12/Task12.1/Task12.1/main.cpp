#include <iostream>
#include <fstream>
#include "hash.h"

using namespace std;

// Сравнение 2 строк
bool compare(string const &pattern, string const &text, int sizeOfPattern, int startIndex)
{
	for (int i = 0; i < sizeOfPattern; ++i)
	{
		if (pattern[i] != text[startIndex + i])
		{
			return false;
		}
	}
	return true;
}

void main()
{
	fstream file("text.txt");
	string text;
	while (!file.eof())
	{
		string line;
		file >> line;
		text = text + line + " ";
	}
	file.close();

	cout << "Enter the pattern: ";
	string pattern;
	cin >> pattern;
	int const patternHash = hashFuction(pattern, 0, pattern.size() - 1);
	int hash = hashFuction(text, 0, pattern.size() - 1);

	if (hash == patternHash)
	{
		if (compare(pattern, text, pattern.size(), 0))
		{
			cout << "Position of first entry: 0." << endl;
			return;
		}
	}

	for (unsigned int i = 1; i < text.size() - pattern.size() + 1; ++i)
	{
		hash = circleHash(hash, text, i, i + pattern.size() - 1);
		if (hash == patternHash)
		{
			if (compare(pattern, text, pattern.size(), i))
			{
				cout << "Position of first entry: " << i << endl;
				return;
			}
		}
	}

	cout << "Entry wasn't found." << endl;
}