CREATE TABLE [dbo].[Role] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL, 
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

