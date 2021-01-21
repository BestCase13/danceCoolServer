CREATE TABLE [dbo].[SkillLevel] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (1024) NOT NULL,
    CONSTRAINT [PK_SkillLevelId] PRIMARY KEY CLUSTERED ([Id] ASC)
);

