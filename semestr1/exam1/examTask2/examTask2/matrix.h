#pragma once

//������� ��������� ������ (������������ ��� ������ ��������)
int **createMatrix(int hight, int length);

//�������� ���������� �������
void deleteMatrix(int **matrix, int hight);

//�������� �������� �����, ���� ��� ����.
void printSeddlePoints(int **matrix, int hight, int length);

//���� �����������(����� ��� ������)
int size();