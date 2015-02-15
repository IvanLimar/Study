#include <iostream>

using namespace std;

int powerSimple(int number, int exponent)
{
	int result = 1;
	for (int i = 1; i <= exponent; ++i)
	{
		result *= number;
	}
	return result;
}

int powerQuick(int number, int exponent)
{
	if (exponent == 0)
	{
		return 1;
	}
	else
	{
		if (exponent % 2 == 0)
		{
			int x = powerQuick(number, exponent / 2);
			return x*x;
		}
		else
		{
			return number * powerQuick(number, exponent - 1);
		}
	}
}

int main()
{
	const bool isQuickWay = true;
	const int number = 5;
	const int exponent = 5;
	int result = 1;

	if (isQuickWay)
	{
		result = powerQuick(number, exponent);
	}
	else
	{
		result = powerSimple(number, exponent);
	}

	cout << number << "^" << exponent << "=" << result << endl;
	return 0;
}