/*线性表的顺序存储*/

#include "structHead.h"
#define LIST_INIT_SIZE 100 //初始分配量
#define LISTINCRESEMENT 10//存储空间的分配增量


typedef int ElemType;
//线性表
typedef struct
{
	ElemType *elem;//存储空间基地址
	int length;//当前长度
	int listsize;//当前分配的存储容量

}SqlList;
//初始化
Status InitList_Sq(SqlList *L) 
{
	L->elem = (ElemType *)malloc(LIST_INIT_SIZE*(sizeof(ElemType)));
	//如果为空，栈溢出
	if (!L->elem)exit(OVERFLOW);
	L->length = 0;
	L->listsize = LIST_INIT_SIZE;

	return OK;
}
//插入
Status ListInsert_Sq(SqlList *L,int i,ElemType e)
{
	//1.判断i的合法值（从1开始向后排）
	if (i<1 || i>L->length + 1) 
		return ERROR;
	//2.判断表满没满
	if (L->length >= L->listsize) 
	{
		ElemType *newbase = (ElemType*)realloc(L->elem,(L->listsize + LISTINCRESEMENT)*sizeof(ElemType));
		//指向新地址
		L->elem = newbase;
		
		if (!L->elem)return OVERFLOW;

		//在基地址上增加L->listsize+LISTINCRESEMENT
		L->listsize += LISTINCRESEMENT;
	}

	ElemType *q= &(L->elem[i - 1]);
	ElemType *p;
		//依次后推
	for (p=&(L->elem[L->length-1]); p>=q; p--)
	{
		*(p + 1) = *p;
	}
	*q = e;
	++L->length;
	return OK;
}
//删除
Status ListDelete_Sq(SqlList *L, int i)
{
	//1.判断i的合法值
	if (i<1 || i>=L->length + 1)
	{
		return ERROR;

	}
	//这里不知道为什么不能用ElemType
	ElemType *q= &(L->elem[L->length - 1]);
	ElemType *p;

	//依次前移
	for (p = &(L->elem[i - 1]); p <= q; p++)
	{
		*(p) = *(p+1);
	}
	
	--L->length;
	return OK;
}

//自己写的
int LocateElem_Sq(SqlList *L,ElemType e)
{
	//若找到，返回位置，否则，返回0
	for (int i = 0; i < L->length; i++)
	{
		if (L->elem[i] == e)
		{
			return i + 1;
		}
		else
		{
			continue;
		}

	}
	return 0;


}
//严
int LocateElem_Sq2(SqlList *L, ElemType e)
{
	//若找到，返回位置，否则，返回0
	int i = 1;
	while (i <= L->length&&*(L->elem++) != e)
	{
		i++;
	}
	if (i <= L->length)
	{
		return i;
	}
	return 0;


}
//合并表La,Lb
Status MergeList(SqlList *La,SqlList *Lb,SqlList *Lc)
{
	//分内存
	ElemType *Pa = La->elem;
	ElemType *Pb = Lb->elem;
	ElemType *Pc = Lc->elem;
	int LaLength = La->length;
	int LbLength = Lb->length;
	//结构体怎么在内存中存储的？
	Lc->listsize = Lc->length = LaLength + LaLength;
	Lc->elem = (ElemType *)malloc(Lc->listsize*(sizeof(ElemType)));
	//检查基地址
	if (!Lc->elem) return OVERFLOW;

	//有序归并
	//依次取值，赋予*Pc
	//0 - 9;
	int* La_last = Pa + (La->length - 1);
	int * Lb_last = Pb + (Lb->length - 1);
	while (Pa <= La_last && Pb <= La_last)
	{
		if (*Pa>=*Pb) *Pc++ = *Pb++;
		else *Pc++ = *Pa++;
		
	}
	while (Pa <= La_last)
		*Pc++ = *Pa++;

	while (Pb <= La_last)
		*Pc++ = *Pb++;

	return 1;
}


int mainOne()
{
	SqlList La;// elem length listsize,描述线性表的基本信息
	SqlList Lb;
	SqlList Lc;
	if (InitList_Sq(&La))
	{
		
	  printf("顺序线性表初始化成功\n");
	}


	int operation = 1;

	
	while (operation)
	{
		printf("=======================================\n请选择操作:\n1.插入数据\n2.删除数据\n3.查找数据\n4.合并顺序表\n5.打印顺序表\n0.退出\n");
		scanf_s("%d", &operation);
		switch (operation)
		{
		case 1:
		{
				  printf("请输入一个线性表元素(0为结束符):");
				  ElemType e;
				  int i = 1;
				  //返回0和1
				  while (scanf_s("%d", &e))
				  {
					  if (e)
					  {
						  if (ListInsert_Sq(&La, i, e))
						  {

							  printf("插入成功....请继续输入\n");
							  i++;
						  }
					  }
					  else
					  {
						  break;
					  }
				  }
				  printf("元素插入结束......\n");

		}
			break;
		case 2:
		{
				  printf("请输入元素的位置：\n");
				  int i = 0;
				  scanf_s("%d", &i);
				  if (ListDelete_Sq(&La, i)){
					  printf("删除成功.......\n");

				  }
				  else
				  {
					  printf("删除失败.......，请检查元素的位置是否超出了表长\n");

				  }
		}
			break;
		case 3:
		{
				  printf("请输入元素要查找的元素:\n");
				  ElemType e;
				  scanf_s("%d",&e);
				  int i = 0;
				  if (i=LocateElem_Sq(&La, e))
				  {
					  printf("查找成功,位置为%d",i);
				  }
				  else
				  {
					  printf("未找到元素");
				  }
		}
			break;
		case 4:
		{
				  printf("功能有限，不能展示");
		}
			break;
		case 5:
		{
				  printf("功能有限，不能展示");
		}
			break;

		default:break;
		}
	}



	
	
}



