USE [master]
GO

CREATE DATABASE [EVIDENCIJA_SPORTSKIH_AKTIVNOSTI_U_GRADU] 
GO

USE [EVIDENCIJA_SPORTSKIH_AKTIVNOSTI_U_GRADU] 
GO

CREATE TABLE [dbo].[SPORT](
	[IDSporta] [char](3) NOT NULL,
	[NazivSporta] [nvarchar](40) NOT NULL,
	[DatumTreninga] date NOT NULL,
	[IDLokacije] [nvarchar](40) not null
	
)
GO

ALTER TABLE [dbo].[SPORT]
ADD CONSTRAINT [PK_SPORT] PRIMARY KEY CLUSTERED 
(
	[IDSporta] ASC
)

GO

CREATE TABLE [dbo].[Lokacija](
	[Sifra] [nvarchar](40) NOT NULL,
	[NAziv] [nvarchar](40) NOT NULL,
)
GO

ALTER TABLE [dbo].[Lokacija]
ADD CONSTRAINT [PK_Lokacija] PRIMARY KEY CLUSTERED
(
	[SIFRA] ASC
)
GO

ALTER TABLE [dbo].[SPORT] ADD CONSTRAINT
[FK_Sport_Lokacija] FOREIGN KEY([IDLokacije])
REFERENCES [dbo].[Lokacija] ([Sifra])
ON UPDATE CASCADE
GO


CREATE TABLE [dbo].[Korisnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Prezime] [nvarchar](40) NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[KorisnickoIme] [nvarchar](20) NOT NULL,
	[Sifra] [nvarchar](30) NOT NULL,
	[Status] [nvarchar](10) NOT NULL
)

GO 