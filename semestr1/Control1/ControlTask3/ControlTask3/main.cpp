#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int main()
{
	ifstream file("text.txt", ios::in);

	while (!file.eof())
	{
		string line;
		file >> line;
		for (int i = 0; i < line.size(); ++i)
		{
			while (line[i] == line[i + 1])
			{
				line.erase(i + 1, 1);
			}
		}
		cout << line << endl;
	}

	file.close();
	return 0;
}

/*
���� 1:
����: dasda
�����: dasda

���� 2:
����: ddaassddaa
		abc
		xxx
�����: dasda
abc
x

���� 3:
����: dasda
�����: dasda
*/