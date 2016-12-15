CREATE TABLE [dbo].[LoginPermissao]
(
	[LoginId] INT NOT NULL , 
    [PermissaoId] INT NOT NULL, 
    CONSTRAINT [FK_LoginPermissao_Login] FOREIGN KEY ([LoginId]) REFERENCES [Login]([Id]), 
    CONSTRAINT [FK_LoginPermissao_Permissao] FOREIGN KEY ([PermissaoId]) REFERENCES [Permissao]([Id]), 
    PRIMARY KEY ([LoginId], [PermissaoId])
)

