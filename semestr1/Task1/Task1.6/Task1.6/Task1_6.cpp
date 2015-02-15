#include <iostream>

using namespace std;

int main()
{
	const int number = 9;
	const int maxNumber = 28;
	int summa[maxNumber] = {0};

	for (int firstNumber = 0; firstNumber <= number; ++firstNumber)
	{
		for (int secondNumber = 0; secondNumber <= number; ++secondNumber)
		{
			for (int thirdNumber = 0; thirdNumber <= number; ++thirdNumber)
			{
				++summa[firstNumber + secondNumber + thirdNumber];
			}
		}
	}

	int happyTicket = 0;
	for (int i = 0; i < maxNumber; ++i)
	{
		summa[i] = summa[i] * summa[i];
		happyTicket = happyTicket + summa[i];
	}

	cout << "The number of happy tickets: " << happyTicket << endl;
	return 0;
}