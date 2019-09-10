USE [EVIDENCIJA_SPORTSKIH_AKTIVNOSTI_U_GRADU] 
GO

CREATE PROCEDURE [DajSveSportove]
AS
Select * from Sport
GO

CREATE PROCEDURE [DajSveSportoveSaJoin] 
AS
Select Sport.IDSporta, Sport.NazivSporta, Sport.DatumTreninga as NazivLokacije from Sportinner join Lokacija on Sport.IdLokacije = Lokacija.Sifra
GO

CREATE PROCEDURE [DajSportPoNazivuSporta] @SportNazivSporta nvarchar(40) AS Lokacije where SPORT.NazivSporta = @SportNazivSporta

CREATE PROCEDURE [DodajNoviSport]( 
@IDSporta char(3),
@NazivSporta nvarchar(40),
@DatumTreninga date,
@IDLokacije char(3))
AS
BEGIN
Insert into Sport(IDSporta, NazivSporta, DatumTreninga, IDLokacije) values (@IDSporta, @NazivSporta, @DatumTreninga, @IDLokacije)
END
GO

CREATE PROCEDURE [ObrisiSport](
@IDSporta char(3))
AS
BEGIN
Delete from Sport where IDSporta=@IDSporta
END
GO

CREATE PROCEDURE [IzmeniSport](
@StariIDSporta char(3),
@IDSporta char(3),
@NazivSporta nvarchar(40),
@DatumTreninga date,
@IDLokacije char(3))
AS
BEGIN
Update Sport set IDSporta=@IDSporta, NazivSporta=@NazivSporta, DatumTreninga=@DatumTreninga, IDLokacije=@IDLokacije where IDSporta=@StariIDSporta
END
GO


CREATE PROCEDURE [DajSveSportoveSaJoinSifromLokacije] 
AS
Select Sport.IDSporta, Sport.NazivSporta, Sport.DatumTreninga, Lokacija.Naziv as NazivLokacije, Lokacija.Sifra as SifraLokacije  from Sport inner join Lokacija on Sport.IdLokacije = Lokacija.Sifra
GO


