/*
 * horner.cpp
 */

#include <iostream>

using namespace std;

//W(x) = 2x^3 + 3x^2 + 5x + 4 (8)
//W(x) = x(2x^2 + 3x + 5) + 4
//W(x) = x(x(2x + 3) + 5) + 4 (3)

float horner_rek(int st, float x, float tbwsp[])
{
    if (st == 0)
        return tbwsp[0];
    return horner_rek(st-1, x, tbwsp) * x + tbwsp[st];

}

float horner_it(int st, float x, float tbwsp[])
{
    float wynik = tbwsp[0];
    for (int i = 1; i < st+1; i++)
        {
            wynik = wynik * x + tbwsp[i];
        }
    return wynik;
}

int main(int argc, char **argv)
{
    int stopien = 3;
    float x;
    float wsp[4];
    cout<<"Podaj argument: ";
    cin>>x;
    for(int i = 0; i < 4; i++)
    {
        cout<<"Podaj wartość współczynników";
        cin>>wsp[i];
    }
	cout << "Wartość wielomianu: "<< horner_it(stopien, x, wsp)<<endl;
	cout << "Wartość wielomianu: "<< horner_rek(stopien, x, wsp)<<endl;
	return 0;
}

