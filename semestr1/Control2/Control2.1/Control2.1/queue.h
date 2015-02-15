#pragma once

struct QueueElement
{
	int value;
	QueueElement *next;
	QueueElement *previous;
};

struct Queue
{
	QueueElement *head;
	QueueElement *tail;
};

//Создаем очередь
Queue *createQueue();

//Удаляем очередь
void moveQueue(Queue *queue);

//Добавляем элемент в очередь
void enQueue(Queue *queue, int element);

//Удаляем элемент из очереди
int deQueue(Queue *queue);