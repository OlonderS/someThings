#include <stdio.h>
#include <math.h>

double silnia(int n)
{
	if (n <= 1)
	{
		return 1;
	}
	return n * silnia(n - 1);
}
double fib(int n)
{
	if (n < 3)
	{
		return 1;
	}
	return fib(n - 2) + fib(n - 1);
}

double ff(double x)
{
	return x * x - 2 * x + 1;
}

void test_ff(double(*ff)(double))
{
	int n = 2;
	double a = -3, b = 3, h = (b - a) / n;
	for (double x = a; x <= b; x += h)
	{
		printf("%f, %.9f\n", x, ff(x));
	}
}

double bisekcja(float(*f)(float), float p, float a, float b)
{
	if (a > b)
	{
		float tmp = a;
		a = b;
		b = tmp;
	}
	if ((*f)(a) * (*f)(b) > 0)
	{
		return -1.0;
	}
	float x = (*f)((b + a) / 2);
	if (abs(x) < p) 
	{
		return ((double)b + a) / 2.0;
	}
	return x ? bisekcja(f, p, (b + a) / 2, b) : bisekcja(f, p, a, (b + a) / 2);
}

int dec2bin(int x)
{
	if (x == 0)
	{
		return 0;
	}
	else
	{
		return (x % 2 + 10 * dec2bin(x / 2));
	}
}

int len_of_str(char* str)
{
	if ((*str == '\0'))
	{
		return 0;
	}
	else
	{
		return 1 + len_of_str(str + 1); //wskaznik na kolejna litere
	}
}

int upper(char* arr, int size, int n)
{
	if (arr[n] <= 'Z' && arr[n] >= 'A')
	{
		return n;
	}
	if (n >= size)
	{
		return -1;
	}
	return upper(arr, size, n + 1);
}