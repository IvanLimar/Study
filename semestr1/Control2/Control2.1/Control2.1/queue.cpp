#include "queue.h"

Queue *createQueue()
{
	Queue *queue = new Queue();
	queue->head = nullptr;
	queue->tail = nullptr;
	return queue;
}

void moveQueue(Queue *queue)
{
	while (queue->head != queue->tail)
	{
		QueueElement *temp = new QueueElement();
		temp->next = queue->head;
		queue->head = queue->head->next;
		temp->next->next = nullptr;
		temp->next->previous = nullptr;
		delete temp->next;
		delete temp;
	}
	if (queue->head != nullptr)
	{
		delete queue->head;
	}
	delete queue;
}

void enQueue(Queue *queue, int element)
{
	QueueElement *newElement = new QueueElement();
	newElement->value = element;
	if (queue->head == nullptr)
	{
		queue->tail = newElement;
	}
	newElement->next = queue->head;
	if (queue->head != nullptr)
	{
		queue->head->previous = newElement;
	}
	newElement->previous = nullptr;
	queue->head = newElement;
}

int deQueue(Queue *queue)
{
	if (queue->tail == nullptr)
	{
		return -10000;
	}
	int result = queue->tail->value;
	QueueElement *temp = new QueueElement();
	temp->next = queue->tail;
	queue->tail = queue->tail->previous;
	if (queue->tail != nullptr)
	{
		queue->tail->next = nullptr;
	}
	temp->next->previous = nullptr;
	delete temp->next;
	delete temp;
	if (queue->tail == nullptr)
	{
		queue->head = nullptr;
	}
	return result;
}