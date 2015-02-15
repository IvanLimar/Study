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

//��������� stackElement � stack
void push(Stack *stack, char stackElement);

//����������� ������� �� stack, ���� stack ����, �� ���������� ' '
char pop(Stack *stack);

//������� Stack
void deleteStack(Stack *stack);