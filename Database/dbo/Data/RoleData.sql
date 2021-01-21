IF OBJECT_ID('dbo.Role', 'U') IS NOT NULL
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[Role] ON
MERGE [dbo].[Role] AS TARGET
    USING (VALUES
    (1, 'Student'),
    (2, 'Mentor'),
    (3, 'Admin')) 
    AS SOURCE ([Id], [Name])
    ON TARGET.Id = SOURCE.Id
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Id], [Name])
        VALUES ([Id], [Name]);
SET IDENTITY_INSERT [dbo].[Role] OFF
COMMIT;
