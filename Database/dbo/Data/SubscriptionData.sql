IF OBJECT_ID('dbo.Subscription', 'U') IS NOT NULL
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[Subscription] ON
MERGE [dbo].[Subscription] AS TARGET
    USING (VALUES
    (1, N'разовий одинарний', 60),
    (2, N'разовий парний', 50),
    (3, N'4-разовий одинарний', 200),
    (4, N'4-разовий парний', 150),
    (5, N'8-разовий одинарний', 300),
    (6, N'8-разовий парний', 250),
    (7, N'індивідуальний одинарний', 250),
    (8, N'індивідуальний парний', 175))
    AS SOURCE ([Id], [Name], [Price])
    ON TARGET.Id = SOURCE.Id
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Id], [Name], [Price])
        VALUES ([Id], [Name], [Price]);
SET IDENTITY_INSERT [dbo].[Subscription] OFF
COMMIT;