#include "stack.h"

void push(Stack *stack, char stackElement)
{
	StackElement *newElement = new StackElement();
	newElement->element = stackElement;
	if (stack->head == nullptr)
	{
		stack->head = newElement;
	}
	else
	{
		newElement->next = stack->head;
		stack->head = newElement;
	}
}

char pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return ' ';
	}
	char result = stack->head->element;
	StackElement *temp = new StackElement();
	temp->next = stack->head;
	stack->head = stack->head->next;
	temp->next->next = nullptr;
	delete temp->next;
	delete temp;
	return result;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *temp = new StackElement();
		temp->next = stack->head;
		stack->head = stack->head->next;
		temp->next->next = nullptr;
		delete temp->next;
		delete temp;
	}
	delete stack;
}