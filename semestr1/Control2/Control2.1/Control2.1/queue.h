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

//������� �������
Queue *createQueue();

//������� �������
void moveQueue(Queue *queue);

//��������� ������� � �������
void enQueue(Queue *queue, int element);

//������� ������� �� �������
int deQueue(Queue *queue);