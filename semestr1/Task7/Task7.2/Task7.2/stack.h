#pragma once

struct Stack;

//������� ����
Stack *createStack();

//��������� stackElement � stack
void push(Stack *stack, char stackElement);

//����������� ������� �� stack, ���� stack ����, �� ���������� ' '
char pop(Stack *stack);

//������� Stack
void deleteStack(Stack *stack);