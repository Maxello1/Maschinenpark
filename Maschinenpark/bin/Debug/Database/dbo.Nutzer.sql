CREATE TABLE [dbo].[Nutzer]
(
	[NID] INT NOT NULL PRIMARY KEY, 
    [BID] INT NOT NULL, 
    [Vorname] NVARCHAR(50) NOT NULL, 
    [Nachname] NVARCHAR(50) NOT NULL, 
    [Passwort] NVARCHAR(50) NOT NULL, 
    [IsAdmin] BIT NOT NULL
	
)
