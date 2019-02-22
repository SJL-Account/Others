//struct StackNode *next; Ϊʲô��ô����
//Ϊʲ������ͬ������

#include<stdio.h>
#include<stdlib.h>
#define OK 1
#define ERROR 0
#define OVERFLOW -1
typedef int Status;
#define _CRT_SECURE_NO_WARNINGS 

#define MaxSize 10

typedef int ElemType;
//�����Ϣ(����)
typedef struct
{
	ElemType data;
	struct StackNode *next;
}StackNode, *StackNodePoint;
//������Ϣ
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
		printf("��ջ�ɹ�");
	}
	if (Push2(&LS, 1, 14))
	{
		printf("��ջ�ɹ�");

	}
	if (Push2(&LS, 2, 34))
	{
		printf("��ջ�ɹ�");
	}

	PrintStack(&LS);

	if(Pop2(&LS, &e))
	{
		printf("��ջ�ɹ�");
	}
	PrintStack(&LS);
	getchar();
}