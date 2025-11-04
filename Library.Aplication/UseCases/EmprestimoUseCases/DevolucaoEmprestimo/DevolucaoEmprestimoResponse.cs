namespace Library.Aplication.UseCases.EmprestimoUseCases.DevolucaoEmprestimo;

public class DevolucaoEmprestimoResponse
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }

    public DevolucaoEmprestimoResponse(bool sucesso, string mensagem)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
    }
}

