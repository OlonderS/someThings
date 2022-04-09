/*
 * wektor.cpp
 */
/*
Napisz program który 
1. pobiera od użytkownika współrzędne pukntu 
początkowego i końcowego 
2. oblicza współrzędne środka tego wektora
Użyj dwóch struktur:
punkt- do przechowywania współrzędnych punkty
wektor - do przechowywania współrzędnych punktu początkowego i koncowego wektora 
 */
#include <iostream>
#include <fstream>

using namespace std;

struct punkt
{
    int x;
    int y;
};

struct wektor
{
    punkt pp;
    punkt pk;
    
};

punkt wylicz_srodek(wektor w) {
    punkt ps;
    ps.x = (w.pp.x + w.pk.x)/2;
    ps.y = (w.pp.y + w.pk.y)/2;
    
    
    
    return ps;
    
}



wektor getWektor() {
    wektor w1;
    cout << "Podaj x, y punktu poczatkowego: ";
    cin >> w1.pp.x;
    cin >> w1.pp.y;
    cout << "Podaj x, y punktu końcowego: ";
    cin >> w1.pk.x;
    cin >> w1.pk.y;

    
    return w1;
    
}



int main(int argc, char **argv)
{
	wektor w;
    w = getWektor();
    cout << "(" << w.pp.x << "," << w.pp.y << ")" << endl;
    cout << "(" << w.pk.x << "," << w.pk.y << ")" << endl;
    punkt ps;
    ps = wylicz_srodek(w);
    cout << "(" << ps.x << "," << ps.y << ")" << endl;
    
    return 0;
}
