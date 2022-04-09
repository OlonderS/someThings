/*
 * kalkulator2.cpp
 */


#include <iostream>
#include <cmath>

using namespace std;

float dodawanie(float a, float b)
{
        return a+b;
}
float odejmowanie (float a, float b)
{
        return a-b;
}
float mnozenie (float a, float b)
{
        return a*b;
}
float dzielenie (float a, float b)
{
    if (b == 0)
    {
    cout<<"Nie dziel przez ";
    return 0;
    }
    else
        return a/b;
}
int main(int argc, char **argv)
{
    char znak; //+ - * /
    int a,b;
    a=b=0;
    
    for(;;)
    {
        cout<<"Podaj pierwsza liczbe: ";
        cin>>a;
        cout<<"Podaj druga liczbe: ";
        cin>>b;
        cout<<"Podaj znak (0 aby wyjść): ";
        cin>>znak;
        
        
        if (znak == '+' )
        {
            cout<<dodawanie(a, b)<<endl;
        }
        else if (znak== '-')
        {
            cout<<odejmowanie(a, b)<<endl;
        }
        else if (znak== '*')
        {
            cout<<mnozenie(a, b)<<endl;
        }
        else if (znak=='/')
        {
            cout<<dzielenie(a ,b)<<endl;
        }
        else if (znak=='0')
        {
            break;
        }
    }
	return 0;
}

