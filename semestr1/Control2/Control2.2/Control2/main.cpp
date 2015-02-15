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

/*Тест1: 
Ввод: 
aaa
bbbb
aaa
aaa 
 Вывод: aaa
 bbbb

 Тест 2:
 Ввод:
 aaa
 bbbb

 Вывод:
 aaa
 bbbb

 Тест 3:
 Ввод:
 a
 a
 a
 b
 c
 b
 h

 Вывод:
 a
 b
 c
 h

*/