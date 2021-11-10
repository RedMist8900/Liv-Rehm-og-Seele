CREATE TABLE [dbo].Kunde
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Fornavn] NVARCHAR(30) NULL, 
    [Efternavn] NVARCHAR(30) NULL, 
    [Adresse] NVARCHAR(30) NULL, 
    [Postnummer] INT NULL, 
    [Telefon] INT NULL
)
