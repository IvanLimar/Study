#include <fstream>
#include "list.h"

using namespace std;

void main()
{
	fstream file("text.txt");
	List *list = createList();
	while (!file.eof())
	{
		string line;
		file >> line;
		addToList(list, line);
	}
	file.close();
	deleteRepetetiveElements(list);
	printList(list);
	deleteList(list);
}

/*����1: 
����: 
aaa
bbbb
aaa
aaa 
 �����: aaa
 bbbb

 ���� 2:
 ����:
 aaa
 bbbb

 �����:
 aaa
 bbbb

 ���� 3:
 ����:
 a
 a
 a
 b
 c
 b
 h

 �����:
 a
 b
 c
 h

*/