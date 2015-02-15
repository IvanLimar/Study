#include "hash.h"

//Хеш-функция
int hashFuction(std::string text, int startIndex, int endIndex)
{
	int result = 0;
	int const number = 1707;
	for (int i = startIndex; i <= endIndex; ++i)
	{
		int const code = int(text[i]);
		result = result + (code * code * code) % number;
	}
	return result;
}

//Кольцевой хеш
int circleHash(int previousHash, std::string text, int startIndex, int endIndex)
{
	int const numberOne = hashFuction(text, startIndex - 1, startIndex - 1);
	int const numberTwo = hashFuction(text, endIndex, endIndex);
	return previousHash - numberOne + numberTwo;
}