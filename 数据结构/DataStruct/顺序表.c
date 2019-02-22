/*���Ա��˳��洢*/

#include "structHead.h"
#define LIST_INIT_SIZE 100 //��ʼ������
#define LISTINCRESEMENT 10//�洢�ռ�ķ�������


typedef int ElemType;
//���Ա�
typedef struct
{
	ElemType *elem;//�洢�ռ����ַ
	int length;//��ǰ����
	int listsize;//��ǰ����Ĵ洢����

}SqlList;
//��ʼ��
Status InitList_Sq(SqlList *L) 
{
	L->elem = (ElemType *)malloc(LIST_INIT_SIZE*(sizeof(ElemType)));
	//���Ϊ�գ�ջ���
	if (!L->elem)exit(OVERFLOW);
	L->length = 0;
	L->listsize = LIST_INIT_SIZE;

	return OK;
}
//����
Status ListInsert_Sq(SqlList *L,int i,ElemType e)
{
	//1.�ж�i�ĺϷ�ֵ����1��ʼ����ţ�
	if (i<1 || i>L->length + 1) 
		return ERROR;
	//2.�жϱ���û��
	if (L->length >= L->listsize) 
	{
		ElemType *newbase = (ElemType*)realloc(L->elem,(L->listsize + LISTINCRESEMENT)*sizeof(ElemType));
		//ָ���µ�ַ
		L->elem = newbase;
		
		if (!L->elem)return OVERFLOW;

		//�ڻ���ַ������L->listsize+LISTINCRESEMENT
		L->listsize += LISTINCRESEMENT;
	}

	ElemType *q= &(L->elem[i - 1]);
	ElemType *p;
		//���κ���
	for (p=&(L->elem[L->length-1]); p>=q; p--)
	{
		*(p + 1) = *p;
	}
	*q = e;
	++L->length;
	return OK;
}
//ɾ��
Status ListDelete_Sq(SqlList *L, int i)
{
	//1.�ж�i�ĺϷ�ֵ
	if (i<1 || i>=L->length + 1)
	{
		return ERROR;

	}
	//���ﲻ֪��Ϊʲô������ElemType
	ElemType *q= &(L->elem[L->length - 1]);
	ElemType *p;

	//����ǰ��
	for (p = &(L->elem[i - 1]); p <= q; p++)
	{
		*(p) = *(p+1);
	}
	
	--L->length;
	return OK;
}

//�Լ�д��
int LocateElem_Sq(SqlList *L,ElemType e)
{
	//���ҵ�������λ�ã����򣬷���0
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
//��
int LocateElem_Sq2(SqlList *L, ElemType e)
{
	//���ҵ�������λ�ã����򣬷���0
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
//�ϲ���La,Lb
Status MergeList(SqlList *La,SqlList *Lb,SqlList *Lc)
{
	//���ڴ�
	ElemType *Pa = La->elem;
	ElemType *Pb = Lb->elem;
	ElemType *Pc = Lc->elem;
	int LaLength = La->length;
	int LbLength = Lb->length;
	//�ṹ����ô���ڴ��д洢�ģ�
	Lc->listsize = Lc->length = LaLength + LaLength;
	Lc->elem = (ElemType *)malloc(Lc->listsize*(sizeof(ElemType)));
	//������ַ
	if (!Lc->elem) return OVERFLOW;

	//����鲢
	//����ȡֵ������*Pc
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
	SqlList La;// elem length listsize,�������Ա�Ļ�����Ϣ
	SqlList Lb;
	SqlList Lc;
	if (InitList_Sq(&La))
	{
		
	  printf("˳�����Ա��ʼ���ɹ�\n");
	}


	int operation = 1;

	
	while (operation)
	{
		printf("=======================================\n��ѡ�����:\n1.��������\n2.ɾ������\n3.��������\n4.�ϲ�˳���\n5.��ӡ˳���\n0.�˳�\n");
		scanf_s("%d", &operation);
		switch (operation)
		{
		case 1:
		{
				  printf("������һ�����Ա�Ԫ��(0Ϊ������):");
				  ElemType e;
				  int i = 1;
				  //����0��1
				  while (scanf_s("%d", &e))
				  {
					  if (e)
					  {
						  if (ListInsert_Sq(&La, i, e))
						  {

							  printf("����ɹ�....���������\n");
							  i++;
						  }
					  }
					  else
					  {
						  break;
					  }
				  }
				  printf("Ԫ�ز������......\n");

		}
			break;
		case 2:
		{
				  printf("������Ԫ�ص�λ�ã�\n");
				  int i = 0;
				  scanf_s("%d", &i);
				  if (ListDelete_Sq(&La, i)){
					  printf("ɾ���ɹ�.......\n");

				  }
				  else
				  {
					  printf("ɾ��ʧ��.......������Ԫ�ص�λ���Ƿ񳬳��˱�\n");

				  }
		}
			break;
		case 3:
		{
				  printf("������Ԫ��Ҫ���ҵ�Ԫ��:\n");
				  ElemType e;
				  scanf_s("%d",&e);
				  int i = 0;
				  if (i=LocateElem_Sq(&La, e))
				  {
					  printf("���ҳɹ�,λ��Ϊ%d",i);
				  }
				  else
				  {
					  printf("δ�ҵ�Ԫ��");
				  }
		}
			break;
		case 4:
		{
				  printf("�������ޣ�����չʾ");
		}
			break;
		case 5:
		{
				  printf("�������ޣ�����չʾ");
		}
			break;

		default:break;
		}
	}



	
	
}



