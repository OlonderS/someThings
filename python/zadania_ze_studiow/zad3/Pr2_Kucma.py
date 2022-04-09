#!c:\python\python.exe
#-*- coding: ibm852 -*-

import math
from tkinter import * 
from tkinter.ttk import *
from tkinter.filedialog import askopenfilename
import os
if __name__ == '__main__':
    root = Tk()
    root.geometry('200x100')
    button_opt = {'padx': 15, 'pady': 5}
    btn = Button(root, text ='Open', command = askopenfilename).pack(**button_opt)
    btn2 = Button(root, text = 'Quit', command = root.destroy).pack(**button_opt)
    file = os.path.basename(askopenfilename(initialdir = "C:\\",title = "Select file",filetypes = [('all files', '.*'), ('text files', '.txt')]))
    error = 0
    try:
        with open(file, mode='r', errors='ignore') as in_file,  \
             open('result.txt', mode='w', errors='ignore') as out_file:
            out_file.write(in_file.readline().strip() + "    y\n")
            line = in_file.readline()
            while line:
                try:
                    desc, x1, x2, x3 = line.split(',') 
                    if desc.isdigit():  # zakladam ze opis to nie moze byc liczba
                        raise NameError("Niepoprawne dane\n")
                        error+=1
                    y = round(math.exp(-math.pow((float(x1)-float(x2))/float(x3), 2)), 3)
                    out_file.write(line.strip() + ", " + str(y) + "\n")    
                except Exception:
                    out_file.write("Niepoprawne dane\n")
                    error += 1
                finally:
                    line = in_file.readline()
    except IOError:
        print("Brak pliku")

    print("liczba blednych linii: ", error)
