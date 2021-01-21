IF OBJECT_ID('dbo.Payment', 'U') IS NOT NULL
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[Payment] ON
MERGE [dbo].[Payment] AS TARGET
    USING (VALUES
    --2/04/19
    (1, '2019-04-2 20:05', 50, 11, 1, 2),
    (2, '2019-04-2 20:06', 60, 15, 1, 1),
    (3, '2019-04-2 20:09', 60, 17, 1, 1),
    (4, '2019-04-2 22:05', 50, 22, 1, 2),
    (5, '2019-04-2 22:06', 60, 21, 1, 1),
    (6, '2019-04-2 22:09', 60, 19, 1, 1),
    (7, '2019-04-2 22:11', 200, 18, 1, 3),
    (8, '2019-04-2 22:12', 200, 20, 1, 3),
    --4/04/19
    (9, '2019-04-4 20:02', 200, 12, 1, 3),
    (10, '2019-04-4 20:03', 150, 14, 1, 4),
    (11, '2019-04-4 20:05', 200, 15, 1, 3),
    (12, '2019-04-4 20:08', 300, 16, 1, 5),
    (13, '2019-04-4 20:10', 200, 17, 1, 3),
    (14, '2019-04-4 22:12', 300, 18, 1, 5),
    (15, '2019-04-4 22:14', 200, 19, 1, 3),
    (16, '2019-04-4 22:17', 150, 21, 1, 4),
    --9/04/19
    (17, '2019-04-9 20:10', 200, 10, 1, 3),
    (18, '2019-04-9 20:12', 150, 13, 1, 4),
    (19, '2019-04-9 20:08', 300, 16, 1, 5),
    (20, '2019-04-9 22:03', 250, 22, 1, 6))
    AS SOURCE ([Id], [Date], [TotalSum], [UserSenderId], [UserReceiverId], [SubscriptionId])
    ON TARGET.Id = SOURCE.Id
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Id], [Date], [TotalSum], [UserSenderId], [UserReceiverId], [SubscriptionId])
        VALUES ([Id], [Date], [TotalSum], [UserSenderId], [UserReceiverId], [SubscriptionId]);
SET IDENTITY_INSERT [dbo].[Payment] OFF
COMMIT;