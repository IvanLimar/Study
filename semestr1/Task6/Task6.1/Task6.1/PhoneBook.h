#pragma once
#include <string>
#include <fstream>

struct PhoneBook;

//��������� � phoneBook ��� � ����� ��������
void addToPhoneBook(PhoneBook *phoneBook, int position);

//������� �������� (phoneBook.number) �� ����� (name)
void findPhoneNumbers(std::string const &name, PhoneBook *phoneBook, int length);

//������� ����� (phoneBook.name) �� ������ (number)
void findPhoneNames(std::string const &number, PhoneBook *phoneBook, int length);

//���������� �� �����
void reading(std::fstream &file, PhoneBook *phoneBook, int &position);

//������� PhoneBook
PhoneBook *createPhoneBook();

//������ � ����
void writing(std::fstream &file, PhoneBook *phoneBook, int position);

//��������
void deleteBook(PhoneBook *phoneBook);