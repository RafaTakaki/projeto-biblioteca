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