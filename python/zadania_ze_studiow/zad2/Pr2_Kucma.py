#!c:\python\python.exe
#-*- coding: ibm852 -*-
"""pierwsza wersja liczy ˜redni¥ geometryczn¥ 4 liczb z jednego pomiaru za pomoc¥ klasy Pomiar
druga wersja liczby ˜rednie danej wˆa˜ciwo˜ci z 3 pomiar¢w(nie byˆem pewien o co chodzi wi©c zrobiˆem obie werje)"""
import configparser as CP
if __name__ == '__main__':
    rd = CP.ConfigParser()
    rd.read('trm.rc') #ewentualnie import sys i sys.argv[1]
    class Pomiar:
        dic={'temp': 0, 'cis':0, 'wil':0, 'ste':0}
        sr=0
        def srednia(self):
            sr=round(abs(Pomiar.dic['temp']*Pomiar.dic['cis']*Pomiar.dic['wil']*Pomiar.dic['ste'])**(1/4), 2)
            return sr
    pomiar=Pomiar()
    wyniki=CP.ConfigParser()
    wyniki['DEFAULT']={'˜rednia geometryczna': '0.00'}
    for i in range(1, 4):
        pomiar.dic['temp']=float(rd.items(rd.sections()[i-1])[0][1].split(",")[0])
        pomiar.dic['cis']=float(rd.items(rd.sections()[i-1])[1][1])
        pomiar.dic['wil']=float(rd.items(rd.sections()[i-1])[2][1])
        pomiar.dic['ste']=float(rd.items(rd.sections()[i-1])[3][1])
        wyniki['Pomiar '+str(i)]={'˜rednia geometryczna': str(pomiar.srednia())}
    with open('result.rc', 'w+') as wyniki_plik:
        wyniki.write(wyniki_plik)
"""
import configparser as CP
if __name__ == '__main__':
    rd = CP.ConfigParser()
    rd.read('trm.rc')
    iloczyn_temp=iloczyn_a=iloczyn_b=iloczyn_c=1
    j_temp=j_a=j_b=j_c=0
    for key in rd.sections():
        try:
            x = rd.getfloat(key, "cis")
            iloczyn_a*=x
            j_a+=1
            x = rd.getfloat(key, "wil")
            iloczyn_b*=x
            j_b+=1
            x = rd.getfloat(key, "ste")
            iloczyn_c*=x
            j_c+=1
            x = rd.get(key, "temp")
            x=x.split(",")
            iloczyn_temp*=float(x[0])
            j_temp+=1
        except ValueError: #  wartosci pierwszego naglowka nie powinny by† liczone do ˜redniej
            continue   # wiec dla pierwszego key="DEFAULT" nic nie liczy
    temp=round(abs(iloczyn_temp)**(1/float(j_temp)), 2)
    a=round(abs(iloczyn_a)**(1/float(j_a)), 2)
    b=round(abs(iloczyn_b)**(1/float(j_b)), 2)
    c=round(abs(iloczyn_c)**(1/float(j_c)), 2)
    wyniki=CP.ConfigParser()
    wyniki['DEFAULT']={'˜rednia z 3 pomiar¢w': '0.00'}
    wyniki['Temperatura']={'˜rednia temperatura': str(temp)}
    wyniki['Ci˜nienie']={'˜rednie ci˜nienie': str(a)}
    wyniki['Wigotno˜†']={'˜rednia wilgotno˜†': str(b)}
    wyniki['St©¾enie']={'˜rednie st©¾enie ': str(c)}
"""

