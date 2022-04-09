#!/usr/bin/python3
 
def nwd(a, b):
    if a != 0 and b != 0:
        while( b != 0):
            b, a = a % b, b
        return a;
    return 0
       
def nww(a, b):
    try:
        return int(a * b / nwd(a, b))
    except ZeroDivisionError:
        return 0
 
def read_and_compose(file_p):
    j=0
    figures=[]
    try:
        with open(file_p) as file:  # with zapewni zamknięcie pliku
            line = file.readline()
            while(line!=''):  # warunek końca pliku
                x=line.split()  # zwraca listę niepustych elementów
                for i in x:
                    if i.isdigit():
                        figures.append(int(i))  # dopisuje do listy każdy element z linii, który jest liczbą
                line = file.readline()
        with open("out.txt", "w+") as result:  # tryb w+ aby utworzyć pusty plik
            while j<len(figures):
                try:
                    result.write(str(figures[j])+" ")
                    result.write(str(figures[j+1])+" ")
                    result.write(str(nwd(figures[j], figures[j+1]))+" ")
                    result.write(str(nww(figures[j], figures[j+1]))+"\n")
                    j+=2
                except IndexError:  # przy nieparzystej liczbie liczb wypisze tylko ostatnią bez pary, w koncu nie ma wtedy ani nww ani nwd
                    break
    except IOError:
        print("Nie mozna odnalezc takiego pliku")

if __name__ == '__main__':
    import sys
    read_and_compose("ParyLiczb.txt")
