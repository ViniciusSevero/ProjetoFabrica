CREATE TABLE [dbo].[Materia]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(255) NOT NULL, 
    [CursoId] INT NOT NULL, 
    CONSTRAINT [FK_Materia_Curso] FOREIGN KEY ([CursoId]) REFERENCES [Curso]([Id])
)
