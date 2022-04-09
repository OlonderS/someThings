/*
 * samogloski.cpp
 */


#include <iostream>
#include <fstream>
#include <cstring>
#include <cstdlib>
#include <iomanip>

using namespace std;


void drukuj(int t[],int n)
{
    for(int i=0;i<n;i++)
    {
        cout<<t[i]<<" ";
    }
    cout<<endl;
}
void zamien(int &a, int &b)
{
    int temp = a;
    a = b;
    b = temp;
}
void bubble_sort(int t[], int n)
{
    for(int i=1;i<n;i++)
    {
        for(int j=1;j<n; j++)
        {
            if(t[j] > t[j-1])
            {
                zamien(t[j], t[j-1]);
            }
        }
    }
}

int liczZnaki(char plik[]) {
    ifstream wejscie(plik);
    if (!wejscie) { cout << "Błąd otwarcia pliku!"; return 0; }
    int a, o, u, e, y, i;
    a=o=u=e=y=i=0;
    char z; // pojedynczy odczytany znak
    while(!wejscie.eof()) {
        wejscie.get(z);  // odczytanie pojedynczego znaku
        if (wejscie) {
            if ((int)z == 65 || z == 97) a++;
            if ((int)z == 79 || z == 111) o++;
            if ((int)z == 85 || z == 117) u++;
            if ((int)z == 69 || z == 101) e++;
            if ((int)z == 89 || z == 121) y++;
            if ((int)z == 73 || z == 105) i++;

        }
    }
    
    wejscie.close();
    cout << setw(10) << "Ilość a/A: " << a << endl;
    cout << setw(10) << "Ilość o/O: " << o << endl;
    cout << setw(10) << "Ilość u/U: " << u << endl;
    cout << setw(10) << "Ilość e/E: " << e << endl;
    cout << setw(10) << "Ilość y/Y: " << y << endl;
    cout << setw(10) << "Ilość i/I: " << i << endl;
    
    int tab[6]={a, o, u, e, y, i};
    int ile = 6;
    bubble_sort(tab, ile);
    drukuj(tab, ile);

    cout<<"Najwięcej jest samogłoski: "  <<endl<<"Jest jej: " <<tab[0];
    
    return a;
}

int main(int argc, char **argv)
{
    char nazwa[15];
    cout << "Podaj nazwę pliku: ";
    cin >> nazwa;
    liczZnaki(nazwa);
    
    return 0;
}

