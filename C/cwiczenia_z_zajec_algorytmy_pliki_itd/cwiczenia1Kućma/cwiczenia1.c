#include <stdio.h>
 

void zad1_1()
{
	printf("Hello World!\n\n");
}

void zad1_2()
{
	int a, b;
	printf("Sprawdzanie zaleznosci miedzy liczbami, podaj pierwsza z nich:\n");
	if (scanf_s("%d", &a) < 1)
	{
		printf("Niepoprawne dane.");
		return;
	}
	printf("Podaj druga z tych liczb:\n");
	if (scanf_s("%d", &b) < 1)
	{
		printf("Niepoprawne dane.");
		return;
	}
	if (a == b)
	{
		printf("liczby sa sobie rowne\n");
	}
	else {
		if (a > b)
		{
			printf("Pierwsza liczba jest wieksza od drugiej liczby\n");
		}
		else
			printf("Druga liczba jest wieksza od pierwszej\n");
	}

	printf("Wypisywanie dwoch liczb \n Podaj a i b:\n");
	if (scanf_s("%d%d", &a, &b) < 2) {
		printf("Niepoprawne dane.");
		return;
	}
	printf("%d %d\n", a, b);
}
void zad1_3()
{
	int c, d;
	char op;
	printf("Podaj wyrazenie (liczba operacja liczba): \n");
	if (scanf_s("%d%c%d", &c, &op, sizeof(op), &d) < 3)
	{
		printf("Nieprawidlowe dane!");
		return;
	}
	if (op == '+')
	{
		printf("%d%c%d=%d\n", c, op, d, c + d);
	}
	if (op == '-')
	{
		printf("%d%c%d=%d\n", c, op, d, c - d);
	}
	if (op == '*')
	{
		printf("%d%c%d=%d\n", c, op, d, c * d);
	}
	if ((op == '/') && (d != 0))
	{
		printf("%d%c%d=%f\n", c, op, d, (float)c / d);
	}
}
void zad1_4()
{
	char imie[30], nazwisko[30];
	printf("Podaj swoje imie i nazwisko:");
	scanf_s("%s%s", imie, sizeof(imie), nazwisko, sizeof(nazwisko));
	printf("Witaj ");
	printf("%s %s\n", imie, nazwisko);
}
