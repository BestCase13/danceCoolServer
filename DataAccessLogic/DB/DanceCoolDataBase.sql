IF OBJECT_ID('[dbo].[Attendances]', 'U') IS NOT NULL
DROP TABLE [dbo].[Attendances]
GO

IF OBJECT_ID('[dbo].[UserGroups]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserGroups]
GO

-- Create a new table called '[UserGroups]' in schema '[dbo]'
CREATE TABLE [dbo].[UserGroups]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [GroupId] INT NOT NULL,
	CONSTRAINT PK_UserGroupId PRIMARY KEY([Id]),
    CONSTRAINT FK_User_UserGroup FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id]),
    CONSTRAINT FK_Group_UserGroup FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups]([Id])
);
GO

DECLARE @salsaLaCount INT = 10;

WHILE @salsaLaCount <= 17
BEGIN
    INSERT INTO [dbo].[UserGroups]
        ( UserId, GroupId )
    VALUES
        ( @salsaLaCount, 1 );
    SET @salsaLaCount = @salsaLaCount + 1;
END;
GO

DECLARE @salsaLaCount INT = 18;

WHILE @salsaLaCount <= 25
BEGIN
    INSERT INTO [dbo].[UserGroups]
        ( UserId, GroupId )
    VALUES
        ( @salsaLaCount, 2 );
    SET @salsaLaCount = @salsaLaCount + 1;
END;
GO

DECLARE @salsaLaCount INT = 25;

WHILE @salsaLaCount <= 32
BEGIN
    INSERT INTO [dbo].[UserGroups]
        ( UserId, GroupId )
    VALUES
        ( @salsaLaCount, 3 );
    SET @salsaLaCount = @salsaLaCount + 1;
END;
GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Attendances]
(
    [Id] INT NOT NULL IDENTITY(1,1), 
	[LessonId] INT NOT NULL,
    [PresentStudentId] INT NOT NULL,
	CONSTRAINT PK_AttendanceId PRIMARY KEY([Id]),
    CONSTRAINT FK_Lesson_Attendances FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lessons]([Id]),
    CONSTRAINT FK_User_Attendances FOREIGN KEY ([PresentStudentId]) REFERENCES [dbo].[Users]([Id])
);
GO

DECLARE @BeginnersLessonsCount INT = 1;
WHILE @BeginnersLessonsCount <= 9
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @BeginnersLessonsCount,  10),
  ( @BeginnersLessonsCount,  12),
  ( @BeginnersLessonsCount,  14),
  ( @BeginnersLessonsCount,  16),
  ( @BeginnersLessonsCount,  17);
  SET @BeginnersLessonsCount = @BeginnersLessonsCount + 2;
END;
GO

DECLARE @BeginnersLessonsCount INT = 11;
WHILE @BeginnersLessonsCount <= 17
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @BeginnersLessonsCount,  11),
  ( @BeginnersLessonsCount,  13),
  ( @BeginnersLessonsCount,  15),
  ( @BeginnersLessonsCount,  16),
  ( @BeginnersLessonsCount,  17);
  SET @BeginnersLessonsCount = @BeginnersLessonsCount + 2;
END;
GO

DECLARE @BeginnersLessonsCount INT = 19;
WHILE @BeginnersLessonsCount <= 27
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @BeginnersLessonsCount,  11),
  ( @BeginnersLessonsCount,  13),
  ( @BeginnersLessonsCount,  15),
  ( @BeginnersLessonsCount,  16),
  ( @BeginnersLessonsCount,  17);
  SET @BeginnersLessonsCount = @BeginnersLessonsCount + 2;
END;
GO

DECLARE @BeginnersLessonsCount INT = 29;
WHILE @BeginnersLessonsCount <= 35
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @BeginnersLessonsCount,  10),
  ( @BeginnersLessonsCount,  12),
  ( @BeginnersLessonsCount,  14),
  ( @BeginnersLessonsCount,  16),
  ( @BeginnersLessonsCount,  17);
  SET @BeginnersLessonsCount = @BeginnersLessonsCount + 2;
END;
GO

DECLARE @BeginnersLessonsCount INT = 37;
WHILE @BeginnersLessonsCount <= 41
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @BeginnersLessonsCount,  10),
  ( @BeginnersLessonsCount,  12),
  ( @BeginnersLessonsCount,  14),
  ( @BeginnersLessonsCount,  16),
  ( @BeginnersLessonsCount,  17);
  SET @BeginnersLessonsCount = @BeginnersLessonsCount + 2;
END;
GO

DECLARE @ImproversLessonsCount INT = 2;
WHILE @ImproversLessonsCount <= 10
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @ImproversLessonsCount,  18),
  ( @ImproversLessonsCount,  20),
  ( @ImproversLessonsCount,  22),
  ( @ImproversLessonsCount,  24),
  ( @ImproversLessonsCount,  25);
  SET @ImproversLessonsCount = @ImproversLessonsCount + 2;
END;
GO

DECLARE @ImproversLessonsCount INT = 12;
WHILE @ImproversLessonsCount <= 18
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @ImproversLessonsCount,  19),
  ( @ImproversLessonsCount,  21),
  ( @ImproversLessonsCount,  23),
  ( @ImproversLessonsCount,  24),
  ( @ImproversLessonsCount,  25);
  SET @ImproversLessonsCount = @ImproversLessonsCount + 2;
END;
GO

DECLARE @ImproversLessonsCount INT = 20;
WHILE @ImproversLessonsCount <= 28
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @ImproversLessonsCount,  19),
  ( @ImproversLessonsCount,  21),
  ( @ImproversLessonsCount,  23),
  ( @ImproversLessonsCount,  24),
  ( @ImproversLessonsCount,  25);
  SET @ImproversLessonsCount = @ImproversLessonsCount + 2;
END;
GO

DECLARE @ImproversLessonsCount INT = 30;
WHILE @ImproversLessonsCount <= 36
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @ImproversLessonsCount,  18),
  ( @ImproversLessonsCount,  20),
  ( @ImproversLessonsCount,  22),
  ( @ImproversLessonsCount,  24),
  ( @ImproversLessonsCount,  25);
  SET @ImproversLessonsCount = @ImproversLessonsCount + 2;
END;
GO

DECLARE @ImproversLessonsCount INT = 38;
WHILE @ImproversLessonsCount <= 42
BEGIN
	INSERT INTO [dbo].[Attendances]
    ([LessonId], [PresentStudentId])
VALUES  
  ( @ImproversLessonsCount,  18),
  ( @ImproversLessonsCount,  20),
  ( @ImproversLessonsCount,  22),
  ( @ImproversLessonsCount,  24),
  ( @ImproversLessonsCount,  25);
  SET @ImproversLessonsCount = @ImproversLessonsCount + 2;
END;
GO
