IF OBJECT_ID('dbo.DanceDirection', 'U') IS NOT NULL
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[DanceDirection] ON
MERGE [dbo].[DanceDirection] AS TARGET
    USING (VALUES
    (1, 'Salsa LA' ),
    (2, 'Salsa Casino' ),
    (3, 'Bachata'),
    (4, 'Latina Lady Solo'))
    AS SOURCE ([Id], [Name])
    ON TARGET.Id = SOURCE.Id
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Id], [Name])
        VALUES ([Id], [Name]);
SET IDENTITY_INSERT [dbo].[DanceDirection] OFF
COMMIT;