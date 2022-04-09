/*
 * sort_wybor.cpp
 */
#include <iostream>

using namespace std;

void sort_wstaw_najm(int t[], int n)
{
    int el=0;
    int k=0;
    
    for(int i=1;i<n;i++)
    {
        el = t[i];
        k = i-1;
        
        while(k>=0 && t[k] > el)
        {
            t[k+1] = t[k];
            k--;
        }
        t[k+1] = el;
    }
}
void drukuj(int tab[], int n)
{
    for(int i=0; i<n; i++)
    {
        cout<<tab[i]<<" ";
    }
}

int main(int argc, char **argv)
{
    int ile = 7;
    int lista[ile];
    
    lista[0]= 2; 
    lista[1]= 5; 
    lista[2]= 8; 
    lista[3]= 9; 
    lista[4]= 0; 
    lista[5]= 3; 
    lista[6]= 6; 
    
    //int lista [5] =  {3, 4, 5, 6, 7}
    
    cout<<"Przed sortowaniem: "<<endl;
    drukuj(lista, ile);
    
    cout<<endl;
    cout<<"Po sortowaniu: "<<endl;
    
    sort_wstaw_najm(lista, ile);
    drukuj(lista, ile);
    
    return 0;
}

