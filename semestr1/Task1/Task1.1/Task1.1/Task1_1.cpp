#include <iostream>

using namespace std;

int main()
{
	cout << "Enter the number:" << endl;
	int number;
	cin >> number;
	int sqare = number * number;
	int answer = (sqare + number) * (sqare + 1) + 1;
	for (int i = 1; i <= 4; ++i)
	{
		cout << number;
		const int n = 4;
		for (int j = 1; j <= n - i; ++j)
		{
			cout << "*" << number;
		}
		if (i < 4)
		{
			cout << "+";
		}
	}

	cout << "+1=" << answer << endl;
	system("pause");
	return 0;
}