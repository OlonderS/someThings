/*
 * tablice2W.cpp
 */


#include <iostream>
#include <iomanip>
using namespace std;

void wprowadz(float *tab, int ile)
{
    for (int i=0;i<ile;i++)
    {
        cout<<"Ocena nr "<<i+1<<": ";
        cin>>*(tab+i); //cin>>tab[i];
    }
}

void drukuj(float *tab, int ile)
{
    cout<<"Podane oceny: ";
    for (int i=0;i<ile;i++)
    {
        cout<<*(tab+i)<<" ";
    }
    cout<<endl;
}

int tab1W() 
{
    float *tab = NULL;
    int ile;
    cout<<"Ile podasz ocen? ";
    cin>>ile;
    try 
    {
        tab = new float[ile];
    }
    catch(bad_alloc)        
    {
        cout<<"Za mało pamięci!";
        return 1;
    }
    
    wprowadz(tab, ile);
    drukuj(tab, ile);
    return 0;
}

void wypelnij2W(int **tab, int w, int k)
{
    srand(time(NULL));
    for(int i=0; i<w; i++)
        for(int j=0; j<k; j++)
            tab[i][j] = rand()%101;
}


void drukuj2W(int **tab, int w, int k)
{
    for(int i=0; i<w; i++)
    {
        for(int j=0; j<k; j++)
            cout<<setw(5)<<tab[i][j];
        cout<<endl;
    }
}


int tab2W()
{
    int w,k;
    cout<<"Podaj ilośc wierszy i kolumn: ";
    cin>>w>>k;
    int **tab; //wskaźnik do wskaźnika
    
    try 
    {
        tab = new int *[w];
    }
    catch(bad_alloc)        
    {
        cout<<"Za mało pamięci!";
        return 1;
    }
    
    for (int i=0;i<w;i++)
    {
        try 
        {
        tab[i] = new int[k];
        }
        catch(bad_alloc)        
        {
            cout<<"Za mało pamięci!";
            return 1;
        }    
    }
    wypelnij2W(tab, w, k);
    drukuj2W(tab, w, k);
    return 0;
    
}

void tabliczka_wyp2W(int **tab, int w, int k)
{
    for(int i=0; i<w; i++)
        for(int j=0; j<k; j++)
        {
            tab[i][j] = (i+1)*(j+1);
        }
}

int tabliczka2W()
{
    int w = 10;
    int k = 10;


    int **tab; //wskaźnik do wskaźnika
    try 
    {
        tab = new int *[w];
    }
    catch(bad_alloc)        
    {
        cout<<"Za mało pamięci!";
        return 1;
    }
    
    for (int i=0;i<w;i++)
    {
        try 
        {
        tab[i] = new int[k];
        }
        catch(bad_alloc)        
        {
            cout<<"Za mało pamięci!";
            return 1;
        }    
    }
    tabliczka_wyp2W(tab, w, k);
    drukuj2W(tab, w, k);
    
    return 0;

}


int main(int argc, char **argv)
{
	//tab2W();
    tabliczka2W();
	return 0;
}

