/*
�ṹ��:����������
struct NAME
{

};

NAME name1,name2...
NAME *p;
�ṹ����������ͽ������ڴ�ķ���:��ջ��

�������ñ���������
name.NO1
*p.NO1
p->N01
*/

#include "structHead.h"
typedef int ElemType;

typedef struct Node{
	ElemType data;
	//Ϊʲô��ô����
	struct Node *next;

}LNode, *LinkList;


//�����������
LinkList CreateListHead()
{

	LinkList p, q;
	//����������ֲ���
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

//����ɾ��
Status DelList(LinkList L)
{
	LinkList p = L->next;
	LinkList q;
	//����ɾ������ͷ�����
	//ѭ����������
	//�ͷŵ�ַ
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
	//��ͷ���Ѱ�ң�һֱ��i-1;

	int j = 1;
	while (p&&j < i)					//1. p->L j=1;(++)  ->  2.p->a1 j=2  (++)  -> 3.p->a2 j=3  (++)  -> 4.p=a3 j=4 (++)  -> 5.p=a4 j=5
	{
		//����ѭ��ʱ��pΪi-1�ĵ�ַ
		p = p->next;
		j++;
	}

	if (!p/*����������Ľ�β*/ || j>i)
	{
		return ERROR;
	}

	/*
	�ҵ�i������i-1����ַ
	*/
	LinkList q = p->next;

	//����newbase
	LinkList newbase = (LinkList)malloc(sizeof(LNode));
	if (!newbase)exit(OVERFLOW);
	newbase->data = e;
	//�ҵ�i-1Ԫ�أ�ʹ��next =newbase
	p->next = newbase;
	//�ҵ�iԪ�صĵ�ַp��ʹnewbase->next=p
	newbase->next = q;

	return OK;
}

Status ListDel_L(LinkList L, int i)
{
	//1.��֤�û�����
	if (i<1 || i>length(L))return ERROR;
	//2.������

	int j = 1;
	LinkList p = L;
	while (p&&j < i)
	{
		//����ʱ��j=i-1; pָ��i��λ��
		p = p->next;
		j++;
	}
	LinkList q = p->next;
	p->next = q->next;

	free(q);
	//3.���ؽ��
	return OK;
}

void ListPrint(LinkList L)
{
	LinkList p;
	p = L->next;
	//���ָ��ͷָ���ͷ����nextΪ��,�򲻴��ڡ�
	if (!p)
	{
		printf("����û������");
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
	//ѭ���������
	//ѭ������n
	//�ƽ�����i
	//��ֹ����j �ж��ٷ���j�������ͷ����˶��ٴ�ѭ�� ��ʼֵ--�������������һ��ֵ(������������ǰһ��ֵ)
	//�ƽ�����->ѭ��������ֵ�����ı�	
	//��i��n�ĺ���
	//����ѭ��ʱ��ִ����i�Σ�i=i+increasement
	//��ʼ����
	//ѭ������
	//����


}

int GetElem(LinkList L, ElemType e)
{
	//��֤

	//����
	//LΪͷ���
	LinkList p = L->next;

	//ѭ��  
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

	//���ؽ��
}

int mainTwo()
{
	//
	//����
	//for (int i = 0; i < 6; i++)
	//{
	//	//i��ѭ���ڵ�ȡֵΪ0-5
	//	//����ִ����6��
	//	//����ѭ��ʱ,i=6
	//	
	//}
	//int i=0;
	//while (i<6)
	//{
	
	//	//i��ѭ���ڵ�ȡֵΪ0-5
	//	//����ִ����6��
	//	//����ѭ��ʱ,i=6
	//	i++;
	//}

	//int i = 0;
	//do
	//{
	//	//i��ѭ���ڵ�ȡֵΪ1-5
	//	//����ִ����5��
	//	//����ѭ��ʱ,i=6
	//	i++;
	//} while (i<6);


	LinkList L;
	if (L = CreateListHead())
	{
		printf("�����ɹ�%p\n", L);

	}

	int operation = 1;

	ListPrint(L);
	while (operation)
	{
		printf("=======================================\n��ѡ�����:\n1.��������\n2.ɾ������\n3.��������\n4.��������\n5.��ӡ��ǰ��\n0.�˳�\n");
		scanf_s("%d", &operation);
		switch (operation){
		case 1:{
				   printf("������Ҫ���������:");
				   ElemType e;
				   scanf_s("%d",&e);
				   printf("����������λ��:");
				   int i = 0;
				   scanf_s("%d",&i);
				   if(ListInsert_L(L, i, e))
				   {
					   printf("����ɹ�");
				   }
					else
					{
						printf("����ʧ��");
					}

				   ListPrint(L);
		}
			break;
		case 2:{
				   printf("������Ҫɾ����λ��:");
				   int i = 0;
				   scanf_s("%d",&i);
				   if (ListDel_L(L, i))
				   {
					   printf("ɾ���ɹ�");
				   }
				   else

				   {
					   printf("ɾ��ʧ��");
				   }
				   ListPrint(L);
		}
			break;
		case 3:{
				   printf("������Ҫ���ҵ���Ԫ��:\n");
				   ElemType e;
				   int i = 0;
				   scanf_s("%d",&e);
				   if (i = GetElem(L, e))
				   {
					   printf("���ҳɹ�,λ��Ϊ%d",i);

				   }
				   else
				   {
					   printf("����ʧ��..");
				   }
		}
			break;
		case 4:
		{
				  if (DelList(L))
				  {
					  printf("����������");
				  }
				  else
				  {
					  printf("����δ�ɹ�");
				  }
				  system("pause");
				  exit(0);
		}
			break;


		case 5:{
				   printf("��ǰ��Ϊ:%d", length(L));

		}
			break;
		default:break;
		}

	}



}

