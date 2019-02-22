#include<stdio.h>
#include<stdlib.h>


/*
f(n)= 0 n=0;
f(n)=1 n=1;
f(n)=(n-1)+(n-2) n>1

*/
int Fbi(int i)
{
	if (i < 2)
	{
		return i == 0 ? 0 : 1;
	}
	return Fbi(i - 1) + Fbi(i - 2);
}

int main1()
{
	for (int  i = 0; i < 20; i++)
	{
		printf("%d\n",Fbi(i));
	}
	getchar();

}

