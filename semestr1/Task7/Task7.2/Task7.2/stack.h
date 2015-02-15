#pragma once

struct Stack;

//Создаем стек
Stack *createStack();

//Добавляет stackElement в stack
void push(Stack *stack, char stackElement);

//Выталкивает элемент из stack, если stack пуст, то возвращает ' '
char pop(Stack *stack);

//Удаляет Stack
void deleteStack(Stack *stack);