CREATE TABLE [dbo].[Group] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [PrimaryMentorId]   INT           NOT NULL,
    [SecondaryMentorId] INT           NULL,
    [DirectionId]       INT           NOT NULL,
    [LevelId]           INT           NULL,
    [GroupName]         VARCHAR (256) NULL,
    CONSTRAINT [PK_GroupId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Direction_Group] FOREIGN KEY ([DirectionId]) REFERENCES [dbo].[DanceDirection] ([Id]),
    CONSTRAINT [FK_Level_Group] FOREIGN KEY ([LevelId]) REFERENCES [dbo].[SkillLevel] ([Id]),
    CONSTRAINT [FK_PrimMentor_Group] FOREIGN KEY ([PrimaryMentorId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_SecMentor_Group] FOREIGN KEY ([SecondaryMentorId]) REFERENCES [dbo].[User] ([Id])
);

