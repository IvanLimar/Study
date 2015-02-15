#include <iostream>

using namespace std;

long recFibonacci(int n)
{
	if (n <= 2)
	{
		return (n == 2) ? 1 : 1;
	}
	else
	{
		return recFibonacci(n - 1) + recFibonacci(n - 2);
	}
}

long fibonacci(int n)
{
	if (n <= 2)
	{
		return (n == 2) ? 1 : 1;
	}
	else
	{
		long numberOne = 1;
		long numberTwo = 1;
		for (int i = 3; i <= n; ++i)
		{
			const long p = numberOne;
			numberOne = numberOne + numberTwo;
			numberTwo = p;			
		}
		return numberOne;
	}
}

int main()
{
	const bool isGoodWay = true;
	const int number = 20; // number >= 1
	long fibonacciNumber = 1;

	if (isGoodWay)
	{
		fibonacciNumber = fibonacci(number);
	}
	else
	{
		fibonacciNumber = recFibonacci(number);
	}

	cout << "Fibbonacci number[" << number << "]=" << fibonacciNumber << endl;
	return 0;
}