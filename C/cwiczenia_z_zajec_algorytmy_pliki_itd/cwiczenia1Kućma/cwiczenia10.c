#include <stdio.h>

typedef struct
{
	char imie[20];
	char nazwisko[20];
	char data[20];
	unsigned long long int pesel;
}Osoba;

void zad10_2(Osoba* osoba1)
{
	printf("Podaj imie, nazwisko, date urodzenia i pesel: ");
	if (scanf_s("%s%s%s%lld", osoba1->imie, sizeof(osoba1->imie), osoba1->nazwisko, sizeof(osoba1->nazwisko), osoba1->data, sizeof(osoba1->data), osoba1->pesel) < 4 || ferror(stdin))
	{
		printf("Bledne dane");
		return;
	}
}

void zad10_2_2(Osoba osoba1)
{
	printf("Imie: %s\nNazwisko: %s\nData urodzenia: %s\n Pesel: %lld\n", osoba1.imie, osoba1.nazwisko, osoba1.data, osoba1.pesel);
}

void zad10_3()
{
	FILE* fp;
	Osoba *arr[5];
	for (int i = 0; i < 5; i++)
	{
		printf("Osoba %d\n", i);
		zad10_2(arr[i]);
	}
	fopen_s(&fp, "out.binary", "wb");
	if (!feof(fp))
	{
		for (int i = 0; i < 5; i++)
		{
			fwrite(&arr[i], sizeof(Osoba), 1, fp);
		}
	}
	fclose(fp);
}

void zad10_4()
{
	FILE* fp;
	Osoba arr[5];
	fopen_s(&fp, "out.binary", "rb");
	for (int i = 0; i < 5; i++)
	{
		while(fread(&arr[i], sizeof(Osoba), 1, fp))
			zad10_2_2(arr[i]);
	}
	fclose(fp);
}

void zad10_5()
{
	FILE* fp;
	Osoba arr;
	Osoba tmp;
	int n = 0;
	fopen_s(&fp, "out.binary", "rb");

}