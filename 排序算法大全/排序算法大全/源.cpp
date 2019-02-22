#include<iostream>
#include<cstdlib>

using namespace std;
void InsertSort(int a[], int n)
{
	//第一层循环  i取 1到n-1
	for (int i = 1; i < n; i++)
	{
		//k取0到i-1
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
				1.有序数列向后推
				2.记住对比数
				3.对比数塞进与之对比的数的位置
				}

				*/
				int X = a[i];
				//l取 i-1到k
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
	//从1 到n-1
	for (int  i = 1; i < n; i++)
	{
		//如果前一项大于后一项进行插入
		if (a[i - 1]>a[i])
		{
			//复制为哨兵
			int temp =a[i];
			//从i-1项依次向后移动，直到小于temp项为止
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



排好序列的数列中最后一个一定是最大的
让a[i]与a[i-1]
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