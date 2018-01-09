USE master;
IF NOT EXISTS(SELECT * FROM sys.databases where name = 'POP') CREATE DATABASE POP;
GO
USE POP;

DROP TABLE IF EXISTS Salon;
DROP TABLE IF EXISTS Korisnik;
DROP TABLE IF EXISTS TipKorisnika;
DROP TABLE IF EXISTS DodatnaUsluga;
DROP TABLE IF EXISTS NaAkciji;
DROP TABLE IF EXISTS Akcija;
DROP TABLE IF EXISTS Namestaj;
DROP TABLE IF EXISTS TipNamestaja;
DROP TABLE IF EXISTS ProdajaUsluga;
DROP TABLE IF EXISTS ProdajaNamestaj;
DROP TABLE IF EXISTS Prodaja;


CREATE TABLE Salon (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	Naziv VARCHAR(120),
	Adresa VARCHAR(120),
	Telefon VARCHAR(80),
	Email VARCHAR(80),
	AdresaSajta VARCHAR(80),
	PIB INT,
	MaticniBroj INT,
	ZiroRacun VARCHAR(80)
);

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

CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	TipKorisnikaId INT FOREIGN KEY REFERENCES TipKorisnika(Id),
	Ime VARCHAR(80),
	Prezime VARCHAR(80),
	KorisnickoIme VARCHAR(80),
	Lozinka VARCHAR(80),
	Obrisan BIT
);

CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
);

CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	TipNamestajaId INT FOREIGN KEY REFERENCES TipNamestaja(Id),
	Naziv VARCHAR(80),
	Sifra VARCHAR(80),
	JedinicnaCena NUMERIC(9,2),
	KolicinaUMagacinu INT,
	Obrisan BIT
);

CREATE TABLE DodatnaUsluga (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	Naziv VARCHAR(80),
	Cena NUMERIC(9,2),
	Obrisan BIT
);

CREATE TABLE Akcija (
	Id INT PRIMARY KEY IDENTITY(0, 1),
	Naziv VARCHAR(80),
	DatumPocetka DATETIME2,
	DatumKraja DATETIME2,
	Obrisan BIT
);

CREATE TABLE NaAkciji (
	IdAkcije INT FOREIGN KEY REFERENCES Akcija(Id),
	IdNamestaja INT FOREIGN KEY REFERENCES Namestaj(Id),
	Popust NUMERIC(9,2)
);

CREATE TABLE Prodaja (
	Id INT PRIMARY KEY IDENTITY(0, 1), 
	DatumProdaje DATETIME2, 
	Kupac VARCHAR(80), 
	BrojRacuna VARCHAR(80), 
	PDV NUMERIC(9,2)
);
CREATE TABLE ProdajaUsluga (
	IdProdaje INT FOREIGN KEY REFERENCES Prodaja(Id),
	NazivUsluge VARCHAR(80), 
	Cena NUMERIC(9,2)
);
CREATE TABLE ProdajaNamestaj (
	IdProdaje INT FOREIGN KEY REFERENCES Prodaja(Id), 
	NazivNamestaja VARCHAR(80), 
	JedinicnaCena NUMERIC(9,2), 
	BrojNamestaja INT,
	Popust NUMERIC(9,2)
);



INSERT INTO Salon (Naziv, Adresa, Telefon, Email, AdresaSajta, PIB, MaticniBroj, ZiroRacun) 
VALUES('Forma FTNale', 'Trg FTN-a', '021/123123', 'kontakt@ftn.uns.ac.rs', 'www.ftn.com', 123, 231231, '840-00073555082-13');


INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Jadnik', 0, 0, 0, 0, 0, 0, 0, 0, 0);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Administrator', 15, 15, 15, 15, 12, 10, 15, 15, 0);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Prodavac', 8, 8, 8, 8, 12, 8, 8, 8, 0);


INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(0, 'Jadnik', 'BezDozvola', 'jadnik', 'jadnik', 0);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(1, 'Neko', 'Nekic', 'username1', 'password1', 0);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(2, 'Pera', 'Peric', 'username2', 'password2', 0);

INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(2, 'Mile', 'Kitic', 'mile', 'kitic123', 0);


INSERT INTO TipNamestaja (Naziv, Obrisan) 
VALUES('Regal', 0);

INSERT INTO TipNamestaja (Naziv, Obrisan) 
VALUES('Polica', 0);

INSERT INTO TipNamestaja (Naziv, Obrisan) 
VALUES('Sofa', 0);


INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(0, 'Sofa1', 'sifra1', 11, 111, 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(1, 'Sofa2', 'sifra2', 22, 222, 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(2, 'Sofa5', 'sifra5', 55, 555, 0);


INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) 
VALUES('DodatnaUsluga1', 150, 0);

INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) 
VALUES('DodatnaUsluga2', 200, 0);

INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) 
VALUES('DodatnaUsluga3', 350, 0);


INSERT INTO Akcija (Naziv, DatumPocetka, DatumKraja, Obrisan) 
VALUES('Akcija1', '2017-12-01T00:00:00', '2018-02-01T00:00:00', 0);

INSERT INTO Akcija (Naziv, DatumPocetka, DatumKraja, Obrisan) 
VALUES('Akcija2', '2018-01-01T00:00:00', '2018-03-01T00:00:00', 0);


INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(0, 0, 20);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(0, 1, 30);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(1, 1, 40);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(1, 2, 50);


INSERT INTO Prodaja (DatumProdaje, Kupac, BrojRacuna, PDV) 
VALUES('0001-01-01T00:00:00', 'Neko Nekic', '123-123-123', 20.0);

INSERT INTO Prodaja (DatumProdaje, Kupac, BrojRacuna, PDV) 
VALUES('0001-01-01T00:00:00', 'Pera Peric', '321-321-321', 20.0);


INSERT INTO ProdajaUsluga (IdProdaje, NazivUsluge, Cena) 
VALUES(1, 'Usluga1', 150);

INSERT INTO ProdajaUsluga (IdProdaje, NazivUsluge, Cena) 
VALUES(1, 'Usluga2', 200);


INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(0, 'Namestaj1', 32, 3, 10);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(0, 'Namestaj2', 12, 7, 20);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(1, 'Namestaj3', 67, 2, 5);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(1, 'Namestaj4', 17, 5, 15);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(1, 'Namestaj1', 20, 3, 10);