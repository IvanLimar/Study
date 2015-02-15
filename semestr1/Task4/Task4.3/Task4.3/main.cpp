#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ifstream file("text.txt", ios::in);
	int numberOfNotEmptyLines = 0;
	while (!file.eof())
	{
		bool isEndOfLine = false;
		bool isLineEmpty = true;
		while (!isEndOfLine)
		{
			char s[1];
			s[0] = '/0';
			file.read(s, 1);
			int const code = (int) s[0];
			int const tabCode = (int) '	';
			int const gapCode = (int) ' ';
			int const enterCode = (int) 'n';
			if (code != tabCode && code != gapCode && isLineEmpty && code != 10 && !file.eof())
			{
				isLineEmpty = false;
			}
			if (code == 10 || file.eof())
			{
				isEndOfLine = true;
			}
		}
		if (!isLineEmpty)
		{
			++numberOfNotEmptyLines;
		}
	}
	cout << "Number of not empty lines: " << numberOfNotEmptyLines  << endl;

	file.close();
	return 0;
}

/*
Tests:
1: a
a
"Number of not empty lines: 2"
2:
a a
"Number of not empty lines: 1"
3:
/t/t/t/n
/t/n
/n
/n
"Number of not empty lines: 0"
*/