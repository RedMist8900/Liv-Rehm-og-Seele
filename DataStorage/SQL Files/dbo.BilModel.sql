CREATE TABLE [dbo].BilModel
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Mærke] NVARCHAR(30) NULL, 
    [Model] NVARCHAR(30) NULL, 
    [Startår] DATETIME NULL, 
    [Slutår] DATETIME NULL, 
    [Pris] MONEY NULL, 
    [Forsikringssum] MONEY NULL
)
