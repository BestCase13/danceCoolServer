IF OBJECT_ID('dbo.Group', 'U') IS NOT NULL
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[Group] ON
MERGE [dbo].[Group] AS TARGET
    USING (VALUES
    (1, /*prima*/1, /*sec*/2, /*dir*/1, /*level*/2),
    (2, /*prima*/1, /*sec*/2, /*dir*/1, /*level*/4),
    (3, /*prima*/5, /*sec*/6, /*dir*/2, /*level*/2),
    (4, /*prima*/5, /*sec*/6, /*dir*/2, /*level*/4),
    (5, /*prima*/3, /*sec*/4, /*dir*/3, /*level*/1),
    (6, /*prima*/3, /*sec*/4, /*dir*/3, /*level*/2),
    (7, /*prima*/3, /*sec*/4, /*dir*/3, /*level*/3),
    (8, /*prima*/9, /*sec*/null, /*dir*/4,/*level*/null))
    AS SOURCE (Id, PrimaryMentorId, SecondaryMentorId, DirectionId, LevelId )
    ON TARGET.Id = SOURCE.Id
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Id, PrimaryMentorId, SecondaryMentorId, DirectionId, LevelId)
        VALUES (Id, PrimaryMentorId, SecondaryMentorId, DirectionId, LevelId);
SET IDENTITY_INSERT [dbo].[Group] OFF
COMMIT;