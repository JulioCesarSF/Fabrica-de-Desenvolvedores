CREATE TABLE [dbo].[Aluno]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(150) NOT NULL, 
    [DataNascimento] DATETIME NOT NULL, 
    [Bolsa] BIT NOT NULL, 
    [Desconto] FLOAT NULL
)
