/*
 * fibonacci.cpp
 */


#include <iostream>

using namespace std;

int fib_rek(int n)
{
    if(n<2)
    {
        return 1;
    }
    else return fib_rek(n-2) + fib_rek(n-1);
}

int fib_iter(int n)
{
    int a = 0;
    int b = 1; 
    int tmp = 0;
    if (n == 0) 
    {
        cout << a;
    }
    else if (n == 1)
    {
        cout << b;
    }
    else if (n > 1)
    {

        //cout<<"Wyraz nr. 0 wynosi: 0"<<endl; 
        //cout<<"Zlota liczba: 0"<<endl;
        for (int i=1; i<=n; i++)
        {
            tmp = b;
            b = a + b;
            a = tmp;
            cout<<"Wyraz nr. "<<i<<" wynosi: "<<a<<endl;
            cout<<"Zlota liczba: "<<float(b)/float(a)<<endl;
        }
    }
    return 0;
}

int fib_iter2(int n)
{
    int a = 0;
    int b = 1;
    int i = 1;
    int tmp = 0;
    
    if (n == 0)
    {
        cout<<a;
    }
    while(n>0)
    {
        tmp = b;
        b = a + b;
        a = tmp;
        
        cout<<"Wyraz nr. "<<i<<" wynosi: "<<a<<endl;
        cout<<"Zlota liczba: "<<float(b)/float(a)<<endl;
        i++;
        n--;
    }
    return 0;
}

int main(int argc, char **argv)
{
	int ile = 0;
    cout<<"Ilosc liczb w ciagu: ";
    cin>>ile;
    //fib_iter(ile);
    //fib_iter2(ile);
    for(int i=0;i<ile;i++)
    {
        cout<<i+1<<" wyraz ciagu to: "<<fib_rek(i)<<endl;
    }
	return 0;
}

