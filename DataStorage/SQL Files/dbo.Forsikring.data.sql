CREATE TABLE [dbo].[Forsikring] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [KundeId]             INT           NULL,
    [BilModelId]          INT           NULL,
    [Registreringsnummer] NVARCHAR (30) NULL,
    [Pris]                MONEY         NULL,
    [Forsikringssum]      MONEY         NULL,
    [Begyndelsesår]       DATETIME      NULL,
    [Betingelser]         NVARCHAR (80) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_Kunde] FOREIGN KEY ([KundeId]) REFERENCES [dbo].[Kunde] ([Id]),
    CONSTRAINT [FK_Table_BilModel] FOREIGN KEY ([BilModelId]) REFERENCES [dbo].[BilModel] ([Id])
);

