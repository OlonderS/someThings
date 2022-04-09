/*Kamil Kućma
Projekt nr 13
Sortowanie elementów tablicy jednowymiarowej algorytmami (co najmniej trzy różne algorytmy) bez porównywania elementów.
Zbadanie efektywności poszczególnych algorytmów (średnie czasy wykonania dla różnych długości ciągów 10≤n≤1000000).*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void countingSort(int* tab, int roz);
void radixSort(int* array, int size);
void bucketSort(int* tab, int n);
void print_tab(int* tab, int n);
void test(int n, int a, int b);
struct bucket;


int main()
{
	test(10, 1, 100);  //ilość liczb, początek zakresu, koniec zakresu
	test(1000, 1, 100);
	test(100000, 1, 100);
	test(1000000, 1, 100);
	test(10, 1, 1000);
	test(1000, 1, 1000);
	test(100000, 1, 1000);
	test(1000000, 1, 1000);
	test(10, 1, 10000);
	test(1000, 1, 10000);
	test(100000, 1, 10000);
	test(1000000, 1, 10000);

	/* Wnioski:
	counting sort: Szybkość oraz ilość wymaganej pamięci zależy zarówno od ilości sortowanych liczb, jak i od zakresu w jakim te liczby się znajdują,
	spośród trzech podanych algorytmów dla podanych zakresów wykonuje się najszybiej. Złożoność czasowa O(n+max-min), podobnie z pamięcią
	radix sort: zlozonosc czasowa - O(d(n+k)), gdzie d oznacza która iteracja/cykl, w ramach której wykorzystujemy counting sort o złożoności O(n+k)
	bucket sort: analogicznie do counting sort, jego złożoność zależy od wielkości i zakresu danych. Złożność czasowa to O(n+r)
	Jeśli chodzi o same czasy wykonywania, to najszybciej przy przykładowych zakresach i przy losowych danych sprawuje się counting sort, następnie bucket sort, a na końcu radix sort,
	choć nawet przy wielkościach rzędu 10^6 są to ułamki sekund różnicy
	*/
}


void countingSort(int* tab, int roz)   // sortowanie przez zliczanie 
{
	int max = tab[0];
	int min = tab[0];
	for (int i = 1; i < roz; i++)   // szukanie największego i najmniejszego elementu tablicy
	{
		if (tab[i] > max)
			max = tab[i];
		if (tab[i] < min)
			min = tab[i];
	}
	int* count = calloc((max - min + 1), sizeof(int));

	for (int i = 0; i < roz; i++) //  zapisuje liczbę wystąpień danej liczby z pierwotnej tablicy w nowej tablicy na odpowiadającej jej indeksie gdzie indeks 0 odpowiada min a index max-min najwiekszej
	{
		count[tab[i] - min]++;
	}

	int k = 0;
	for (int i = 0; i < (max - min + 1); i++)  //  przekształcanie wcześniejszych zliczeń we właściwe sortowanie
	{
		while (count[i] != 0)
		{
			tab[k] = i + min;
			count[i]--;
			k++;
		}
	}
	free(count);
}

void radixSort(int* array, int size) {  //sortowanie pozycyjne - sortuje elementy grupując je według następujących po sobie cyfr - leksykograficznie 
	int* tmp_array = malloc(sizeof(int) * size);
	int i;
	int which_number = 1;
	int max = -1;
	for (i = 0; i < size; i++) {
		if (array[i] > max)
			max = array[i];
	} //szukamy wartosci maksymalnej aby znaleźć element o największej ilości cyfr

	if (tmp_array) {

		while (max / which_number > 0) { // poprzez dzielenie /10 przechodzimy po kolejnych cyfrach pozycyjnych danego elementu

			int bucket[10] = { 0 }; //tworzymy tyle bucketów od 0-9 ile iteracji przez wartosc max, reszta dziala tak jak w counting-sorcie
			for (i = 0; i < size; i++)
				bucket[(array[i] / which_number) % 10]++;
			for (i = 1; i < 10; i++)
				bucket[i] += bucket[i - 1];
			for (i = size - 1; i >= 0; i--)
				tmp_array[--bucket[(array[i] / which_number) % 10]] = array[i];
			for (i = 0; i < size; i++)
				array[i] = tmp_array[i];
			which_number *= 10;
		}
	}

	free(tmp_array);
}

struct bucket {
	int count;
	int* value;
};

void bucketSort(int* tab, int n) {  //sortowanie kubekowe
	struct bucket buckets[3]; // tworzenie kubelków
	int i, j, k;
	for (i = 0; i < 3; i++) {
		buckets[i].count = 0;
		buckets[i].value = (int*)malloc(sizeof(int) * n);
	}
	for (i = 0; i < n; i++) { // przypisywanie wartości z tablicy do odpowiedniego kubełka
		if (tab[i] < 0) {
			buckets[0].value[buckets[0].count++] = tab[i];
		}
		else if (tab[i] > 10) {
			buckets[2].value[buckets[2].count++] = tab[i];
		}
		else {
			buckets[1].value[buckets[1].count++] = tab[i];
		}
	}
	for (k = 0, i = 0; i < 3; i++) { // sortowanie wartości wewnątrz kubelka
		countingSort(buckets[i].value, buckets[i].count);
		for (j = 0; j < buckets[i].count; j++) {
			tab[k + j] = buckets[i].value[j];
		}
		k += buckets[i].count;
		free(buckets[i].value);
	}
}


void print_tab(int* tab, int n)
{
	for (int i = 0; i < n; ++i)
	{
		printf("%d ", tab[i]);
	}
	printf("\n");
}

void test(int n, int a, int b)
{
	int* tab1 = malloc(sizeof(int) * n);
	int* tab2 = malloc(sizeof(int) * n);
	int* tab3 = malloc(sizeof(int) * n);
	srand((size_t)time(0));

	for (int i = 0; i < n; ++i)
	{	
		tab1[i] = tab2[i] = tab3[i] = rand() % b + a;
	}

	printf("Czas wykonania dla %d liczb w zakresie %d-%d\n", n, a, b);

	clock_t begin = clock();
	//print_tab(tab1, n); // odkomentowac tylko w przypadku sprawdzania poprawnosci 
	countingSort(tab1, n);
	//print_tab(tab1, n);
	clock_t end = clock();
	double time_spent = ((double)end - (double)begin) / CLOCKS_PER_SEC;
	printf("Counting sort: %.3lfs\n", time_spent);

	begin = clock();
	//print_tab(tab2, n);
	radixSort(tab2, n);
	//print_tab(tab2, n);
	end = clock();
	time_spent = ((double)end - (double)begin) / CLOCKS_PER_SEC;
	printf("Radix sort: %.3lfs\n", time_spent);

	begin = clock();
	//print_tab(tab3, n);
	bucketSort(tab3, n);
	//print_tab(tab3, n);
	end = clock();
	time_spent = ((double)end - (double)begin) / CLOCKS_PER_SEC;
	printf("Bucket sort: %.3lfs\n", time_spent);

}