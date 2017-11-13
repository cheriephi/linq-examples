TRUNCATE TABLE dbo.[Address];

SET IDENTITY_INSERT [dbo].[Address] ON
INSERT [dbo].[Address] ([AddressKey], [FullName], [City], [StateCode]) 
VALUES (1, N'John Doe', N'Boulder', N'CO')
	, (2, N'Brent Leroy', N'Dog River', N'SK')
	, (3, N'Michelle', N'Washington', N'DC')
SET IDENTITY_INSERT [dbo].[Address] OFF

-- SELECT * FROM dbo.Address