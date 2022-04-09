/*
 * sort_wyb.cpp
 * 
 */


#include <iostream>
//#include <windows.h>
//#include <time.h>


using namespace std;

void wypelnij(int t[], int n, int m)
{
    srand(time(NULL));
    
    
    for (int i = 0; i < n; i++)
    {
        t[i] = 1 + rand() % m; // losowanie liczb całkowitych z zakresu <0; m>
    }
}

void drukuj(int t[], int n)
{
    for (int i = 0; i < n; i++)
    {
        cout << t[i] << " ";
    }
    cout<<endl;
}


void zamien(int &a, int &b)
{
    int tmp = a;
    a = b;
    b = tmp;
}


void sort_wyb(int t[], int n)
{
    int k;
    for (int i = 0; i < n; i++)
    {
        k = i;
        for (int j = i + 1; j < n; j++)
        {
            if (t[j] < t[k])
            {
                k = j;
            }
        }
        zamien(t[i], t[k]);
    }
}


int main(int argc, char **argv)
{
	const int ile = 10;
    int tab[ile];
    wypelnij(tab, ile, 20);
    cout<<"Tabela przed posortowaniem: "<<endl;
    drukuj(tab, ile);
    cout<<"Tabela po posortowaniu: "<<endl;
    sort_wyb(tab,ile);
    drukuj(tab,ile);
	return 0;
}
