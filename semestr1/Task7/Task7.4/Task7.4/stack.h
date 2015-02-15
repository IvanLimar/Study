#pragma once

struct Stack;
struct StackElement;

struct Stack
{
	StackElement *head = nullptr;
};

struct StackElement
{
	char element = ' ';
	StackElement *next = nullptr;
};

//Добавляет stackElement в stack
void push(Stack *stack, char stackElement);

//Выталкивает элемент из stack, если stack пуст, то возвращает ' '
char pop(Stack *stack);

//Удаляет Stack
void deleteStack(Stack *stack);