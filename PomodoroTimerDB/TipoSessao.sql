CREATE TABLE [dbo].[TipoSessao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Tipo] VARCHAR(255) NOT NULL, 
    [Duracao] INT NOT NULL, 
    [TempoEstudo] INT NOT NULL, 
    [TempoDescanso] INT NOT NULL
)
