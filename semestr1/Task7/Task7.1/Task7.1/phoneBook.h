#pragma once
#include <string>

struct PhoneBook;

//Создаем PhoneBook
PhoneBook *createPhoneBook();

//Удаляем PhoneBook
void deletePhoneBook(PhoneBook *phoneBook);

void add(PhoneBook *phoneBook, std::string const &name, std::string const &number);

//Вывод phoneBook на консоль
void writing(PhoneBook *phoneBook);

// MergeSort phoneBook по name (если isName - true) или по number (если isName - false)
void mergeSort(PhoneBook *phoneBook, bool isName);