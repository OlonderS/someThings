#include <stdio.h>
#include <ctype.h>
#include <math.h>
#include <conio.h>
#include "cwiczenia3.h"

void zad4_1()
{
	int n, k;
	int suma = 0;
	int j = 0;
	printf("Podaj liczbe wprowadzanych liczb: ");
	if (scanf_s("%d", &n) < 1 || ferror(stdin) || n < 1)
	{
		printf("Nieprawidlowe dane ");
		return;
	}
	for (int i = 1; i <= n; ++i)
	{
		printf("Podaj %d liczbe: ", i);
		if (scanf_s("%d", &k) < 1)
		{
			printf("Nieprawidlowe dane\n");
			--i;
			continue;
		}
		if (czy_doskonala(k))
		{
			suma = suma + k;
			++j;
		}
	}
	if (suma == 0)
	{
		printf("Nie ma takiej liczby ");
	}
	else
	{
		printf("Suma = %d, ich liczba to %d, a srednia to %f", suma, j, (float)suma/j);
	}
}

void zad4_2()
{
	int i = 0;
	printf("Podaj cyfry(enter aby zakonczyc): ");
	do
	{
		i = getchar();
		if ((i > 47) && (i < 58))
		{
			printf("%d ", i - 48);
		}
	} while (i != '\n');
}
void zad4_2_2()
{
	char c;
	do
	{
		c = _getch();
		if (isdigit(c))
			_putch(c);
	} while (c != '\t');
}
void zad4_3()
{
	int n, p, c;
	printf("Podaj dlugosc ciagu(n), pierwszy element(p) oraz wyraz wolny(c): ");
	if (scanf_s("%d%d%d", &n, &p, &c) < 3 || ferror(stdin) || n < 1)
	{
		printf("Nieprawidlowe dane ");
		return;
	}
	int x = p;
	for (int i = 1; i <= n; ++i)
	{
		printf("%d. wyraz ciagu: %d\n", i, x);
		x = 2 * x + c;
	}
}

void zad4_4()
{
	int n;
	long int i, j;
	i = 0;
	j = 1;
	printf("Podaj n: ");
	if (scanf_s("%d", &n) < 1 || ferror(stdin) || n < 1)
	{
		printf("Nieprawidlowe dane ");
		return;
	}
	for (n; n>0; --n)
	{
		printf("%ld ", j);
		j = j + i;
		i = j - i;
	}
}

int zad4_5(int a,int b)
{
	int tmp;
	if (a > b)
	{
		tmp = a;
		a = b;
		b = tmp;
	}
	if (b < 0)
	{
		printf("Bledny zakres");
		return 0;
	}
	if (a * a * a + 20 * a >= 33 * a * a + 370) //bez tego
	{
		printf("brak rozwiazania");
		return 0;
	}
	while (b * b * b + 20 * b >= 33 * b * b + 370) // && b>=a
	{	
		--b;									
	}
	// if ((a==b) && (b * b * b + 20 * b >= 33 * b * b + 370))
	//		return 0;
	printf("n=%ld", b);
	return b;
}

void zad4_6()
{
	int n = 1; //lepiej np n=1000
	while ((pow(1.02, n) <= (1000 * n * n)))
	{
		++n;
	}
	printf("Najmniejsze n to %d", n);
	return;
}

void zad4_7(int a, int b)
{
	if (a < 1 || b < 1)
	{
		printf("Nieprawidlowe dane ");
		return;
	}
	while ((a!=0) && (b!=0))
	{
		if (a > b)
		{
			a = a % b;
		}
		else
		{
			b = b % a;
		}
	}
	if (a == 0)
	{
		printf("Nwd to %d", b);
	}
	else
	{
		printf("Nwd to %d", a);
	}
}

void zad4_8()
{
	int x, y, i, j, k, m, tmp;
	int tab[20], tabp[20];
	x = y = i = j = k = m = tmp = 0;
	printf("Podaj liczbe: ");
	scanf_s("%d", &y);
	if (y == 0)
	{
		printf("%d", 0);
		return;
	}
	if (y < 0)
		x = -y;
	else
		x = y;
	while (x > 0)
	{	
		tabp[i] = x % 2;
		x = x / 2;
		++i;
	}
	while (m <= (i - 1) / 2)
	{
		tmp = tabp[m];
		tabp[m] = tabp[i - m - 1];
		tabp[i - m - 1] = tmp;
		++m;
	}
	if (i % 2 == 1)
	{
		tab[0] = 0;
		j = 1;
	}
	else
	{
		tab[0] = tab[1] = 0;
		j = 2;
	}
	for (int a = 0; a < i; ++a, ++j)
	{
		tab[j] = tabp[a];
	}
	if (y >= 0)
	{
		for (int a = 0; a < j; ++a)
		{
			printf("%d", tab[a]);
		}
		return;
	}
	if (y<0)
	{
		for (int a = 0; a < j; ++a)
		{
			if (tab[a] == 0)
			{
				tabp[a] = 1;
			}
			else
			{
				tabp[a] = 0;
			}
		}
		k = j;
		while (k>0)
		{
			if (tabp[k - 1] == 0)
			{
				tabp[k - 1] = 1;
				break;
			}
			else
			{
				tabp[k - 1] = 0;
				--k;
			}
		}
		for (int a = 0; a < j; ++a)
		{
			printf("%d", tabp[a]);
		}
	}
}