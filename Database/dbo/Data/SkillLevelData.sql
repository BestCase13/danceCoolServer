IF OBJECT_ID('dbo.SkillLevel', 'U') IS NOT NULL
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[SkillLevel] ON
MERGE [dbo].[SkillLevel] AS TARGET
    USING (VALUES
    (1, 'New Group', N'Групи з "нуля", для тих, хто робить перші кроки в танці.'),
    (2, 'Beginners', N'Група займається до 6-ти місяців.'),
    (3, 'Improvers', N'Група займається від 6-ти місяців до року.'),
    (4, 'Intermediate', N'Група займається від року до півтора.'),
    (5, 'Advanced', N'Група займається від півтора року і довше.'))
    AS SOURCE ([Id], [Name], [Description])
    ON TARGET.Id = SOURCE.Id
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Id], [Name], [Description])
        VALUES ([Id], [Name], [Description]);
SET IDENTITY_INSERT [dbo].[SkillLevel] OFF
COMMIT;