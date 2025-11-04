namespace Library.Domain.Entities;

public class Emprestimo(string  Id,
                       string IdUsuario,
                       string IdLivro,
                       DateTime DataEmprestimo,
                       DateTime DataDevolucaoPrevista,
                       DateTime? DataDevolucaoReal,
                       string Status); //transformar em enum: ativo, devolvido, atrasado