/*
 * wektork.cpp
 */


#include <iostream>
using namespace std;

class Wektor
{
    private:
        double x;
        double y;
    public:
        void pobierz(int);
        void wypisz();     
        void dlugosc();  
        friend Wektor dodaj(Wektor, Wektor); 
        friend Wektor iloczyn(Wektor, Wektor); 
        
};

void Wektor::pobierz(int nr)
{
    cout<<"Podaj współrzędne "<<nr<< " wektora: "<<endl;
    cin>>x;    
    cin>>y;    
}

void Wektor::wypisz()
{
    cout<<"["<<x<<","<<y<<"]"<<endl;
}

Wektor dodaj(Wektor w1, Wektor w2)
{
    Wektor w3;
    w3.x = w1.x + w2.x;
    w3.y = w1.y + w2.y;
    return w3;
}

Wektor iloczyn(Wektor w1, Wektor w2)
{
    Wektor w4;
    float wsp;
    cout<<"Podaj współczynnik: "<<endl;
    cin>>wsp;
    w4.x = w1.x*wsp;
    w4.y = w1.y*wsp; //ty no nw jak to zrobic
    return w4;
}

int main(int argc, char **argv)
{
	Wektor w1;
    w1.pobierz(1);
    w1.wypisz();
	Wektor w2;
    w2.pobierz(2);
    w2.wypisz();
    Wektor w3;
    w3 = dodaj(w1, w2);
    Wektor w4;
    
	return 0;
}

