#include <stdio.h>
#include <string.h>
#include <math.h>
#include "cwiczenia1.h"
#include "cwiczenia2.h"
#include "cwiczenia3.h"
#include "cwiczenia4.h"
#include "cwiczenia5.h"
#include "cwiczenia6.h"
#include "cwiczenia7.h"
#include "cwiczenia8.h"
#include "cwiczenia9.h"
//#include "cwiczenia10.h"
void swap(int* a, int* b)
{
	int t;
	t = *a;
	*a = *b;
	*b = t;
	printf("a=%d, b=%d", *a, *b);
}

int pierwsza(int x)
{
	if ((x < 2) || (x % 2 == 0)) { return 0; }
	for (int i = 3; i <= sqrt(x); i += 2)
	{
		if (x % i == 0) { return 0; }
	}
	return 1;
}

int nwdd(int a, int b)
{
	int t;
	while (b > 0)
	{
		t = b;
		b = a % b;
		a = t;
	}
	return a; 
}
int tworzenie_tab(int n)
{

	int** a = (int**)malloc(n * sizeof(int*)); // rezerwujemy miejsce w pamieci //** - dwuwymiarowa  //tablica tablic jednowymiarowych
	for (int i = 0; i < n; i++)
	{
		a[i] = (int)malloc(n * sizeof(int)); //rezerwujemy pamiec na kazdy wiersz
	}
	srand((size_t)time(0)); //inicjalizacja generatora liczb losowych
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			a[i][j] = rand() % 2981 + 20;
			printf(" %d", a[i][j]);
		}
		printf("\n");
	}
	printf("\n");
	return a;
}

void pamiec(int** a, int n)
{
	for (int i = 0; i < n; i++)
	{
		free(a[i]); //zwolnienie pamieci
	}
	free(a); //zwolnienie pamieci
}
int zad1_402585(int** a, int n)
{
	int x = 0;
	int max = 20;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{  
			/*
			if (czy_pierwsza(a[i][j]) == 1)
			{
				x=1;
			}
			else if (NWD(a[i][j], 15) == 3)
			{
				x=2;
			}
			else if (a[i][j] % 4 == 0)
			{
				x=3;
			}
			switch (x)
			{
			case 1:
				++a[i][j];
				break;
			case 2:
				a[i][j] *= 2;
				break;
			case 3:
				a[i][j] = 0;
			default:
				break;
			} */
			if (pierwsza(a[i][j]) == 1)
			{
				++a[i][j];
			}
			else if (nwdd(a[i][j], 15) == 3)
			{
				a[i][j] = a[i][j]*2;
			}
			else if (a[i][j] % 4 == 0)
			{
				a[i][j] = 0;
			}
			if (a[i][j] > max)
			{
				max = a[i][j];
			}
		}
	}
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			printf(" %d", a[i][j]);
		}
		printf("\n");
	}
	printf("\n");
	printf("najwieksza to: %d", max);
	return max;
}

void zad22()
{
	int a, m, n;
	printf("podaj 3 liczby: ");
	if (scanf_s("%d%d%d", &a, &m, &n) < 3 || ferror(stdin) || m<0 || n<0|| a<10|| a>31256236316)
	{
		printf("zle dane");
		return;
	}
	printf("%d\n", a);
	char buf[100];
	sprintf_s(buf, sizeof(buf), "%d", a);
	char* b = _strdup(buf);
	int len = strlen(buf);
	for (int i = 0; i < m/2; i++)
	{
		swap(buf[i], buf[m-1 - i]);
	}
	for (int i = m - 1; i < (len - n-m) / 2; i++)
	{
		swap(buf[i], buf[len - 1 - n]);
	}	
	int j = 0;
	for (int i = len - n; i < (len-(len - n)) / 2; i++, j++)
	{
		swap(buf[i], buf[len-j]);
	}
	printf("%d\n", buf[0]);
	printf("%d\n", atoi(buf));
	int k = 0;
	while (b[k] == buf[k])
		k++;
	if (b[k] > buf[k])
		printf("stara wieksza");
	else
		printf("nowa wieksza");


}


int main(int argc, char* argv[])
{
	//if (argc > 1) //argv[1]
	//char* nazwa = "text.txt";//albo sciezka bezwzgledna
		//zad9_4(nazwa);
	//Osoba osoba1 = { "", "", "", 0 };
	//zad10_2(osoba1);
	//zad10_2_2(osoba1);
	//zad10_3();

	/*int n;
	printf("Podaj n: ");
	if (scanf_s("%d", &n) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
		return;
	}
	int a = tworzenie_tab(n);
	zad1_402585(a, n);*/
	int x = -3;
	x <= -1 ? printf("pierwszy") : x > 1 ? printf("trzeci") : printf("drugi");


	return 0;
}
