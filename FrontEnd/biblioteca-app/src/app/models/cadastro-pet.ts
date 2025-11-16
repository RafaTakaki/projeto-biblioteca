export interface CadastroPet {
    id: number;
    idUsuario: number;
    nomePet: string;
    tipoPet: string;
    idadePet: number;
    sexo?: string;
    raca: string;
    imagem?: string;
  }

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
