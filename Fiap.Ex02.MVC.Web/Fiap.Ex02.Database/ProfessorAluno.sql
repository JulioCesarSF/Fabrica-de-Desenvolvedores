CREATE TABLE [dbo].[ProfessorAluno]
(
	[ProfessorId] INT NOT NULL, 
    [AlunoId] INT NOT NULL, 
    CONSTRAINT [FK_ProfessorAluno_Professor] FOREIGN KEY ([ProfessorId]) REFERENCES [Professor]([Id]), 
    CONSTRAINT [FK_ProfessorAluno_Aluno] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno]([Id])
)
