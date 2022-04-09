/*
 * samochod.cpp
 */
#include <iostream>
#include <cstdlib>
#include "car.h"
#include "osoba.h"

using namespace std;

int main(int argc, char **argv)
{
    Car s1 = Car();
    s1.dodaj();
    s1.dane();
    Car s2 = Car();
    int ile = 2;
    s2.laduj(ile);
    s2.pasazerowie;
    return 0;
}

