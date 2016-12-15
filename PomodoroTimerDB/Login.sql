CREATE TABLE [dbo].[Login]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Username] NVARCHAR(255) NOT NULL, 
    [Senha] NVARCHAR(50) NOT NULL
)
