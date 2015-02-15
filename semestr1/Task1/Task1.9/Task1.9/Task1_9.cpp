#include <iostream>

using namespace std;

int main()
{
	cout << "Enter the number: " << endl;
	int number = 0;
	cin >> number;

	int primeNumberIndex = 0;
	int *primeNumber = new int[number];
	primeNumber[primeNumberIndex] = 2;

	for (int i = 3; i <= number; ++i)
	{
		const int startIndex = 0;
		int numberOfDivisors = 0;
		for (int j = startIndex; j <= primeNumberIndex; ++j)
		{
			if (i % primeNumber[j] == 0)
			{
				++numberOfDivisors;
			}
		}
		if (numberOfDivisors == 0)
		{
			++primeNumberIndex;
			primeNumber[primeNumberIndex] = i;
		}
	}
	cout << "prime numbers:" << endl;
	for (int i = 0; i <= primeNumberIndex; ++i)
	{
		cout << primeNumber[i] << endl;
	}

	cin.ignore();
	delete[] primeNumber;
	return 0;
}