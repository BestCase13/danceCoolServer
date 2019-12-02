CREATE TABLE [dbo].[UserGroups] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [UserId]  INT NOT NULL,
    [GroupId] INT NOT NULL,
    CONSTRAINT [PK_UserGroupId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Group_UserGroup] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [FK_User_UserGroup] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

