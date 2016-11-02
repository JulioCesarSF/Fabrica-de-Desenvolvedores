CREATE TABLE [dbo].[Produto]
(
	[ProdutoId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataCadastro] DATE NOT NULL, 
    [Descricao] NVARCHAR(200) NOT NULL, 
    [Nacional] BIT NOT NULL, 
    [Titulo] NVARCHAR(150) NOT NULL, 
    [Valor] DECIMAL(10, 2) NOT NULL
)
