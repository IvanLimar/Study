#include <iostream>;
#include <string>;

using namespace std;

int main()
{
	cout << "Enter the main line:" << endl;
	string mainLine;
	cin >> mainLine;
	cout << "Enter the small line:" << endl;
	string smalLine;
	cin >> smalLine;

	const int lengthOfMain = mainLine.length();
	const int lengthOfSmall = smalLine.length();
	int numbersOfEaqals = 0;
	int mainLineIndex = 0;

	while (mainLineIndex <= lengthOfMain - 1)
	{
		int smallLineIndex = 0;
		if (smalLine[smallLineIndex] == mainLine[mainLineIndex])
		{
			int notEqual = 0;
			++smallLineIndex;
			int i = mainLineIndex + 1;
			while (i <= lengthOfMain - 1 && smallLineIndex <= lengthOfSmall - 1)
			{
				if (smalLine[smallLineIndex] != mainLine[i])
				{
					++notEqual;
				}
				++smallLineIndex;
				++i;
			}
			if (notEqual == 0 && smallLineIndex == lengthOfSmall)
			{
				++numbersOfEaqals;
			}
		}
		++mainLineIndex;
	}

	cin.ignore();
	cout << "number of equals: " << numbersOfEaqals << endl;

	return 0;
}