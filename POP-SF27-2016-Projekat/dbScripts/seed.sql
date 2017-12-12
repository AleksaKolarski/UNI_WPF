-- seed.sql
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Polica', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Regal', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Ugaona garnitura', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Krevet', 0);


INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(1, 'Ultra polica', 'UL1PO', 123.5, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(2, 'Crni regal', 'CR1RE', 22, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(1, 'Mala polica', 'MA2PO', 13, 12, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(3, 'Basvelika', 'BA1UG', 55.6, 4, 0);