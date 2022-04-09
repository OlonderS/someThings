#include <stdio.h>
#include <math.h>
#define PI 3.14159


void zad2_1()
{
	int a, b;
	char op;
	printf("Podaj wyrazenie (liczba1 znak liczba2): \n");
	if (scanf_s("%d%c%d", &a, &op, sizeof(op), &b) < 3)
	{
		printf("Nieprawidlowe dane!\n");
		return;
	}
	switch (op)
	{
	case '+':
		printf("%d%c%d=%d\n", a, op, b, a + b);
		break;
	case '-':
		printf("%d%c%d=%d\n", a, op, b, a - b);
		break;
	case '*':
		printf("%d%c%d=%d\n", a, op, b, a * b);
		break;
	case '/':
		if (b != 0)
			printf("%d%c%d=%f\n", a, op, b, (float)a / b);
		else
			printf("Nie dziel przez 0\n");
		break;
	default:
		printf("Podaj poprawny znak\n");
		break;
	}
}

void zad2_2()
{
	int a, b, c;
	printf("Podaj 3 liczby: \n");
	if (scanf_s("%d%d%d", &a, &b, &c) < 3)
	{
		printf("Za ma³o liczb!\n");
		return;
	}
	if (a > b)
	{
		if (a > c)
			printf("%d jest najwieksze\n", a);
		else
			printf("%d jest najwieksze\n", c);
	}
	else 
	{
		if (b > c)
			printf("%d jest najwieksze\n", b);
		else
			printf("%d jest najwieksze\n", c);
	}

}

int zad2_3(int a)
{
	if (a < 0)
		return -1;
	if (a > 0)
		return 1;
	else
		return 0;
}

int zad2_4(int a)
{
	return(a > 0) ? 1 : (a < 0) ? -1 : 0;
}

void zad2_5()
{
	double a, b, c, x0, x1, x2, pierw_delta;
	printf("Podaj wspolczynniki: \n");
	if (scanf_s("%lf%lf%lf", &a, &b, &c) < 3)
	{
		printf("Podaj wszystkie wspolczynniki\n");
		return;
	}
	if (a == 0)
	{
		if (b != 0)
		{
			x0 = -(c) / b;
			printf("x0 = %.2lf", x0);
			return;
		}
		else
			printf("brak rzeczywistych rozwiazan");
			return;
	}
	pierw_delta = sqrt(b * b - 4 * a * c);
	if (pierw_delta > 0)
	{
		x1 = ((-b) - pierw_delta) / (2 * a);
		x2 = ((-b) + pierw_delta) / (2 * a);
		printf("x1 = %.2lf, x2 = %.2lf", x1, x2);
	}
	else if (pierw_delta == 0)
	{
		x0 = (-b) / (2 * a);
		printf("x0 = %.2lf", x0);
	}
	else
		printf("brak rzeczywistych rozwiazan");
	return;
}

float zad2_6()
{
	float tab[3][4];
	float a, x, y, z;
	printf("Podaj wspolczynniki ukladu rownan z 3 niewiadomymi (x | y | z | wyraz_wolny: \n");
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			if (scanf_s("%f", &tab[i][j]) < 1)
			{
				printf("Podaj liczbe\n");
				return 0;
			}
		}
		printf("\n");
	}
	for (int k = 0; k < 3; k++)
	{
		for (int i = 0; i < 2 - k; i++)
		{
			a = tab[i + k + 1][k] / tab[k][k];
			for (int j = 0; j < 4 - k; j++)
			{
				tab[i + k + 1][j + k] = tab[i + k + 1][j + k] - a * tab[k][j + k];
			}
		}
	}
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			printf("%.2f ",tab[i][j]);
		}
		printf("\n");
	}
	z = tab[2][3] / tab[2][2];
	y = (tab[1][3] - z * tab[1][2]) / tab[1][1];
	x = (tab[0][3] - y * tab[0][1] - z * tab[0][2]) / tab[0][0];
	printf("x=%.2f, y=%.2f, z=%.2f\n", x, y, z);
	return x, y, z;
}

double zad2_7(int wybor)
{
	double r, H, obj, pole;
	r = H = 0;
	switch (wybor)
	{
	case 0: //kula
		printf("Podaj promien kuli: \n");
		if (scanf_s("%lf", &r) < 1)
		{
			printf("Bledne dane\n");
			return 0;
		}
		obj = 4 / 3 * PI * pow(r, 3);
		pole = 4 * PI * r * r;
		printf("Pole kuli wynosi: %lf\nObjetosc wynosi: %lf\n", pole, obj);
		return pole, obj;
	case 1: //stozek
		printf("Podaj promien podstawy oraz wysokosc stozka: \n");
		if (scanf_s("%lf%lf", &r, &H) < 2)
		{
			printf("Bledne dane\n");
			return 0;
		}
		obj = PI * r * r * H / 3;
		pole = PI*r*r + PI*r*sqrt(r*r+H*H);
		printf("Pole stozka wynosi: %lf\nObjetosc wynosi: %lf\n", pole, obj);
		return pole, obj;
	case 2: //walec
		printf("Podaj promien podstawy i wysokosc walca: \n");
		if (scanf_s("%lf%lf", &r, &H) < 2)
		{
			printf("Bledne dane\n");
			return 0;
		}
		obj = PI*r*r*H;
		pole = 2*PI*r*r + 2*PI*r*H;
		printf("Pole walca wynosi: %lf\nObjetosc wynosi: %lf\n", pole, obj);
		return pole, obj;
	}
	return 0;
}