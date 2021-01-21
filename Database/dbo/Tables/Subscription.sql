CREATE TABLE [dbo].[Subscription] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [Price]          DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_SubscriptionId] PRIMARY KEY CLUSTERED ([Id] ASC)
);

