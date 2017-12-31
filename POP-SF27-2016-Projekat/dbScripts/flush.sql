USE master;
CREATE DATABASE POP;
GO
USE POP;

CREATE TABLE TipKorisnika (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	Naziv VARCHAR(80),
	DozvolaAkcija TINYINT,
	DozvolaDodatnaUsluga TINYINT,
	DozvolaKorisnik TINYINT,
	DozvolaNamestaj TINYINT,
	DozvolaProdajaNamestaja TINYINT,
	DozvolaSalon TINYINT,
	DozvolaTipKorisnika TINYINT,
	DozvolaTipNamestaja TINYINT,
	Obrisan BIT
);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Jadnik', 0, 0, 0, 0, 0, 0, 0, 0, 0);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Administrator', 15, 15, 15, 15, 12, 10, 15, 15, 0);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Prodavac', 8, 8, 8, 8, 12, 8, 8, 8, 0);


CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	TipKorisnikaId INT FOREIGN KEY REFERENCES TipKorisnika(Id),
	Ime VARCHAR(80),
	Prezime VARCHAR(80),
	KorisnickoIme VARCHAR(80),
	Lozinka VARCHAR(80),
	Obrisan BIT
);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(0, 'Jadnik', 'BezDozvola', 'jadnik', 'jadnik', 0);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(1, 'Neko', 'Nekic', 'username1', 'password1', 0);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(2, 'Pera', 'Peric', 'username2', 'password2', 0);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(2, 'Mile', 'Kitic', 'mile', 'kitic123', 0);