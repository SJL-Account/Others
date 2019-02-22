#include "structHead.h"
#define MAXSIZE 100
typedef int ElemType;

typedef struct
{
	ElemType data;
	int cur;
}Component,StaticLinkList[MAXSIZE];

//创建
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
//静态链表Malloc函数

int SLL_Malloc(StaticLinkList space)
{
	//判断备用链表是否可用
	int i=space[0].cur;
	if (space[i].cur)
	{
		space[0].cur = space[i].cur;
		return i;
	}

	return 0;

	//什么时候满了
	//申请并且返回一个备用链表
	//将头指针指向申请备用链表的cur
}


//插入
Status InserList(StaticLinkList space,int i,ElemType e)
{
	//检查空间大小
	if (i<1 || i>MAXSIZE)
	{
		return ERROR;
	}
	
	int j,k=1,l=0;
	if(j = SLL_Malloc(space))
	{
		space[j].data = e;
		//查找i-1的结点
		while (k < i )
		{
			l = space[l].cur;
			k++ ;
		}

		//如果l不为0
		if (l)
		{

		}

		space[j].cur = space[l].cur;

		space[l].cur = j;
 		return OK;


	}

	return ERROR;
	//SSL_Malloc,并赋值

	//a[0]2 a[1]2  a[2]3 a[3]4 
	//a[0]3 a[1]2  a[2]3 a[3]4
	//a[0]3 a[1]3  a[2]1 a[3]4 
	//a[0]4 a[1]3  a[2]1 a[3]2

	//查找i-1的结点 space[i].cur=插入结点的地址

}

//删除
Status ListDelete(StaticLinkList space,int i)
{
	

	return OK;
}

int SLL_Free(StaticLinkList space )
{


}




//查找

//合并

//打印

int main()
{
	StaticLinkList space;
	if (InitialList(space))
	{
		printf("创建成功!");
	}
	ElemType e = 10;
	if (InserList(space, 2, e))
	{
		printf("插入成功");
	}
	if (InserList(space, 2, 200))
	{
		printf("插入成功");
	}


	getchar();

}
//Max
//i 0--max-1 
//data 1-Max
//cur
