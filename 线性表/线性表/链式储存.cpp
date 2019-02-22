#include <iostream>
#include<cstdlib>
using namespace std;
#define dataType int


/*
线性表：a1,a2,a3.....an
a1有且只有一个后继元素 
an有且只有一个前驱元素
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
	cout << "请输入：0为终止" << endl;


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
	cout << "创建完成" << endl;
	return head;

}

void Print(Node *head)
{
	//循环输出，直到next为空
	
	//将head 拷贝成副本p 不然在进行 head=head-next操作时，就直接对head 进行了操作，就会丢失了头指针	
	Node *p = head;
	if (p->next == NULL)
	{
		cout << "线性表内无内容" << endl;
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
		cout << "线性表内无内容" << endl;
	}
	else
	{
		while (p->next != NULL)
		{
			if (index == i)
			{
				//插入后推操作
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

