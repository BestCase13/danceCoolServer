CREATE TABLE [dbo].[Payments] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Date]           DATETIME     NOT NULL,
    [TotalSum]       DECIMAL (18) NOT NULL,
    [UserSenderId]   INT          NOT NULL,
    [UserReceiverId] INT          NOT NULL,
    [AbonnementId]   INT          NOT NULL,
    CONSTRAINT [PK_PaymentId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Abonement_Payment] FOREIGN KEY ([AbonnementId]) REFERENCES [dbo].[Abonnements] ([Id]),
    CONSTRAINT [FK_UserReceiver_Payment] FOREIGN KEY ([UserReceiverId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_UserSender_Payment] FOREIGN KEY ([UserSenderId]) REFERENCES [dbo].[Users] ([Id])
);

