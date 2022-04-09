#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#define SWAP(x, y, type) type t; (t=x, x=y, y=t)


void zad7_1(int* tab, int n)
{
	int koniec;
	do
	{
		koniec = 0;
		for (int i = 0; i < n-1; i++)
		{
			if (tab[i] > tab[i + 1])
			{
				SWAP(tab[i], tab[i + 1], int);
				++koniec;
			}
		}
	} while (koniec != 0);
}

void zad7_2(int** tab, int n, int m)
{
	for (int i = 0; i < n * m-1;i++)
	{
		for (int j = 0; i < n*m -i-1;j++)
		{
			if (tab[j/m][j%m] > tab[(j + 1)/m][(j+1)%m])
			{
				SWAP(tab[j / m][j % m], tab[(j + 1) / m][(j + 1) % m], int);
			}
		}
	}
}

void zad7_3(int* tab1, int* tab2, int m, int n)
{
	int* copy = (int*)malloc(n * sizeof(int));
	for (int i = 0; i < m; i++)
	{
		copy[i] = tab1[i];
	}
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - i - 1; j++)
		{
			if (tab1[j] > tab1[j + 1])
			{
				SWAP(tab1[j], tab1[j + 1], int);
				//SWAP(copy[j], copy[j + 1], int); // powoduje blad??
			}
		}
	}
}

void insert_sort(int* arr, int n) 
{
	int tmp;
	for (int i = 0; i < n - 1; ++i)
	{
		int tmp = i;
		for (int j = i + 1; j < n; j++)
			if (arr[j] < arr[tmp])
				tmp = j;
		SWAP(arr[i], arr[tmp], int);
	}
}

/*void zad7_4(int* tab1, int m)
{
	int k = (int)sqrt(sizeof(tab1) / sizeof(int));
	int** tab2 = (int**)malloc(k * sizeof(int*)); 
	int x = ceil((float)m / k);
	for (int i = 0; i < x; ++i)
	{
		tab2[k] = (int*)malloc(x * sizeof(int));
	}
	int r=m%k;
	for (int i = 0; i < r; i++)
	{
		for (int j = 0; j < x; j++)
		{
			tab2[i][j] = tab1[i * j + j];
		}
	}
	for (int i = r; i < k; i++)
	{
		for (int j = 0; j <= m / k; j++)
		{
			tab2[i][j] = tab1[i * j + j];
			printf("%d ", tab2[i][j]);
		}
		printf("\n");
	}
}*/ //do poprawy 

