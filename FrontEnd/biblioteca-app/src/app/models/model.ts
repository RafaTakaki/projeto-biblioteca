 export interface CadastroLivro {
    id?: string,
    titulo: string,
    autor: string,
    isbn: string,
    categoria: string,
    quantidadeEstoque: string
  }

  export interface Reserva {
    id: string,
    idUsuario: string,
    emailUsuario: string,
    idLivro: string,
    tituloLivro: string,
    dataReserva: string,
    dataExpiracaoReserva: string,
    status: string
  }

  export interface Emprestimo {
    id: string,
    idUsuario: string,
    idLivro: string,
    dataEmprestimo: string,
    dataDevolucaoPrevista: string,
    dataDevolucaoReal: string,
    status: string
  }
