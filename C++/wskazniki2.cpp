/*
 * wskazniki.cpp
 */


#include <iostream>
using namespace std;

int main(int argc, char **argv)
{
    double tab[10] = {10, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    double *wsk_x;
    wsk_x = tab;
    for(int i=0; i<10; i++)
    {
        cout<<*(wsk_x+i)<<endl;
    }
    
    cout<<tab<<endl;
    cout<<tab+1<<endl;
    cout<<tab+2<<endl;
    cout<<*tab<<endl;
    cout<<*(tab+1)<<endl;
    cout<<*(tab+2)<<endl;
    

    
	return 0;
}

