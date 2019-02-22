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
	int top1;
	int top2;
}DoubleStackList, *DoubleStackListPoint;

Status InitStack1(DoubleStackListPoint DSLP)
{
	DSLP->top1 = -1;
	DSLP->top2 = -1;
}
Status Push1(DoubleStackListPoint DSL, SElementType e, int StackNumber)
{
	if (DSL->top1 == DSL->top2 + 1)
	{
		return ERROR;
	}
	if (StackNumber == 1)
	{
		DSL->data[++DSL->top1] = e;
	}
	else if (StackNumber == 2)
	{
		DSL->data[--DSL->top2] = e;
	}
	return OK;
}

Status Pop1(DoubleStackListPoint DSL, SElementType *e, int StackNumber)
{
	if (StackNumber==1)
	{
		if (DSL->top1 == -1)
		{
			return ERROR;
		}
		*e = DSL->data[DSL->top1--];
	}
	else if (StackNumber == 2)
	{
		if (DSL->top1 == MaxSize)
		{
			return ERROR;
		}
		*e = DSL->data[DSL->top2++];

	}
	return OK;
}

int main()
{
	DoubleStackList DSL;
	InitStack1(&DSL);
	SElementType e = 24;
	Push1(&DSL,&e,2);
}
