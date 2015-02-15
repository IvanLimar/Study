#include <iostream>
#include <string>

using namespace std;

int main()
{
	string line;
	cout << "Enter the line" <<  endl;
	cin >> line;
	const int size = line.length();
	
	int openedBrackets = 0;
	int closedBrackets = 0;
	int i = 0;
	while (i < size && closedBrackets <= openedBrackets)
	{
		if (line[i] == '(')
		{
			++openedBrackets;
		}
		if (line[i] == ')')
		{
			++closedBrackets;
		}
		++i;
	}

	if (openedBrackets != closedBrackets)
	{
		cout << "Answer: false";
	}
	else
	{
		cout << "Answer: true";
	}

	cin.ignore();
	cout << endl;
	return 0;
}