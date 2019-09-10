CREATE PROCEDURE [DajKorisnikaPoKorisnickomImenuISifri]
( @KorisnickoIme nvarchar(20),
@Sifra nvarchar(30)
)
AS
select * from Korisnik where Korisnik.KorisnickoIme=@KorisnickoIme and Korisnik.Sifra=@Sifra
GO