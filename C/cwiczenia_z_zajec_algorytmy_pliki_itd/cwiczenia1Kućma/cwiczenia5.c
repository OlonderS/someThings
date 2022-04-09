#include <stdio.h>
#include <math.h>
#include <string.h>
#include <ctype.h>
#include <conio.h>
#include <stdlib.h>
#define SIZE 100


int zad5_1(int a) {
	char buf[100];
	sprintf_s(buf, sizeof(buf), "%d", a);

	char* b = _strdup(buf);
	b = _strrev(b);
	int wynik = strcmp(b, buf);
	free(b);
	return wynik == 0;
	/*	for (int i = 0; i < strlen(buf); ++i)
		{
			if (buf[i] != buf[strlen(buf) - i - 1]) return 0;
		}

		return 1;
	*/
}

void zad5_test() {
	int a;
	printf("Podaj a: \n");
	if (scanf_s("%d", &a) < 1 || ferror(stdin)) {
		printf("Niepoprawne dane \n");
		return;
	}
	printf("Liczba %d %s.\n", a, zad5_1(a) ? "jest palindromem" : "nie jest palindromem");
}


int zad5_2(int a) {
	char buf[100];
	int test_pali, wynik_odw;
	do {
		sprintf_s(buf, sizeof(buf), "%d", a);
		char* reverse = _strdup(buf);
		_strrev(reverse);
		wynik_odw = atoi(reverse);
		test_pali = a + wynik_odw;
		a = test_pali;
	} while (zad5_1(test_pali) == 0);

	return a;

}

void zad5_2_test() {
	int a;
	printf("Podaj a: \n");
	if (scanf_s("%d", &a) < 1 || ferror(stdin)) {
		printf("Niepoprawne dane \n");
		return;
	}
	printf("Wynik: %d\n", zad5_2(a));
}

void zad5_3() {
	char c;
	char str[200];

	printf("Wpisz litere: \n");
	c = _getch();
	printf("%c\n", c);
	c = tolower(c);
	printf("Podaj zdanie: \n");
	fgets(str, sizeof(str), stdin);


	char* tmp = NULL;
	char* token = strtok_s(str, " ,\t\n", &tmp);
	while (token)
	{
		if ((char)tolower(token[0]) == c)
			printf("%s ", token);
		token = strtok_s(NULL, " ,\t\n", &tmp);
	}

}



void zad5_5() {
	char str[200];
	printf("Podaj zdanie: \n");
	fgets(str, sizeof(str), stdin);
	size_t n;
	int w;
	printf("Podaj n: \n");
	if (scanf_s("%d", &n) < 1 || ferror(stdin)) {
		printf("Niepoprawne dane \n");
		return;
	}
	w = 0;
	char* tmp = NULL;
	char* token = strtok_s(str, " ,;?!.\t\n", &tmp);
	while (token)
	{
		if (strlen(token) >= n)
			w++;
		token = strtok_s(NULL, " ,\t\n", &tmp);
	}
	printf("Ilosc wyrazow >= %d: %d", n, w);
}

void zad5_6(char* text, char param) {
	unsigned int i;
	switch (param) {
	case 'a':
		for (i = 0; i < strlen(text); ++i) {
			text[i] = toupper(text[i]);
		}
		printf("%s", text);
		break;
	case 'b':
		for (i = 0; i < strlen(text); ++i) {
			text[i] = tolower(text[i]);
		}
		printf("%s", text);
		break;
	case 'c':
		text[0] = toupper(text[0]);
		printf("%s", text);
		break;
	case 'd':
		text[0] = toupper(text[0]);
		for (i = 1; i < strlen(text); ++i) {
			text[i] = tolower(text[i]);
		}
		printf("%s", text);
		break;
	case 'e':
		for (i = 0; i < strlen(text); ++i) {
			if (text[i] == tolower(text[i])) {
				text[i] = toupper(text[i]);
			}
			else {
				text[i] = tolower(text[i]);
			}
		}
		printf("%s", text);
		break;
	}
}

void zad5_3_test() {
	char text[500];
	char param;

	printf("Podaj zdanie: \n");
	fgets(text, sizeof(text), stdin);

	printf("Podaj parametr: \n");
	param = _getch();
	zad5_6(text, param);
}

void zad5_4()
{	
	char msg[SIZE];
	char key[SIZE];
	printf("Podaj tekst: ");
	fgets(msg, sizeof(msg), stdin);
	printf("Podaj klucz: ");
	scanf_s("%s", key, sizeof(key));
	int msgLen = strlen(msg), keyLen = strlen(key), i, j;

	char newKey[SIZE], encryptedMsg[SIZE], decryptedMsg[SIZE];

	for (i = 0, j = 0; i < msgLen-1; ++i, ++j) 
	{
		if ((int)msg[i] != 32)
		{
			msg[i] = toupper(msg[i]);
		}
		if (j == keyLen)
			j = 0;
		newKey[i] = toupper(key[j]);
	}
	newKey[i] = '\0';

	for (i = 0; i < msgLen-1; ++i)
	{
		if (msg[i] != ' ')
			encryptedMsg[i] = ((msg[i] + newKey[i]) % 26) + 'A';
		else
			encryptedMsg[i] = ' ';
	}
	encryptedMsg[i] = '\0';

	for (i = 0; i < msgLen-1; ++i)
	{
		if (encryptedMsg[i] != ' ')
			decryptedMsg[i] = (((encryptedMsg[i] - newKey[i]) + 26) % 26) + 'A';
		else
			decryptedMsg[i] = ' ';
	}
	decryptedMsg[i] = '\0';

	printf("\nZaszyfrowana wiadomosc: %s", encryptedMsg);
	printf("\nOdszyfrowana wiadomosc: %s", decryptedMsg);

	return;

}



