--TWORZENIE BAZY I TABEL
CREATE DATABASE Wypo�yczalnia_rower�w;
GO
USE Wypo�yczalnia_rower�w;

CREATE TABLE Klienci
(
	IDKlienta INT NOT NULL IDENTITY PRIMARY KEY,
	Imi� NVARCHAR(20) NOT NULL,
	Nazwisko NVARCHAR(20) NOT NULL,
	Adres NVARCHAR(50) NOT NULL,
	Kod_pocztowy VARCHAR(6) NOT NULL,
	Miasto NVARCHAR(20) NOT NULL DEFAULT 'Krak�w'
);

CREATE TABLE Pracownicy
(
	IDPracownika INT NOT NULL IDENTITY PRIMARY KEY,
	Imi� NVARCHAR(20) NOT NULL,
	Nazwisko NVARCHAR(20) NOT NULL,
	Adres NVARCHAR(50) NOT NULL,
	Kod_pocztowy VARCHAR(6) NOT NULL,
	Miasto NVARCHAR(20) NOT NULL DEFAULT 'Krak�w',
	P�e� CHAR(1) NOT NULL CHECK(P�e� IN('K','M')),
	Email VARCHAR(30) NOT NULL,
	Telefon_s�u�bowy VARCHAR(12) NOT NULL,
	Stanowisko NVARCHAR(30) NOT NULL DEFAULT 'Obs�uga Klienta',
	IDPrze�o�onego INT NULL,
	CHECK(p�e� IN('K','M')),
	FOREIGN KEY(IDPrze�o�onego ) REFERENCES Pracownicy (IDPracownika) 
);

CREATE TABLE Cenniki
(
	IDCennika INT NOT NULL IDENTITY PRIMARY KEY,
	Sta�a_op�ata SMALLMONEY NOT NULL,
	Cena_za_godzin� SMALLMONEY NOT NULL,
);

CREATE TABLE Typy_rower�w
(
	IDRodzaju INT NOT NULL IDENTITY PRIMARY KEY,
	Typ NVARCHAR(20) NOT NULL,
	IDCennika INT NOT NULL,
	FOREIGN KEY(IDCennika) REFERENCES Cenniki (IDCennika)
);

CREATE TABLE Rowery
(
	IDRoweru INT NOT NULL IDENTITY PRIMARY KEY,
	Marka NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	Dost�pno�� CHAR(3) NOT NULL DEFAULT 'Tak' CHECK(Dost�pno�� IN('Tak', 'Nie')),
	Kolor NVARCHAR(20) NOT NULL,
	Rama CHAR(4) NOT NULL,
	Ko�a CHAR(4) NOT NULL,
	IDRodzaju INT NOT NULL,
	FOREIGN KEY(IDRodzaju) REFERENCES Typy_rower�w (IDRodzaju) 
);

CREATE TABLE Plac�wki
(
	IDPlac�wki INT NOT NULL IDENTITY PRIMARY KEY,
	Adres NVARCHAR(50) NOT NULL,
	Kod_pocztowy VARCHAR(6) NOT NULL,
	Miasto NVARCHAR(20) NOT NULL, 
);

CREATE TABLE Pracownik_plac�wka
(
	IDPlac�wki INT NOT NULL, 
	IDPracownika INT NOT NULL, 
	FOREIGN KEY (IDPlac�wki) REFERENCES Plac�wki(IDPlac�wki),
	FOREIGN KEY (IDPracownika) REFERENCES Pracownicy(IDPracownika)
);

CREATE TABLE Rezerwacje
(
	IDRezerwacji INT NOT NULL IDENTITY PRIMARY KEY,
	Data_od SMALLDATETIME NOT NULL,
	Liczba_godzin INT NOT NULL,
	IDRoweru INT NOT NULL,
	IDKlienta INT NOT NULL,
	IDPracownika INT NOT NULL,
	IDPlac�wki INT NOT NULL,
	FOREIGN KEY(IDRoweru) REFERENCES Rowery (IDRoweru),
	FOREIGN KEY(IDKlienta) REFERENCES Klienci (IDKlienta),
	FOREIGN KEY(IDPracownika) REFERENCES Pracownicy (IDPracownika),
	FOREIGN KEY(IDPlac�wki) REFERENCES Plac�wki (IDPlac�wki)
);

CREATE TABLE Wypo�yczenia
(
	IDWypo�yczenia INT NOT NULL IDENTITY PRIMARY KEY,
	Data_wypo�yczenia SMALLDATETIME NOT NULL DEFAULT GETDATE(),
	Liczba_godzin INT NOT NULL,
	Do_zap�aty SMALLMONEY NOT NULL DEFAULT '0.00',
	IDRoweru INT NOT NULL,
	IDKlienta INT NOT NULL,
	IDPracownika INT NOT NULL,
	IDPlac�wki INT NOT NULL,
	IDRezerwacji INT NULL,
	FOREIGN KEY(IDRoweru) REFERENCES Rowery (IDRoweru),
	FOREIGN KEY(IDKlienta) REFERENCES Klienci (IDKlienta),
	FOREIGN KEY(IDPracownika) REFERENCES Pracownicy (IDPracownika),
	FOREIGN KEY(IDRezerwacji) REFERENCES Rezerwacje (IDRezerwacji),
	FOREIGN KEY(IDPlac�wki) REFERENCES Plac�wki (IDPlac�wki),
);

CREATE TABLE Zwroty
(
	IDZwrotu INT NOT NULL IDENTITY PRIMARY KEY,
	Data SMALLDATETIME NOT NULL,
	Kara SMALLMONEY NULL,
	IDWypo�yczenia INT NOT NULL UNIQUE,
	IDRoweru INT NOT NULL,
	IDPracownika INT NOT NULL,
	FOREIGN KEY(IDWypo�yczenia) REFERENCES Wypo�yczenia (IDWypo�yczenia), 
	FOREIGN KEY(IDPracownika) REFERENCES Pracownicy (IDPracownika),
	FOREIGN KEY(IDRoweru) REFERENCES Rowery (IDRoweru)
);

-----------WSTAWIANIE WARTO�CI

INSERT INTO Klienci
VALUES 
('Adam', 'Kowalski', 'Mickiewicza 6/16', '30-003', DEFAULT),
('Mariusz', 'Nowak', 'S�owackiego 3/14', '30-001', DEFAULT),
('Karolina', 'Nowakowska', 'Czarniowiejska 26/25', '30-002', DEFAULT),
('Natalia', 'Adamczyk', 'Osio�ka 22/51', '29-513', 'Niepo�omice'),
('Ziemowit', 'Ma�y', 'Zakopia�ska 36/66', '30-002', DEFAULT),
('Marta', '�wi�ta', 'Krakowska 51/11', '31-611', 'Zakopane'),
('Micha�', 'Kicha�', 'Batorego 31/46', '30-002', DEFAULT),
('Julia', 'Bas', 'Norwida 26/4', '30-004', DEFAULT),
('Dominika', 'Kowalska', 'Mickiewicza 6/16', '30-003', DEFAULT);


INSERT INTO Pracownicy
VALUES
('Robert', 'Wielki', 'Stara 52/12', '30-004', DEFAULT, 'M', 'robertwielki@gmail.com', '123456789', 'Szef', NULL),
('Mariusz', 'Dzien', 'Warszawska 18/2', '30-004', DEFAULT, 'M', 'mariuszdzien@gmail.com', '796196789', 'Kierownik', 1),
('Bartosz', 'Adamczak', 'Sandmomierska 13/11', '29-513', 'Niepo�omice', 'M', 'bartoszadamczak@gmail.com', '123654987', DEFAULT, 2),
('Maria', 'Danch', 'Nowa 23/6', '30-002', DEFAULT, 'K', 'mariadanch@gmail.com', '753456789', DEFAULT, 2);

INSERT INTO Cenniki
VALUES
('5.00', '3.00'),
('7.00', '4.00'),
('10.00', '5.00');

INSERT INTO Typy_rower�w
VALUES
('Crossowy', 3),
('Trekkingowy', 2),
('Miejski', 2),
('MTB', 3),
('Dzieci�ce', 1),
('M�odzie�owe', 1);

INSERT INTO Rowery (Marka, Model, Kolor, Rama, Ko�a, IDRodzaju)
VALUES
('TABOU', 'Flow', 'Czerwony', '19''''', '29''''', 1),
('TABOU', 'Flow', 'Czarny', '19''''', '29''''', 1),
('GT', 'Speed', 'Czarno-zielony', '21''''', '30''''', 1),
('GT', 'Speed', 'Czarno-��ty', '21''''', '30''''', 1),
('TABOU', 'Kinetic', 'Szary', '18''''', '28''''', 2),
('TABOU', 'Kinetic', 'Bia�y', '18''''', '28''''', 2),
('Merida', 'Furious', 'Czany', '17''''', '26''''', 2),
('Merida', 'Furious', 'Szary', '17''''', '26''''', 2),
('TABOU', 'Queen', 'R�owy', '16''''', '26''''', 3),
('TABOU', 'Queen', 'Bia�y', '16''''', '26''''', 3),
('Orbea', 'King', 'Czarny', '17''''', '28''''', 3),
('Orbea', 'King', 'Br�zowy', '17''''', '28''''', 3),
('TABOU', 'WIZZ', 'Czerwony', '19''''', '28''''', 4),
('TABOU', 'WIZZ', 'Niebiesko-czarny', '19''''', '28''''', 4),
('Author', 'QUAZ', 'Czarny', '18''''', '27''''', 4),
('Author', 'QUAZ', 'Szary', '18''''', '27''''', 4),
('Romet', 'Panda', 'Niebieski', '16''''', '25''''', 5),
('Romet', 'Panda', 'Czarny', '18''''', '25''''', 5),
('TABOU', 'ROCKET', 'Niebieski', '14''''', '20''''', 6),
('TABOU', 'ROCKET', 'Czerwony', '14''''', '20''''', 6);

INSERT INTO Plac�wki
VALUES
('Wi�lacka 13', '30-001', 'Krak�w'),
('Stara 11', '30-002', 'Krak�w');

INSERT INTO Pracownik_plac�wka
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 1),
(2, 2),
(2, 3),
(2, 4);

INSERT INTO Rezerwacje
VALUES
('2021-06-8 16:00:00', 3, 2, 2, 3, 1),
('2021-06-8 17:00:00', 4, 3, 3, 4, 2),
('2021-06-9 09:30:00', 10, 7, 5, 3, 2),
('2021-06-10 10:00:00', 8, 5, 7, 3, 2),
('2021-06-15 11:30:00', 6, 1, 9, 4, 1);

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-8 10:00:00', 7, 1, 1, 3, 1, NULL);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=1;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-8 16:30:00', 3, 3, 2, 4, 2, 1);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=3;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-8 17:10:00', 4, 2, 3, 4, 2, 2);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=2;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-9 08:00:00', 8, 6, 4, 4, 1, NULL);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=6;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-9 09:30:00', 10, 7, 5, 3, 2, 3);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=7;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES('2021-06-9 12:00:00', 8, 10, 6, 3, 2, NULL);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=10;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-10 10:30:00', 8, 5, 7, 3, 2, 4);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=5;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-10 11:00:00', 4, 8, 8, 4, 1, NULL);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=8;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-10 11:00:00', 4, 19, 8, 4, 1, NULL);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=19;

INSERT INTO Wypo�yczenia (Data_wypo�yczenia, Liczba_godzin, IDRoweru, IDKlienta, IDPracownika, IDPlac�wki, IDRezerwacji)
VALUES ('2021-06-10 16:30:00', 5, 1, 1, 3, 2, NULL);

UPDATE Rowery
SET Dost�pno�� = 'Nie' WHERE IDRoweru=1;

UPDATE Wypo�yczenia 
SET Do_zap�aty=C.Sta�a_op�ata+C.Cena_za_godzin�*W.Liczba_godzin
FROM
    Wypo�yczenia W
INNER JOIN 
	Rowery R ON W.IDRoweru=R.IDRoweru
INNER JOIN 
	Typy_rower�w TR ON R.IDRodzaju=TR.IDRodzaju
INNER JOIN
    Cenniki C ON  TR.IDCennika = C.IDCennika;

INSERT INTO Zwroty
VALUES ('2021-06-8 17:55:00', NULL, 1, 3, 1);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=1;

INSERT INTO Zwroty
VALUES('2021-06-8 19:20:00', NULL, 2, 3, 3);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=3;

INSERT INTO Zwroty
VALUES('2021-06-8 21:10:00','10.00',3, 4, 2);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=2;

INSERT INTO Zwroty
VALUES('2021-06-9 17:30:00', '20.00', 4, 4, 6);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=6;

INSERT INTO Zwroty
VALUES('2021-06-9 19:25:00', NULL, 5, 3, 7);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=7;

INSERT INTO Zwroty
VALUES('2021-06-9 20:20:00', '10.00', 6, 3, 10);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=10;

INSERT INTO Zwroty
VALUES('2021-06-10 19:20:00', NULL, 7, 3, 5);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=5;

INSERT INTO Zwroty
VALUES('2021-06-10 14:55:00', NULL, 8, 4, 8);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=8;

INSERT INTO Zwroty
VALUES('2021-06-10 14:55:00', NULL, 9, 4, 19);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=19;

INSERT INTO Zwroty
VALUES('2021-06-10 21:00:00', NULL, 10, 3, 1);

UPDATE Rowery
SET Dost�pno�� = 'Tak' WHERE IDRoweru=1;

---------KWERENDY
SET LANGUAGE Polish

SELECT CONCAT(Data_wypo�yczenia, ' - ', DATENAME(dw, data_wypo�yczenia)) AS 'Data wypo�yczenia - dzie� tygodnia' FROM Wypo�yczenia
WHERE (DATENAME(hh, data_wypo�yczenia) <12) AND MONTH(Data_wypo�yczenia)=6 --szczeg�owe daty wypo�ycze�, kt�re mia�y miejsce w czerwcu przed po�udniem

SELECT CONCAT(K.Imi�, ' ', K.Nazwisko) AS 'Klient', W.Do_zap�aty FROM Klienci K INNER JOIN Wypo�yczenia W ON K.IDKlienta=W.IDKlienta WHERE K.Imi� LIKE '[A-K]%' -- Klient kt�rego Imi� zaczyna si� na liter� od A do K i kwota do zap�aty za jeden rower 

SELECT CONCAT(P.Imi�, ' ', P.Nazwisko) AS 'Pracownik',CONCAT(K.Imi�, ' ', K.Nazwisko) AS 'Klient' FROM Pracownicy P INNER JOIN Wypo�yczenia W 
ON P.IDPracownika=W.IDPracownika INNER JOIN Klienci K ON K.IDKlienta=W.IDKlienta WHERE K.Kod_pocztowy=P.Kod_pocztowy -- klienci i pracownicy, kt�rzy ich obs�ugiwali, kt�rzy maj� taki sam kod pocztowy

SELECT K.Imi�, K.Nazwisko FROM Klienci K INNER JOIN Wypo�yczenia W ON K.IDKlienta=W.IDKlienta
GROUP BY K.Imi�, K.Nazwisko HAVING SUM(W.Do_zap�aty)>=30 --klienci kt�rzy zaplacili przynajmniej 30 we wszystkich wypozyczeniach

Select CONCAT(Do_zap�aty, ', w miesi�cu ', DATENAME(m, data_wypo�yczenia)) as 'Najdro�sze wypo�yczenie' FROM Wypo�yczenia
WHERE Do_zap�aty=
	(Select MAX(Do_zap�aty) FROM Wypo�yczenia); -- wypisuje najdro�sze dokonane wypo�yczenie i miesi�c w kt�rym mia�o miejsce

SELECT R.Marka, COUNT(R.Marka) as 'Marka wypo�yczana tyle razy: 'FROM Rowery R  INNER JOIN Wypo�yczenia W ON R.IDRoweru=W.IDRoweru WHERE R.IDRodzaju < 5
GROUP BY R.Marka HAVING COUNT(*)>1 -- wypisuje te marki, kt�rych rowery przeznaczone dla doros�ych by�y wypo�yczone minimum 2 razy
