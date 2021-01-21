CREATE TABLE [dbo].[Lesson] (
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [Date]    DATETIME        NOT NULL,
    [Room]    NVARCHAR (1024) NOT NULL,
    [GroupId] INT             NULL,
    CONSTRAINT [PK_LessonId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Group_Lesson] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id])
);

