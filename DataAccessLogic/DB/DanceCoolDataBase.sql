IF OBJECT_ID('[dbo].[Attendances]', 'U') IS NOT NULL
DROP TABLE [dbo].[Attendances]
GO
IF OBJECT_ID('[dbo].[Lessons]', 'U') IS NOT NULL
DROP TABLE [dbo].[Lessons]
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

-- Create a new table called '[Lessons]' in schema '[dbo]'
CREATE TABLE [dbo].[Lessons]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Date] DATETIME NOT NULL,
    [Room] NVARCHAR(1024) NOT NULL,
    [GroupId] INT NULL,
	CONSTRAINT PK_LessonId PRIMARY KEY([Id]),
    CONSTRAINT FK_Group_Lesson FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups]([Id])
);
GO

-- Insert rows into table '[Lessons]' in schema '[dbo]'
INSERT INTO [dbo].[Lessons]
    ([Date], [Room], [GroupId])
VALUES
------------------------------------------Квітень
	( '2019-04-2 19:00', N'Малий зал', 1),--1
	( '2019-04-2 20:30', N'Малий зал', 2),--2
	( '2019-04-4 19:00', N'Малий зал', 1),--3
	( '2019-04-4 20:30', N'Малий зал', 2),--4
	( '2019-04-9 19:00', N'Малий зал', 1),--5
	( '2019-04-9 20:30', N'Малий зал', 2),--6
	( '2019-04-11 19:00', N'Малий зал', 1),--7
	( '2019-04-11 20:30', N'Малий зал', 2),--8
	( '2019-04-16 19:00', N'Малий зал', 1),--9
	( '2019-04-16 20:30', N'Малий зал', 2),--10
	( '2019-04-18 19:00', N'Малий зал', 1),--11
	( '2019-04-18 20:30', N'Малий зал', 2),--12
	( '2019-04-23 19:00', N'Малий зал', 1),--13
	( '2019-04-23 20:30', N'Малий зал', 2),--14
	( '2019-04-25 19:00', N'Малий зал', 1),--15
	( '2019-04-25 20:30', N'Малий зал', 2),--16
	( '2019-04-30 19:00', N'Малий зал', 1),--17
	( '2019-04-30 20:30', N'Малий зал', 2),--18
	------------------------------------------Травень
	( '2019-05-2 19:00', N'Малий зал', 1),--19
	( '2019-05-2 20:30', N'Малий зал', 2),--20
	( '2019-05-7 19:00', N'Малий зал', 1),--21
	( '2019-05-7 20:30', N'Малий зал', 2),--22
	( '2019-05-9 19:00', N'Малий зал', 1),--23
	( '2019-05-9 20:30', N'Малий зал', 2),--24
	( '2019-05-14 19:00', N'Малий зал', 1),--25
	( '2019-05-14 20:30', N'Малий зал', 2),--26
	( '2019-05-16 19:00', N'Малий зал', 1),--27
	( '2019-05-16 20:30', N'Малий зал', 2),--28
	( '2019-05-21 19:00', N'Малий зал', 1),--29
	( '2019-05-21 20:30', N'Малий зал', 2),--30
	( '2019-05-23 19:00', N'Малий зал', 1),--31
	( '2019-05-23 20:30', N'Малий зал', 2),--32
	( '2019-05-28 19:00', N'Малий зал', 1),--33
	( '2019-05-28 20:30', N'Малий зал', 2),--34
	( '2019-05-30 19:00', N'Малий зал', 1),--35
	( '2019-05-30 20:30', N'Малий зал', 2),--36
	------------------------------------------Червень
    ( '2019-06-4 19:00', N'Малий зал', 1),--37
    ( '2019-06-4 20:30', N'Малий зал', 2),--38
    ( '2019-06-6 19:00', N'Малий зал', 1),--39
    ( '2019-06-6 20:30', N'Малий зал', 2),--40
    ( '2019-06-11 19:00', N'Малий зал', 1),--41
    ( '2019-06-13 20:30', N'Малий зал', 2)--42
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
