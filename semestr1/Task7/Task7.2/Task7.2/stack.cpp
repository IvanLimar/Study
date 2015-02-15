#include "stack.h"

struct StackElement
{
	char element = ' ';
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

void push(Stack *stack, char stackElement)
{
	StackElement *newElement = new StackElement();
	newElement->element = stackElement;
	newElement->next = stack->head;
	stack->head = newElement;
}

char pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return ' ';
	}
	char result = stack->head->element;
	StackElement *temp = stack->head;
	stack->head = stack->head->next;
	temp->next = nullptr;
	delete temp;
	return result;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *temp = stack->head;
		stack->head = stack->head->next;
		temp->next = nullptr;
		delete temp;
	}
	delete stack;
}

Stack *createStack()
{
	Stack *stack = new Stack;
	stack->head = nullptr;
	return stack;
}