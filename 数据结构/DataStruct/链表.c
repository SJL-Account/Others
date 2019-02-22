/*
结构体:先声明后定义
struct NAME
{

};

NAME name1,name2...
NAME *p;
结构体变量定义后就进行了内存的分配:在栈区

三种引用变量的类型
name.NO1
*p.NO1
p->N01
*/

#include "structHead.h"
typedef int ElemType;

typedef struct Node{
	ElemType data;
	//为什么这么定义
	struct Node *next;

}LNode, *LinkList;


//整表随机创建
LinkList CreateListHead()
{

	LinkList p, q;
	//随机生成数字插入
	LinkList L = (LinkList *)malloc(sizeof(LNode));
	L->next = NULL;

	srand(time(0));
	for (int i = 0; i <=10; i++)
	{
		p = (LinkList *)malloc(sizeof(LNode));
		//p->data = rand()%100+1;
		p->data = i;
		p->next = L->next;
		L->next = p;
	}

	return L;
}

//整表删除
Status DelList(LinkList L)
{
	LinkList p = L->next;
	LinkList q;
	//整表删除包括头结点吗
	//循环整个链表
	//释放地址
	while (p)
	{
		q = p;
		p=p->next;
		free(q);
	}
	L->next = NULL;
	return OK;

}

Status ListInsert_L(LinkList L, int i, ElemType e)
{
	LinkList p = L;
	//if (i<1 || i>length(L))return ERROR;
	//从头向后寻找，一直到i-1;

	int j = 1;
	while (p&&j < i)					//1. p->L j=1;(++)  ->  2.p->a1 j=2  (++)  -> 3.p->a2 j=3  (++)  -> 4.p=a3 j=4 (++)  -> 5.p=a4 j=5
	{
		//跳出循环时，p为i-1的地址
		p = p->next;
		j++;
	}

	if (!p/*到达了链表的结尾*/ || j>i)
	{
		return ERROR;
	}

	/*
	找第i个，第i-1个地址
	*/
	LinkList q = p->next;

	//创建newbase
	LinkList newbase = (LinkList)malloc(sizeof(LNode));
	if (!newbase)exit(OVERFLOW);
	newbase->data = e;
	//找到i-1元素，使其next =newbase
	p->next = newbase;
	//找到i元素的地址p，使newbase->next=p
	newbase->next = q;

	return OK;
}

Status ListDel_L(LinkList L, int i)
{
	//1.验证用户输入
	if (i<1 || i>length(L))return ERROR;
	//2.程序处理

	int j = 1;
	LinkList p = L;
	while (p&&j < i)
	{
		//跳出时，j=i-1; p指向i的位置
		p = p->next;
		j++;
	}
	LinkList q = p->next;
	p->next = q->next;

	free(q);
	//3.返回结果
	return OK;
}

void ListPrint(LinkList L)
{
	LinkList p;
	p = L->next;
	//如果指向头指针的头结点的next为空,则不存在。
	if (!p)
	{
		printf("链表没有数据");
		return ERROR;
	}

	while (p->next)
	{
		printf("Data:%d Address:%p\n", p->data, p);
		p = p->next;
	}

}

int length(LinkList L)
{
	LinkList p = L->next;
	int i = 0;
	while (p = p->next)
	{
		i++;

	}
	return i;
	//循环该如何想
	//循环变量n
	//推进变量i
	//终止条件j 有多少符合j的条件就发生了多少次循环 初始值--符合条件的最后一个值(不符合条件的前一个值)
	//推进变量->循环变量的值发生改变	
	//找i和n的函数
	//跳出循环时，执行了i次，i=i+increasement
	//初始条件
	//循环条件
	//增量


}

int GetElem(LinkList L, ElemType e)
{
	//验证

	//处理
	//L为头结点
	LinkList p = L->next;

	//循环  
	//1-n
	//p->data
	int j = 1;
	while (p&&p->data != e)
	{
		j++;
		p = p->next;
	}
	if (p)
	{
		return j;

	}
	return 0;

	//返回结果
}

int mainTwo()
{
	//
	//创建
	//for (int i = 0; i < 6; i++)
	//{
	//	//i在循环内的取值为0-5
	//	//程序执行了6次
	//	//跳出循环时,i=6
	//	
	//}
	//int i=0;
	//while (i<6)
	//{
	
	//	//i在循环内的取值为0-5
	//	//程序执行了6次
	//	//跳出循环时,i=6
	//	i++;
	//}

	//int i = 0;
	//do
	//{
	//	//i在循环内的取值为1-5
	//	//程序执行了5次
	//	//跳出循环时,i=6
	//	i++;
	//} while (i<6);


	LinkList L;
	if (L = CreateListHead())
	{
		printf("创建成功%p\n", L);

	}

	int operation = 1;

	ListPrint(L);
	while (operation)
	{
		printf("=======================================\n请选择操作:\n1.插入数据\n2.删除数据\n3.查找数据\n4.销毁链表\n5.打印当前表长\n0.退出\n");
		scanf_s("%d", &operation);
		switch (operation){
		case 1:{
				   printf("请输入要插入的数据:");
				   ElemType e;
				   scanf_s("%d",&e);
				   printf("请输入插入的位置:");
				   int i = 0;
				   scanf_s("%d",&i);
				   if(ListInsert_L(L, i, e))
				   {
					   printf("插入成功");
				   }
					else
					{
						printf("插入失败");
					}

				   ListPrint(L);
		}
			break;
		case 2:{
				   printf("请输入要删除的位置:");
				   int i = 0;
				   scanf_s("%d",&i);
				   if (ListDel_L(L, i))
				   {
					   printf("删除成功");
				   }
				   else

				   {
					   printf("删除失败");
				   }
				   ListPrint(L);
		}
			break;
		case 3:{
				   printf("请输入要查找到的元素:\n");
				   ElemType e;
				   int i = 0;
				   scanf_s("%d",&e);
				   if (i = GetElem(L, e))
				   {
					   printf("查找成功,位置为%d",i);

				   }
				   else
				   {
					   printf("查找失败..");
				   }
		}
			break;
		case 4:
		{
				  if (DelList(L))
				  {
					  printf("链表已销毁");
				  }
				  else
				  {
					  printf("销毁未成功");
				  }
				  system("pause");
				  exit(0);
		}
			break;


		case 5:{
				   printf("当前表长为:%d", length(L));

		}
			break;
		default:break;
		}

	}



}

