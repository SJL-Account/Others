#include<iostream>
#include<cstdlib>

using namespace std;
void ShellInsertSort(int a[], int n)
{

	int gap = n;
	//��ʼ����
	//��ֹ����
	//ѭ������
	do{

		gap = gap / 3 + 1;

		//��gap ��n-1   0 1 2 3 4 5 6
		for (int i = gap; i < n; i+=gap)
		{
			//���ǰһ����ں�һ����в���
			if (a[i - gap]>a[i])
			{
				//����Ϊ�ڱ�
				int temp = a[i];
				//��i-1����������ƶ���ֱ��С��temp��Ϊֹ
				int k;
				for (k = i - gap; k > -1&& a[k] > temp; k -= gap)
				{
					a[k + gap] = a[k];
				}

				a[k + gap] = temp;

			}
		}
	} while (gap > 1);


	//ϣ������
	//�� ��������i 
	// ����������϶gap
	// ������������ k






	//��¼���߰���
	//û�п�ѧ�Ĺ���
	
	//��һ������������һ����(����̰��)
	//ע����������
	//������ȥ˼��
	//





}



int main()
{
	int a[8] = { 9, 5435, 7, 4, 5, 3645, 6, 0 };

	int n = sizeof(a) / sizeof(int);

	ShellInsertSort(a, 8);

	for (int i = 0; i < 8; i++)
	{
		cout << a[i] << endl;
	}

	system("pause");


}
/*
1 2 3 4 5 6 7 8 9 10\


8 4 5 2 10 45 23 3

8   5
5 4 8 2 10 45 23 3

4   2
5 2 8 4 10 45 23 3

10  8
5 2 8 4 10 45 23 3
45  4
5 2 8 4 10 45 23 3

23  10
5 2 8 4 10 45 23 3

3   45
5 2 8 4 10 3 23 45

5 2
2 5 8 4 10 3 23 45

8 5
2 5 8 4 10 3 23 45

8 4

2 5 4 8 10 3 23 45

8 10

2 5 4 8 10 3 23 45

i+gap<n;

 1,5,3,4,6,34,12



*/



