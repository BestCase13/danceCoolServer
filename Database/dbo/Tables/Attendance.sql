CREATE TABLE [dbo].[Attendance] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [LessonId]         INT NOT NULL,
    [PresentStudentId] INT NOT NULL,
    CONSTRAINT [PK_AttendanceId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lesson_Attendance] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lesson] ([Id]),
    CONSTRAINT [FK_User_Attendance] FOREIGN KEY ([PresentStudentId]) REFERENCES [dbo].[User] ([Id])
);

