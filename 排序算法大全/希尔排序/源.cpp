#include<iostream>
#include<cstdlib>

using namespace std;
void ShellInsertSort(int a[], int n)
{

	int gap = n;
	//起始条件
	//终止条件
	//循环变量
	do{

		gap = gap / 3 + 1;

		//从gap 到n-1   0 1 2 3 4 5 6
		for (int i = gap; i < n; i+=gap)
		{
			//如果前一项大于后一项进行插入
			if (a[i - gap]>a[i])
			{
				//复制为哨兵
				int temp = a[i];
				//从i-1项依次向后移动，直到小于temp项为止
				int k;
				for (k = i - gap; k > -1&& a[k] > temp; k -= gap)
				{
					a[k + gap] = a[k];
				}

				a[k + gap] = temp;

			}
		}
	} while (gap > 1);


	//希尔排序
	//动 驱动索引i 
	// 驱动索引间隙gap
	// 驱动后推索引 k






	//记录乱七八糟
	//没有科学的过程
	
	//干一件事总想着另一件事(过于贪心)
	//注意力不集中
	//不动脑去思考
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



