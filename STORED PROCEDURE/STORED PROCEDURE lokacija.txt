USE [EVIDENCIJA_SPORTSKIH_AKTIVNOSTI_U_GRADU] 
GO

CREATE PROCEDURE [DajSveLokacije]
AS
select * from Lokacija
GO

CREATE PROCEDURE [DajLokacijuPoNazivu]
( @NazivLokacije nvarchar(40)
)
AS
select * from Lokacija where Lokacija.Naziv = @NazivLokacije
GO

CREATE PROCEDURE [DodajNovuLokaciju]
( 
@Sifra char(3),
@Naziv nvarchar(40)
)
AS
BEGIN
Insert into Lokacija(Sifra, Naziv) values (@Sifra, @Naziv)
END
GO

CREATE PROCEDURE [ObrisiLokaciju](
@Sifra char(3))
AS
BEGIN
Delete from Lokacija where Sifra=@Sifra
END
GO

CREATE PROCEDURE [IzmeniLokaciju](
@StaraSifra char(3),
@Sifra char(3),
@Naziv nvarchar(40)
)
AS
BEGIN
Update Lokacija set Sifra=@Sifra, Naziv=@Naziv where Sifra=@StaraSifra
END
GO



