#pragma once
#include <string>

struct Stack;

//Добавляет stackElement в stack
void push(Stack *stack, char stackElement);

//Выталкивает элемент из stack, если stack пуст, то возвращает ' '
char pop(Stack *stack);

//Удаляет Stack
void deleteStack(Stack *stack);

//Создаем стек
Stack *createStack();

//Проверяем, пуст ли стек
bool isStackEmpty(Stack *stack);

//Смотрим в вершину стека
char head(Stack *stack);