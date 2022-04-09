/*
 * minmaks.cpp
 */

#include <iostream>
#include <cstdlib>
#include <ctime>
#include <time.h>

using namespace std;

int main(int argc, char **argv)
{
    int ile = 0;
    int zakres = 0;
    int lista[zakres];
    int lmax[zakres/2];
    int lmin[zakres/2];
    int index = 0;

    cout<<"Podaj ilość liczb: ";
    cin>>ile;
    cout<<"Podaj zakres liczb: ";
    cin>>zakres;

    srand(time(NULL));
    for(int i=0;i<ile ;i++)
    {
        lista[i] = rand()%zakres+1;
        cout<<lista[i]<<", ";
    }
    cout<<endl<<endl;
    for(int i=0;i<ile/2 ;i++)
    {
        if(lista[index] > lista[index + 1])
        {
            lmax[i] = lista[index];
            lmin[i] = lista[index+1];
        }
        else
        {
            lmax[i] = lista[index+1];
            lmin[i] = lista[index];
        }
        index += 2;

        //cout<<"lmax: "<<lmax[i]<<endl;
        //cout<<"lmin: "<<lmin[i]<<endl;
    }

    int max = lmax[0];
    for(int i=0; i<ile/2 ;i++)
    {
        if(lmax[i] > max)
            max = lmax[i];
    }

    int min = lmin[0];
    for(int i=0; i<ile/2 ;i++)
    {
        if(lmin[i] < min)
            min = lmin[i];
    }

    cout<<"Minimalna liczba to: "<<min<<endl;
    cout<<"Maksymalna liczba to: "<<max<<endl;
    return 0;
}
