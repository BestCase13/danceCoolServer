CREATE TABLE [dbo].[User] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (512) NOT NULL,
    [LastName]     NVARCHAR (512) NOT NULL,
    [PhoneNumber]  VARCHAR (17)   NULL,
    [RoleId]       INT            DEFAULT ((1)) NOT NULL,
    [PayedLessons] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    UNIQUE NONCLUSTERED ([PhoneNumber] ASC)
);

