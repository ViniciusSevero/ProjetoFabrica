CREATE TABLE [dbo].[Sessao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipoId] INT NOT NULL, 
    [AlunoId] INT NOT NULL, 
    [MateriaId] INT NOT NULL, 
    CONSTRAINT [FK_Sessao_Tipo] FOREIGN KEY ([TipoId]) REFERENCES [TipoSessao]([Id]), 
    CONSTRAINT [FK_Sessao_Aluno] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno]([Id]), 
    CONSTRAINT [FK_Sessao_Materia] FOREIGN KEY ([MateriaId]) REFERENCES [Materia]([Id])
)
