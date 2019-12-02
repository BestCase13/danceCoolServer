CREATE TABLE [dbo].[Abonnements] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [AbonnementName] NVARCHAR (50) NOT NULL,
    [Price]          DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_AbonnementId] PRIMARY KEY CLUSTERED ([Id] ASC)
);

