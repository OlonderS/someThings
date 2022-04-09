#include <stdio.h>
#include <stdlib.h>

void czytaj_plik(char* nazwa_pliku)
{
	FILE* fp;
	char buf[1000];
	if (fopen_s(&fp, nazwa_pliku, "r") != 0 || ferror(fp))
	{
		perror("Blad");
		return;
	}
	while (!feof(fp))
	{
		fgets(buf, sizeof(buf), fp);
		printf("%s", buf);
	}
	fclose(fp);
}
int zad5_5_5(char* buf)
{
	int w = 0;
	char* tmp = NULL;
	char* token = strtok_s(buf, " ,;?!.\t\n", &tmp);
	while (token)
	{
		if (strlen(token) >= 1)
			w++;
		token = strtok_s(NULL, " ,\t\n", &tmp);
	}
	return w;
}

void zad9_2(char* nazwa_pliku)
{
	FILE* fp;
	if (fopen_s(&fp, nazwa_pliku, "r") != 0 || ferror(fp))
	{
		perror("Blad");
		return;
	}
	int w = 0;
	int l = 0;
	char c;
	char buf[100];
	while (!feof(fp))
	{
		fgets(buf, sizeof(buf), fp);
		w += zad5_5_5(buf);
	}
	fseek(fp, 0, SEEK_SET);
	while (!feof(fp))
	{
		c = fgetc(fp);
		if (c != ' ' && c != '\n' && c != '\t')
			l++;
	}
	printf("Liczba znakow: %d; liczba slow: %d",l,  w);
}

void zad9_3(char* nazwa_pliku)
{
	FILE* fp;
	FILE* fp2;
	char buf[100];

	if ((fopen_s(&fp, nazwa_pliku, "r") != 0 || ferror(fp)) || (fopen_s(&fp2, "text2.txt", "w+") != 0 || ferror(fp2)))
	{
		perror("Blad");
		return;
	}
	while (!feof(fp))
	{
		fgets(buf, sizeof(buf), fp);
		if (buf[0] != '\n')
			fputs(buf, fp2);
	}
	fclose(fp);
	fclose(fp2);
}

void zad9_5(char* nazwa_pliku)
{
	FILE* fp;
	char buf[100];
	int r;
	if (fopen_s(&fp, nazwa_pliku, "r") != 0 || ferror(fp))
	{
		perror("Blad");
			return;
	}
	fseek(fp, 0, SEEK_END);
	r = ftell(fp);
	printf("Plik ma %d bajtow", r);
}

void zad9_4(char* nazwa_pliku)
{
	FILE* fp;
	char buf[100];
	char c;
	int n, m;
	n = m = 0;

	if (fopen_s(&fp, nazwa_pliku, "r") != 0 || ferror(fp))
	{
		perror("Blad");
		return;
	}
	do
	{
		c = fgetc(fp);
		if (isdigit(c))
		{
			n = c-48;
		}
	} while (!isdigit(c));
	do
	{
		c = fgetc(fp);
		if (isdigit(c))
		{
			m = c-48;
		}
	} while (!isdigit(c));
	if (n != m)
	{
		printf("bledne dane");
		return;
	}
	int** arr = (int**)malloc(n * sizeof(int*));
	for (int i = 0; i < n; i++)
		arr[i] = (int*)malloc(n * sizeof(int));
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			do
			{
				c = fgetc(fp);
			} while (!isdigit(c));
			arr[i][j] = c-48;
			printf("%d ", arr[i][j]);
		}
		printf("\n");
	}
	float ratio;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			if (j > i) {
				ratio = arr[j][i] / arr[i][i];
				for (int k = 0; k < n; k++) {
					arr[j][k] -= ratio * arr[i][k];
				}
			}
		}
	}
	float det = 1; 
	for (int i = 0; i < n; i++)
		det *= arr[i][i];
	printf("Wyznacznik: %.2f", det);
}

/*
typedef struct
{
	char nazwa[20];
	int glosy;
	int mandaty;
} Partia;

void test_partia()
{
	int mandaty = 20;
	int m[50];
	Partia A, B, C, D, E, F, G, H, I, J;
	A.nazwa = "PartiaA";
	B.nazwa = "PartiaB";
	C.nazwa = "PartiaC";
	D.nazwa = "PartiaD";
	E.nazwa = "PartiaE";
	F.nazwa = "PartiaF";
	G.nazwa = "PartiaG";
	H.nazwa = "PartiaH";
	I.nazwa = "PartiaI";
	J.nazwa = "PartiaJ";
	A.glosy = 1234;
	B.glosy = 234;
	C.glosy = 1897;
	D.glosy = 345;
	E.glosy = 2340;
	F.glosy = 102;
	G.glosy = 1023;
	H.glosy = 456;
	I.glosy = 1455;
	J.glosy = 109;
	for (int i = 0; i < 10; i++)
	{
		m[i] = 0;
	}
}
*/


