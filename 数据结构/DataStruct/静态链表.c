#include "structHead.h"
#define MAXSIZE 100
typedef int ElemType;

typedef struct
{
	ElemType data;
	int cur;
}Component,StaticLinkList[MAXSIZE];

//����
Status InitialList(StaticLinkList space)
{
	//MAXSIZE=i+1
	for (int  i = 0; i < MAXSIZE-1; i++)
	{
		if (i < 50)
		{
			space[i].data = i + 1;

		}
		space[i].cur = i + 1;
	}
	space[MAXSIZE - 1].cur = 0;
	
}
//��̬����Malloc����

int SLL_Malloc(StaticLinkList space)
{
	//�жϱ��������Ƿ����
	int i=space[0].cur;
	if (space[i].cur)
	{
		space[0].cur = space[i].cur;
		return i;
	}

	return 0;

	//ʲôʱ������
	//���벢�ҷ���һ����������
	//��ͷָ��ָ�����뱸�������cur
}


//����
Status InserList(StaticLinkList space,int i,ElemType e)
{
	//���ռ��С
	if (i<1 || i>MAXSIZE)
	{
		return ERROR;
	}
	
	int j,k=1,l=0;
	if(j = SLL_Malloc(space))
	{
		space[j].data = e;
		//����i-1�Ľ��
		while (k < i )
		{
			l = space[l].cur;
			k++ ;
		}

		//���l��Ϊ0
		if (l)
		{

		}

		space[j].cur = space[l].cur;

		space[l].cur = j;
 		return OK;


	}

	return ERROR;
	//SSL_Malloc,����ֵ

	//a[0]2 a[1]2  a[2]3 a[3]4 
	//a[0]3 a[1]2  a[2]3 a[3]4
	//a[0]3 a[1]3  a[2]1 a[3]4 
	//a[0]4 a[1]3  a[2]1 a[3]2

	//����i-1�Ľ�� space[i].cur=������ĵ�ַ

}

//ɾ��
Status ListDelete(StaticLinkList space,int i)
{
	

	return OK;
}

int SLL_Free(StaticLinkList space )
{


}




//����

//�ϲ�

//��ӡ

int main()
{
	StaticLinkList space;
	if (InitialList(space))
	{
		printf("�����ɹ�!");
	}
	ElemType e = 10;
	if (InserList(space, 2, e))
	{
		printf("����ɹ�");
	}
	if (InserList(space, 2, 200))
	{
		printf("����ɹ�");
	}


	getchar();

}
//Max
//i 0--max-1 
//data 1-Max
//cur
