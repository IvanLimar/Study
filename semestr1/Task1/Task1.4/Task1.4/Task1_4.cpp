#include <iostream>

using namespace std;

int main()
{
	cout << "Enter divident and divisor (not zero): ";
	int divident = 0; 
	int divisor = 1;
	cin >> divident >> divisor;
	cin.ignore();

	int i = 0;
	int quotient = i * divisor; 
	while (quotient <= abs(divident))
	{
		++i;
		quotient = i * abs(divisor);				
	}
	quotient = i - 1;

	if (divisor * divident < 0)
	{
		quotient = -quotient;
	}
		
	cout << "Quotient: " << quotient << endl;

	return 0;
}