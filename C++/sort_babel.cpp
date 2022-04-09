/*
 * sort_babel.cpp
 */


#include <iostream>

using namespace std;

void wypelnij(int t[],int n, int m)
{
    srand(time(NULL));
    
    for(int i=0;i<n;i++)
    {
        t[i] = 1+ rand()%m ;//losowanie liczb calkowitych z zakresu <0,m>
    }
}
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

int main(int argc, char **argv)
{
    const int ile=10;
    int tab[ile];
    
    wypelnij(tab, ile, 20);
    cout<<"TABELA: ";
    drukuj(tab,ile);
    cout<<endl;
    
    bubble_sort(tab,ile);
    drukuj(tab,ile);
    
    return 0;
}
