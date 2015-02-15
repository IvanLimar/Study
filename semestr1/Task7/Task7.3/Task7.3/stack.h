#pragma once
#include <string>

struct Stack;

//��������� stackElement � stack
void push(Stack *stack, char stackElement);

//����������� ������� �� stack, ���� stack ����, �� ���������� ' '
char pop(Stack *stack);

//������� Stack
void deleteStack(Stack *stack);

//������� ����
Stack *createStack();

//���������, ���� �� ����
bool isStackEmpty(Stack *stack);

//������� � ������� �����
char head(Stack *stack);