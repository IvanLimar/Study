#pragma once
#include <string>
#include <fstream>

struct PhoneBook;

//Добавляет в phoneBook имя и номер телефона
void addToPhoneBook(PhoneBook *phoneBook, int position);

//Выводит телефоны (phoneBook.number) по имени (name)
void findPhoneNumbers(std::string const &name, PhoneBook *phoneBook, int length);

//Выводит имена (phoneBook.name) по номеру (number)
void findPhoneNames(std::string const &number, PhoneBook *phoneBook, int length);

//Считывание из файла
void reading(std::fstream &file, PhoneBook *phoneBook, int &position);

//Создаем PhoneBook
PhoneBook *createPhoneBook();

//Запись в файл
void writing(std::fstream &file, PhoneBook *phoneBook, int position);

//Удаление
void deleteBook(PhoneBook *phoneBook);