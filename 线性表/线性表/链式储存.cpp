#include <iostream>
#include<cstdlib>
using namespace std;
#define dataType int


/*
���Ա�a1,a2,a3.....an
a1����ֻ��һ�����Ԫ�� 
an����ֻ��һ��ǰ��Ԫ��
*/


typedef  struct Node
{
	struct  Node *next;
	dataType data;

}Node;

Node* Create()
{
	Node *head, *p, *q;
	dataType a;
	p = new Node;
	head = p;
	cout << "�����룺0Ϊ��ֹ" << endl;


	while (cin >> a)
	{
		if (a)
		{
			p->data = a;
			q = new Node;
			p->next = q;
			p = q;

		}
		else
		{
			p->next = NULL;
			break;

		}



	}
	cout << "�������" << endl;
	return head;

}

void Print(Node *head)
{
	//ѭ�������ֱ��nextΪ��
	
	//��head �����ɸ���p ��Ȼ�ڽ��� head=head-next����ʱ����ֱ�Ӷ�head �����˲������ͻᶪʧ��ͷָ��	
	Node *p = head;
	if (p->next == NULL)
	{
		cout << "���Ա���������" << endl;
	}
	else
	{
		while (p->next != NULL)
		{
			cout << p->data << endl;
			p = p->next;
		}
	}
		
}

void Insert(Node* head,int i,dataType data)
{
	Node *p = head;
	Node *temp=new Node;
	Node *q;
	int index = 0;
	if (p->next == NULL)
	{
		cout << "���Ա���������" << endl;
	}
	else
	{
		while (p->next != NULL)
		{
			if (index == i)
			{
				//������Ʋ���
				q = new Node;
				temp->next = q;
				q->data = data;
				q->next = p;
				
				break;
			}
			i++;
			p = p->next;
			temp = p;
		}
	}

}



int main()
{

	Node* head= Create();
	Print(head);
	Insert(head,2,20);
	Print(head);
	system("pause");
	return 0;
}

