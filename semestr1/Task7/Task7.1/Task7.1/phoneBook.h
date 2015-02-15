#pragma once
#include <string>

struct PhoneBook;

//������� PhoneBook
PhoneBook *createPhoneBook();

//������� PhoneBook
void deletePhoneBook(PhoneBook *phoneBook);

void add(PhoneBook *phoneBook, std::string const &name, std::string const &number);

//����� phoneBook �� �������
void writing(PhoneBook *phoneBook);

// MergeSort phoneBook �� name (���� isName - true) ��� �� number (���� isName - false)
void mergeSort(PhoneBook *phoneBook, bool isName);