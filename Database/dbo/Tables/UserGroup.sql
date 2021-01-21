CREATE TABLE [dbo].[UserGroup] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [UserId]  INT NOT NULL,
    [GroupId] INT NOT NULL,
    CONSTRAINT [PK_UserGroupId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Group_UserGroup] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    CONSTRAINT [FK_User_UserGroup] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

