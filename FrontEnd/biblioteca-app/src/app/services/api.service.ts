import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CadastroPet } from '../models/cadastro-pet';
import { Agendamento } from '../models/agendamentos';
import { Notificacao } from '../models/notificacao';
import type { CadastroLivro, Reserva, Emprestimo } from '../models/cadastro-pet';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:'; // Base da API
  private apiUrlCachorro = 'http://localhost:5222/api/Pet/listarRacaCachorros'; // Endpoint para cachorros
  private apiUrlGato = 'http://localhost:5222/api/Pet/listarRacaGatos'; // Endpoint para gatos
  private urlBuscaPet = 'http://localhost:5222/api/Pet/ListarPetsPorUsuario';

  constructor(private http: HttpClient) { }

  sendEmail(email: string): Observable<string> {
    const url = `${this.apiUrl}5143/api/Usuario/RecuperarSenha`;
    return this.http.get(url, {
      params: { Email: email },
      responseType: 'text'
    });
  }

  cadastro(email: string, senha: string, nome: string): Observable<string> {
    const url = `${this.apiUrl}5016/api/Usuario/CriarUsuario`;

    // Criando o JSON no corpo da requisição
    const body = {
      nome: nome,
      email: email,
      senha: senha
    };



    // Cabeçalhos HTTP
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post(url, body, { headers, responseType: 'text' });
  }

  cadastrarLivro(body: CadastroLivro): Observable<string> {
    const url = `${this.apiUrl}5016/Livro/CriarLivro`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<string>(url, body, { headers: headers, responseType: 'text' as 'json' });
  }

  editarLivro(body: CadastroLivro): Observable<string> {
    // TODO Criar no back end o endpoint para alteração
    const url = `${this.apiUrl}5016/Livro/*altere aqui*`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<string>(url, body, { headers: headers, responseType: 'text' as 'json' });
  }

  listarLivrosDisponiveis(): Observable<any> {
    const url = `${this.apiUrl}5016/Livro/ObterLivrosDisponiveis`;
    return this.http.get<any>(url);
  }

  listarReservasPorEmail(email: string): Observable<Reserva[]> {
    const params = new HttpParams()
      .set('email', email);

    const url = `${this.apiUrl}5016/Reserva/BuscarReservasPorEmail`;
    return this.http.get<Reserva[]>(url, { params });
  }

  excluirLivro(livroParaDeletar: any): Observable<string> {
    const params = new HttpParams()
      .set('titulo', livroParaDeletar.toString());

    // TODO Criar endpoint para realizar a operação
    const url = `${this.apiUrl}5016/Livro/*altere aqui*`;
    return this.http.delete<string>(url, {params});
  }

  criarEmprestimo(reserva: Reserva): Observable<string> {
    const url = `${this.apiUrl}5016/Emprestimo/CriarEmprestimoLivro`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<string>(url,{idReserva: reserva.id} , { headers: headers, responseType: 'text' as 'json' });
  }

  devolverEmprestimo(emprestimo: Emprestimo): Observable<string> {
    const url = `${this.apiUrl}5016/Emprestimo/DevolucaoEmprestimo`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<string>(url,{idEmprestimo: emprestimo.id} , { headers: headers, responseType: 'text' as 'json' });
  }

  buscarEmprestimosAtivos(): Observable<any> {
    const url = `${this.apiUrl}5016/Emprestimo/TodosEmprestimosAtivos`;
    return this.http.get<any>(url);
  }

  buscarReservasAtivas(): Observable<Reserva[]> {
    const url = `${this.apiUrl}5016/Reserva/BuscarTodasReservasAtivas`
    return this.http.get<Reserva[]>(url);
  }

  criarReserva(titulo: string): Observable<string> {
    const url = `${this.apiUrl}5016/Reserva/ReservarLivro`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<string>(url, { livro: titulo, token: '' }, { headers: headers, responseType: 'text' as 'json' });
  }

  buscaRacas(tipoPet: string): Observable<string[]> {
    const url = tipoPet === 'Cachorro' ? this.apiUrlCachorro : this.apiUrlGato;
    return this.http.get<string[]>(url);


  }

  buscapets(): Observable<CadastroPet[]> {
    const url = this.urlBuscaPet;
    return this.http.get<CadastroPet[]>(url);
  }

  cadastroAgendamento(nomePet: string, servico: string, data: string, observacao: string): Observable<string> {
    const url = 'http://localhost:5090/api/Cuidado/CadastrarServico';


    const params = new HttpParams()
      .set('nomePet', nomePet)
      .set('Servico', servico)
      .set('Data', data)
      .set('Observacao', observacao);

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<string>(url, {}, { headers, params });
  }

  buscaNomePetsToken(): Observable<string[]> {
    const url = 'http://localhost:5222/api/Pet/ListarNomePetsPorUsuario';
    return this.http.get<string[]>(url);
  }

  buscaAgendamentosPorPet(nomePet: string): Observable<Agendamento[]> {
    const url = 'http://localhost:5090/api/Cuidado/ListarAgendamentosPorPet';

    const params = new HttpParams()
      .set('nomePet', nomePet);


    return this.http.get<Agendamento[]>(url, { params });
  }

  excluirPet(id: number): Observable<CadastroPet[]> {
    const url = 'http://localhost:5222/api/Pet/';

    const params = new HttpParams()
      .set('id', id.toString());

    return this.http.delete<CadastroPet[]>(url, { params });

  }


  excluirAgendamento(idAgendamento: number): Observable<Agendamento[]> {
    const url = 'http://localhost:5090/api/Cuidado/DeletarAgendamento/';

    const params = new HttpParams()
      .set('id', idAgendamento.toString());

    return this.http.delete<Agendamento[]>(url, { params });

  }
  buscarNotificacoes(): Observable<Notificacao[]> {
    const urlZerarNotificacoes = 'http://localhost:5090/api/Notificacao/MarcarTodasNotificacaoComoLida';
    this.http.patch(urlZerarNotificacoes, {}).subscribe();



    const url = 'http://localhost:5090/api/Notificacao/ListarTodasNotificacoesUsuario';
    return this.http.get<Notificacao[]>(url);
  }

  numeroNotificacoes(): Observable<number> {
    const url = 'http://localhost:5090/api/Notificacao/TemNovaNotificacao';
    return this.http.get<number>(url);
  }

}
