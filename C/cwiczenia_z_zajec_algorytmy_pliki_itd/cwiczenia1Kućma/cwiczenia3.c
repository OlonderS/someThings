#include <stdio.h>
#include <math.h>
#include <string.h>


int czy_parzysta(int x)
{
	return x % 2 == 0;
}

void test_czy_parzysta()
{
	int a;
	printf("Podaj a: ");
	if (scanf_s("%d", &a) < 1 || ferror(stdin))
	{
		printf("Nieprawidlowe dane.\n");
		return;
	}
	printf("Liczba %d jest %s\n", a, czy_parzysta(a) ? "parzysta" : "nieparzysta");
}

void test_sprintf()
{
	int a;
	char buf[10];
	printf("Podaj a: ");
	if (scanf_s("%d", &a) < 1 || ferror(stdin))
	{
		printf("Nieprawidlowe dane.\n");
		return;
	}
	sprintf_s(buf, sizeof(buf), "%d", a);
	printf("%s\n%c\nliczba cyfr: %d", buf, buf[0], strlen(buf));
}


int czy_potega_dwojki(int x)
{
	int a = 1;
	while (a < x)
	{
		a = a * 2;
	}
	return a == x;

}

int czy_doskonala(int x)
{
	int suma = 0;
	for (int i = 1; i <= x / 2; ++i)
	{
		if ((x % i) == 0)
		{
			suma += i;
		}
	}
	return suma == x;
}

int czy_automorficzna(int x)
{
	char buf[10], buf2[20];
	int lena, lena2;
	sprintf_s(buf, sizeof(buf), "%d", x);
	lena = strlen(buf);
	sprintf_s(buf2, sizeof(buf2), "%d", x * x);
	lena2 = strlen(buf2);
	for (int i = lena - 1, j = lena2 - 1; i >= 0; --i, --j)
	{
		if (buf[i] != buf2[j])
		{
			return 0;
		}
	}
	return 1;
}

int czy_armstronga(int x)
{
	/*int i = 0;
	int suma = 0;
	int buf[10];
	while (x > 0)
	{
		buf[i] = x % 10;
		i++;
		x = x / 10;
	}*/
	int i=0;
	int suma = 0;
	char buf[10];
	sprintf_s(buf, sizeof(buf), "%d", x);
	i = strlen(buf);
	for (int j = 0; j < i; j++)
	{
		suma = suma + pow((buf[j]-48), (int)i); //ascii
	}
	return suma == x;
}

int czy_zaprzyjaznione(int x, int y)
{
	int suma = 0;
	int suma2 = 0;
	for (int i = 1; i <= x / 2; ++i)
	{
		if ((x % i) == 0)
		{
			suma += i;
		}
	}
	if (suma == y)
	{
		for (int i = 1; i <= y / 2; ++i)
		{
			if ((y % i) == 0)
			{
				suma2 += i;
			}
		}
	}
	return suma == y && suma2 == x;
}

int czy_pierwsza(int x)
{
	if ((x < 2) || (x%2==0)) { return 0; }
	for (int i = 3; i <= sqrt(x); i+=2)
	{
		if (x%i == 0) {return 0; }
	}
	return 1;
}
void test_czy_pierwsza()
{
	int a;
	printf("Podaj a: ");
	if (scanf_s("%d", &a) < 1 || ferror(stdin))
	{
		printf("Nieprawidlowe dane.\n");
		return;
	}
	printf("Liczba %d jest %s\n", a, czy_potega_dwojki(a) ? "taka" : "nie taka");
}
void test_czy_zaprzyjaznione()
{
	int a, b;
	printf("Podaj a i b: ");
	if (scanf_s("%d%d", &a, &b) < 2 || ferror(stdin))
	{
		printf("Nieprawidlowe dane.\n");
		return;
	}
	printf("Liczby %d i %d %s\n", a, b, czy_zaprzyjaznione(a, b) ? "sa zaprzyjaznione" : "nie sa zaprzyjaznione");
}
