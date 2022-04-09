#!c:\python\python.exe
#-*- coding: utf-8 -*-
"""kalkulator z różnymi dodatkowymi funkcjami"""

from tkinter import *
import math as m
import os
from tkinter.filedialog import askopenfilename
from fractions import Fraction
from tkinter import font as tkFont

expression = ""
ans_s = ""

def press(num):
    global expression
    expression = expression + str(num)
    equation.set(expression)   

def equalpress():
    try:
        global expression
        global ans_s
        total = str(round(eval(expression), 7))
        if int(float(total)) == float(total):
            equation.set(str(int(float(total))))
        else:
            equation.set(total)
        ans_s = equation.get()
        expression = ""
    except:
        equation.set(" error ")
        expression = ""

def clear():
    global expression
    expression = ""
    equation.set("")

def c():
    global expression
    expression = expression[:-1]
    equation.set(expression)

def fract():
    try:
        equation.set(Fraction(float(equation.get())).limit_denominator())
    except:
        equation.set(" error ")

def ans():
    global ans_s
    global expression
    expression = expression+ans_s
    equation.set(expression)

def sin(num):
    return m.sin(num)

def cos(num):
    return m.cos(num)

def tg(num):
    return m.tan(num)

def sq(num):
    return m.sqrt(num)

def plik():
    global expression
    file = os.path.basename(askopenfilename(initialdir="C:\\",
                           title="Select file", filetypes=[('all files', '.*'),
                           ('text files', '.txt')]))
    with open(file, 'r') as in_file:
        expression = in_file.readline()
        equation.set(expression)


if __name__ == "__main__":

    gui = Tk()
    gui.configure(background="silver")
    gui.title("Kalkulator")
    gui.geometry("")
    helv15 = tkFont.Font(family='Helvetica', size=15, weight=tkFont.BOLD)
    helv36 = tkFont.Font(family='Helvetica', size=36, weight=tkFont.BOLD)
    
    equation = StringVar()
    expression_field = Entry(gui, textvariable=equation, font=helv36)
    expression_field.grid(columnspan=6, ipadx=120, ipady=20)

    button1 = Button(gui, text=' 1 ', font=helv15,
                    command=lambda: press(1), height=3, width=5)
    button1.grid(row=5, column=0, sticky="NESW")

    button2 = Button(gui, text=' 2 ', font=helv15,
                     command=lambda: press(2), height=3, width=5)
    button2.grid(row=5, column=1, sticky="NESW")

    button3 = Button(gui, text=' 3 ', font=helv15,
                    command=lambda: press(3), height=3, width=5)
    button3.grid(row=5, column=2, sticky="NESW")

    button4 = Button(gui, text=' 4 ', font=helv15,
                    command=lambda: press(4), height=3, width=5)
    button4.grid(row=4, column=0, sticky="NESW")

    button5 = Button(gui, text=' 5 ', font=helv15,
                    command=lambda: press(5), height=3, width=5)
    button5.grid(row=4, column=1, sticky="NESW")

    button6 = Button(gui, text=' 6 ', font=helv15,
                    command=lambda: press(6), height=3, width=5)
    button6.grid(row=4, column=2, sticky="NESW")

    button7 = Button(gui, text=' 7 ', font=helv15,
                    command=lambda: press(7), height=3, width=5)
    button7.grid(row=3, column=0, sticky="NESW")

    button8 = Button(gui, text=' 8 ', font=helv15,
                    command=lambda: press(8), height=3, width=5)
    button8.grid(row=3, column=1, sticky="NESW")

    button9 = Button(gui, text=' 9 ', font=helv15,
                    command=lambda: press(9), height=3, width=5)
    button9.grid(row=3, column=2, sticky="NESW")

    button0 = Button(gui, text=' 0 ', font=helv15,
                    command=lambda: press(0), height=3, width=5)
    button0.grid(row=6, column=0, sticky="NESW")

    buttonln = Button(gui, text=' ( ', font=helv15,  
                    command=lambda: press('('), height=3, width=3)
    buttonln.grid(row=2, column=3, padx=3, sticky="NESW")

    buttonpn = Button(gui, text=' ) ', font=helv15,  
                    command=lambda: press(')'), height=3, width=3)
    buttonpn.grid(row=2, column=4, sticky="NESW")

    plus = Button(gui, text=' + ', font=helv15,  
                    command=lambda: press("+"), height=3, width=3)
    plus.grid(row=3, column=3, padx=3, sticky="NESW")

    minus = Button(gui, text=' - ', font=helv15,  
                    command=lambda: press("-"), height=3, width=3)
    minus.grid(row=3, column=4, sticky="NESW")

    multiply = Button(gui, text=' * ', font=helv15,  
                    command=lambda: press("*"), height=3, width=3)
    multiply.grid(row=4, column=3, padx=3, sticky="NESW")

    divide = Button(gui, text=' / ', font=helv15,  
                    command=lambda: press("/"), height=3, width=3)
    divide.grid(row=4, column=4, sticky="NESW")

    equal = Button(gui, text=' = ', font=helv15,  
                    command=equalpress, height=3, width=3)
    equal.grid(row=6, column=3, columnspan=2, sticky="NESW", padx=2)

    clear = Button(gui, text='Clear', font=helv15,  
                command=clear, height=3, width=5)
    clear.grid(row=2, column=1, pady=2, sticky="NESW")

    c = Button(gui, text='C', font=helv15,  
                command=c, height=3, width=5)
    c.grid(row=2, column=2, pady=2, sticky="NESW")

    file = Button(gui, text='Open', font=helv15,
                    command=plik, height=3, width=5)
    file.grid(row=2, column=0, pady=2, sticky="NESW")

    power = Button(gui, text='x**y', font=helv15,  
                    command=lambda: press("**"), height=3, width=3)
    power.grid(row=5, column=3, padx=3, sticky="NESW")

    decimal = Button(gui, text='.', font=helv15,
                    command=lambda: press('.'), height=3, width=5)
    decimal.grid(row=6, column=1, sticky="NESW")

    fract = Button(gui, text='fract(x)', font=helv15,  
                    command=fract, height=3, width=5)
    fract.grid(row=5, column=4, sticky="NESW")

    anss = Button(gui, text='ans', font=helv15,  
                    command=ans, height=3, width=5)
    anss.grid(row=6, column=2, sticky="NESW")

    pii = Button(gui, text='π', font=helv15,  
                    command=lambda: press("m.pi"), height=3, width=3)
    pii.grid(row=6, column=5, sticky="NESW", padx=3)

    sqrt = Button(gui, text='√(x)', font=helv15,  
                    command=lambda: press("sq("), height=3, width=3)
    sqrt.grid(row=2, column=5, sticky="NESW", padx=3)

    sinus = Button(gui, text='sin(x)', font=helv15,  
                    command=lambda: press("sin("), height=3, width=3)
    sinus.grid(row=3, column=5, sticky="NESW", padx=3)

    cosinus = Button(gui, text='cos(x)', font=helv15,  
                    command=lambda: press("cos("), height=3, width=3)
    cosinus.grid(row=4, column=5, sticky="NESW", padx=3)

    tangens = Button(gui, text='tg(x)', font=helv15,  
                    command=lambda: press("tg("), height=3, width=3)
    tangens.grid(row=5, column=5, sticky="NESW", padx=3)

    gui.mainloop()
