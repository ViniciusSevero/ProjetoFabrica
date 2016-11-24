CREATE TABLE [dbo].[Aluno]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(255) NOT NULL, 
    [Rm] INT NOT NULL, 
    [DtNascimento] DATE NOT NULL, 
    [CursoId] INT NOT NULL, 
    CONSTRAINT [FK_Aluno_Curso] FOREIGN KEY ([CursoId]) REFERENCES [Curso]([Id]),
)
