CREATE TABLE [dbo].[Attendances] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [LessonId]         INT NOT NULL,
    [PresentStudentId] INT NOT NULL,
    CONSTRAINT [PK_AttendanceId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lesson_Attendances] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lessons] ([Id]),
    CONSTRAINT [FK_User_Attendances] FOREIGN KEY ([PresentStudentId]) REFERENCES [dbo].[Users] ([Id])
);

