#include <stdio.h>
#include <ctype.h>
#include <string.h>
#include <stdlib.h>
#include <conio.h>
#include <math.h>
#include <time.h>
#define EPS 0.000001
#define f(x) 2*(x) - cos(x) -1
#define g(x) 2 + sin(x)
#define h(x) (x)*(x)*(x)-x+1
#define SWAP(x, y, type) type t; (t=x, x=y, y=t)
#define FUNC(x) (x)*(x)-1

double zad6_1()
{
	double min, max, mid;
	printf("Podaj min i max przedzia³u: ");
	if (scanf_s("%lf%lf", &min, &max) < 2 || ferror(stdin))
	{
		printf("Nieprawidlowe dane \n");
		return 0;
	}
	printf("%lf%lf", h(min), h(max));
	do
	{
		mid = (min + max) / 2;
		if ((h(mid) <= EPS) && (h(mid) >= -EPS))
		{
			printf("Pierwiastek to %.3lf", mid);
			return mid;
		}
		else if ((h(max)) * (h(mid)) < 0)
		{
			min = mid;
		}
		else
		{
			max = mid;
		}
	} while ((max - min) > EPS);
	printf("Pierwiastek to %.3lf", (max + min) / 2);
	return (max + min) / 2;
}

double zad6_1_1()
{
	double x0, x1, f0, f1, g0;
	x0 = 0;
	scanf_s("%lf", &x0);
	do
	{
		g0 = g(x0);
		f0 = f(x0);
		if (g0 == 0.0)
		{
			printf("Dzielenie przez 0 ");
			return 0;
		}
		x1 = x0 - f0 / g0;
		x0 = x1;
		f1 = f(x1);
	} while (fabs(f1) > EPS);

	printf("\nPierwiastek to: %.3f", x1);
	return x1;
}
double zad6_2(int n)
{
	double x = sqrt(2.0);
	double result = 1.0;
	for (int i = 1; i <= n; ++i)
	{
		result *= x/2;
		x = sqrt(x + 2);
	}
	return 2.0 / result;
}
double zad6_2_3(long int n)
{	
	float x, y;
	float k = 0;
	srand((rsize_t)time(0));
	for (int i = 1; i <= n; i++)
	{
		x = rand() / (float)RAND_MAX;
		y = rand() / (float)RAND_MAX;
		if (x * x + y * y <= 1) k++;
	}
	printf("pi = %.12lf", 4 * k / n);
	return 4 * k / n;
}
void zad6_3()
{
	double xp, xk, dx, calka, s, x;
	int n = 10;
	printf("Podaj poczatek i koniec przedzialu calkowania\n");
	scanf_s("%lf%lf", &xp, &xk);
	dx = (xk - xp) / (float)n;

	calka = 0;
	s = 0;
	for (int i = 1; i < n; i++) {
		x = xp + i * dx;
		s += FUNC(x - dx / 2);
		calka += FUNC(x);
	}
	s += FUNC(xk - dx / 2);
	calka = (dx / 6) * (FUNC(xp) + FUNC(xk) + 2 * calka + 4 * s);

	printf("Wartosc calki wynosi w przyblizeniu %lf\n", calka);
	return;
}
void zad6_3_2()
{
	int n = 10;
	double xp, xk, s, dx;
	int i;
	printf("Podaj poczatek i koniec przedzialu calkowania\n");
	scanf_s("%lf%lf", &xp, &xk);
	s = 0;
	dx = (xk - xp) / (float)n;
	for (i = 1; i < n; i++)
	{
		s += FUNC(xp + i * dx);
	}
	s = (s + (FUNC(xp) + FUNC(xk)) / 2) * dx;
	printf("Wartosc calki wynosi w przyblizeniu %lf\n", s);
	return;
}
void zad6_4()
{
	int a = 4;
	int b = 2;
	SWAP(a, b, int);
	printf("a= %d, b=%d", a, b);
}