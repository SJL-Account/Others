#include<iostream>
#include<cstdlib>

using namespace std;
void InsertSort(int a[], int n)
{
	//��һ��ѭ��  iȡ 1��n-1
	for (int i = 1; i < n; i++)
	{
		//kȡ0��i-1
		for (int k = 0; k < i; k++)
		{
			if (a[i]>a[k])
			{
				//{ k->next }
				continue;
			}
			else
			{
				/*{
				1.�������������
				2.��ס�Ա���
				3.�Ա���������֮�Աȵ�����λ��
				}

				*/
				int X = a[i];
				//lȡ i-1��k
				for (int l = i - 1; l >= k; l--)
				{
					a[l + 1] = a[l];

				}
				a[k] = X;
			}
		}
	}

}


void StraightInsertSort(int a[], int n)
{
	//��1 ��n-1
	for (int  i = 1; i < n; i++)
	{
		//���ǰһ����ں�һ����в���
		if (a[i - 1]>a[i])
		{
			//����Ϊ�ڱ�
			int temp =a[i];
			//��i-1����������ƶ���ֱ��С��temp��Ϊֹ
			int k;
			for (k= i-1; a[k]>temp; k--)
			{
				a[k + 1] = a[k];
			}
			a[k + 1] = temp;
			



		}
	}
}
int main()
{
	int a[8] = {34,2,45,4,5,3,56,0};

	int n = sizeof(a) / sizeof(int);

	StraightInsertSort(a, n);
	
	for (int i = 0; i < n; i++)
	{
		cout << a[i] << endl;
	}

	system("pause");
	 

}

/*
0 8 i-1

1 2 k



a[i-1]<a[i]



�ź����е����������һ��һ��������
��a[i]��a[i-1]
82645371
2 8 6 5 4 3 7 1

a[k] <a[i]
{

}
26854371
25684371 


	if(a>b) 
 
	else

	int m = 0;
	if (a[i] < a[i - 1])
	{
	m = i + 1;


	}



*/