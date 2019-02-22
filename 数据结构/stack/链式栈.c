//struct StackNode *next; 为什么这么定义
//为什不能用同名函数

#include<stdio.h>
#include<stdlib.h>
#define OK 1
#define ERROR 0
#define OVERFLOW -1
typedef int Status;
#define _CRT_SECURE_NO_WARNINGS 

#define MaxSize 10

typedef int ElemType;
//结点信息(对象)
typedef struct
{
	ElemType data;
	struct StackNode *next;
}StackNode, *StackNodePoint;
//链表信息
typedef struct
{
	StackNode *LinkTop;
	int count;
}LinkStack, *LinkStackPoint;

Status InitialStack(LinkStackPoint LSP, StackNodePoint SNP)
{
	SNP->data = 0;
	SNP->next = NULL;
	LSP->LinkTop = SNP;
	LSP->count = 0;
	return OK;
}

Status Push2(LinkStackPoint LSP, int i, ElemType e)
{
	StackNodePoint LNP = (StackNodePoint)malloc(sizeof(StackNode));
	LNP->data = e;
	LNP->next= LSP->LinkTop;
	LSP->LinkTop = LNP;
	LSP->count++;
	return OK;
}

void PrintStack(LinkStackPoint LSP)
{
	StackNodePoint p = LSP->LinkTop;
	while (p)
	{
		printf("%d\n",p->data);
		p = p->next;
	}
}

Status Pop2(LinkStackPoint LSP,ElemType *e)
{
	if (LSP->count = 0)
	{
		return ERROR;
	}
	
	StackNodePoint p = LSP->LinkTop;

	*e = p->data;
	
	LSP->LinkTop = LSP->LinkTop->next;

	free(p);

	LSP->count--;
	return OK;

}

int main456()
{
	LinkStack LS;
	StackNode SN;
	ElemType e = 12;
	InitialStack(&LS, &SN);
	if (Push2(&LS, 0, e))
	{
		printf("进栈成功");
	}
	if (Push2(&LS, 1, 14))
	{
		printf("进栈成功");

	}
	if (Push2(&LS, 2, 34))
	{
		printf("进栈成功");
	}

	PrintStack(&LS);

	if(Pop2(&LS, &e))
	{
		printf("出栈成功");
	}
	PrintStack(&LS);
	getchar();
}