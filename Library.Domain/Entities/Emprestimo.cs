using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Emprestimo
    {
        Guid Id { get; set; }
        Guid IdUsuario { get; set; }
        Guid IdLivro { get; set; }
        DateTime DataEmprestimo { get; set; }
        DateTime DataDevolucaoPrevista { get; set; }
        DateTime? DataDevolucaoReal { get; set; }
        string Status { get; set; } //transformar em enum: ativo, devolvido, atrasado
    }
}