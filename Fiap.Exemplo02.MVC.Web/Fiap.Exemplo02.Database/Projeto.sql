CREATE TABLE [dbo].[Projeto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(150) NOT NULL, 
    [Descricao] TEXT NOT NULL, 
    [DataInicio] DATETIME2 NOT NULL, 
    [DataTermino] DATETIME2 NULL, 
    [Entregue] BIT NOT NULL, 
    CONSTRAINT [FK_Projeto_Grupo] FOREIGN KEY ([Id]) REFERENCES [Grupo]([Id])
)
