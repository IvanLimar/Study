#include <iostream>

using namespace std;

void reverse(int* aray, int startIndex, int endIndex)
{
	int j = 0;
	for (int i = startIndex; i <= (endIndex + startIndex) / 2; ++i)
	{
		const int a = aray[i];
		aray[i] = aray[endIndex - j];
		aray[endIndex - j] = a;
		++j;
	}
}

int main()
{
	cout << "enter the size of array (first part):" << endl;
	int sizeFirst = 0;
	cin >> sizeFirst;
	cout << "enter the size of array (second part):" << endl;
	int sizeSecond = 0;
	cin >> sizeSecond;

	const int fullSize = sizeFirst + sizeSecond;
	int *aray = new int[fullSize];
	for (int i = 0; i < fullSize; ++i)
	{
		cout << "enter the number: ";
		cin >> aray[i];
	}
	cin.ignore();

	cout << "Array in the begining:";
	for (int i = 0; i < fullSize; ++i)
	{		
		cout << " " <<  aray[i];
	}
	cout << endl << "End:";

	const int startIndex = 0;
	reverse(aray, startIndex, sizeFirst - 1);
	reverse(aray, sizeFirst, fullSize - 1);
	reverse(aray, startIndex, fullSize - 1);

	for (int i = 0; i < fullSize; ++i)
	{
		cout << " " << aray[i];
	}
	cout << endl;

	delete[] aray;
	return 0;
}