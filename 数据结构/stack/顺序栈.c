#include<stdio.h>
#include<stdlib.h>
#define OK 1
#define ERROR 0
#define OVERFLOW -1
typedef int Status;
#define _CRT_SECURE_NO_WARNINGS 

#define MaxSize 10
typedef int SElementType;


typedef struct 
{
	SElementType data[MaxSize];
	int top;
}StackList, *StackListPoint;

Status InitStack(StackListPoint SLP)
{
	SLP->top = -1;

}

Status Push(StackListPoint SLP,SElementType e)
{
	if (SLP->top == MaxSize)
	{
		return ERROR;
	}

	SLP->top++;
	SLP->data[SLP->top] = e;

}

Status Pop(StackListPoint SLP,SElementType *e)
{
	if (SLP->top == -1)
	{
		return ERROR;
	}
	*e = SLP->data[SLP->top];
	SLP->top--;
	
	return OK;
}

int main6 ()
{
	StackList SL;
	InitStack(&SL);
	SElementType *L = SL.data;
	SElementType e = 10;
	Push(&SL, e);
	e = 2;
	Push(&SL, e);

	e = 8;
	Push(&SL, e);

	e = 5;
	Push(&SL, e);
	SElementType e1 = 0;
	Pop(&SL,&e1);
	Pop(&SL, &e1);

	Pop(&SL, &e1);

	Pop(&SL, &e1);
}