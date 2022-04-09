/*
 * dec2bin.cpp
 */


#include <iostream>


using namespace std;

int main(int argc, char **argv)
{
    // dane wejsciowe
    //char znakA = 'A';
    //char znakB = 'B';
    //int l14 = 14;
    //int l15 = 15;
    //cout << (int)znakA << (int)znakB << endl;
    //cout << (char)l14 << (char)l15 << endl;
    int reszty[16];
	int liczba = 0;
    int podstawa = 0;
    
    cout << "Podaj liczbę i podstawę: ";
    cin >> liczba >> podstawa;
    
    // algorytm
    int i = 0; // indesk tabeli
    do
    {  // petla wykona sie przynajmniej raz
        reszty[i] = liczba % podstawa;
        liczba = liczba / podstawa;
        i++;
    }while(liczba > 0);
    
    //~for (int j = i - 1; j >= 0; j--)
    //~{
        //~cout << reszty [j];
    //~} 
    
    
    //~int j = i - 1;
    //~while(j>=0)
    //~{
        //~cout<<reszty[j];
        //~j--;
    //~}
    
    while (i - 1 >= 0)
    {
        i--;
        if(podstawa > 10 && reszty[i]>=10)
        {
            cout<< (char)(reszty[i]+55);
        }
        else
        {
            cout<<reszty[i];
        }
        
    }
    

    
    
	return 0;
}
