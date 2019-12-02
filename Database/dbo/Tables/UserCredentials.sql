CREATE TABLE [dbo].[UserCredentials] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [UserId]       INT             NOT NULL,
    [Email]        NVARCHAR (254)  NOT NULL,
    [PasswordHash] VARBINARY (MAX) NOT NULL,
    [PasswordSalt] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_UserCredentialsId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_UserCredentials] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([UserId] ASC)
);

