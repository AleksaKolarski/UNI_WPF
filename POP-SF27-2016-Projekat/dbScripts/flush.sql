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
VALUES('Magacioner', 0, 0, 0, 15, 0, 8, 0, 15, 0);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Administrator', 15, 15, 15, 15, 12, 10, 15, 15, 0);

INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) 
VALUES('Prodavac', 8, 8, 0, 8, 12, 8, 0, 8, 0);


INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) 
VALUES(0, 'Magacionerko', 'Magacionerkic', 'srbenda', 'srbenda123', 0);

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
VALUES(0, 'Beli regal', 'BE0RE', 35, 43, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(0, 'Crveni regal', 'CR0RE', 37, 27, 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(1, 'Mala polica', 'MA1PO', 11, 56, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(1, 'Velika polica', 'VE1PO', 15, 10, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(1, 'Ugaona polica', 'UG1PO', 13, 3, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(1, 'Dupla polica', 'DU1PO', 14, 43, 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(2, 'Ugaona sofa', 'UG2SO', 45, 14, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(2, 'Mala sofa', 'MA2SO', 38, 26, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) 
VALUES(2, 'Velika sofa', 'VE2SO', 50, 24, 0);

INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) 
VALUES('Sklapanje', 15, 0);

INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) 
VALUES('Dostava', 20, 0);

INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) 
VALUES('Servis', 25, 0);


INSERT INTO Akcija (Naziv, DatumPocetka, DatumKraja, Obrisan) 
VALUES('Novogodisnja akcija', '2017-12-21 00:00:00', '2018-01-10 00:00:00', 0);

INSERT INTO Akcija (Naziv, DatumPocetka, DatumKraja, Obrisan) 
VALUES('Letnja akcija', '2018-05-31 00:00:00', '2018-08-16 00:00:00', 0);


INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(0, 0, 20);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(0, 2, 30);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(1, 4, 25);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(1, 6, 15);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) 
VALUES(1, 8, 25);


INSERT INTO Prodaja (DatumProdaje, Kupac, BrojRacuna, PDV) 
VALUES('2017-09-21 12:04:01', 'Kupac1', '123-123-123', 20.0);

INSERT INTO Prodaja (DatumProdaje, Kupac, BrojRacuna, PDV) 
VALUES('2018-01-05 16:30:20', 'Kupac2', '341-341-441', 20.0);

INSERT INTO Prodaja (DatumProdaje, Kupac, BrojRacuna, PDV) 
VALUES('2018-01-11 10:30:20', 'Bane Bojanic', '321-321-321', 20.0);


INSERT INTO ProdajaUsluga (IdProdaje, NazivUsluge, Cena) 
VALUES(1, 'Dostava', 25);

INSERT INTO ProdajaUsluga (IdProdaje, NazivUsluge, Cena) 
VALUES(1, 'Sklapanje', 30);

INSERT INTO ProdajaUsluga (IdProdaje, NazivUsluge, Cena) 
VALUES(2, 'Dostava', 40);


INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(0, 'Mala polica', 12, 3, 10);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(0, 'Mala sofa', 40, 7, 20);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(1, 'Ugaona polica', 15, 2, 5);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(1, 'Crveni regal', 28, 5, 0);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(1, 'Ugaona sofa', 25, 3, 10);

INSERT INTO ProdajaNamestaj (IdProdaje, NazivNamestaja, JedinicnaCena, BrojNamestaja, Popust) 
VALUES(2, 'Kraljevska sofa', 10000, 2, 3);
