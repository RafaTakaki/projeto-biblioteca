import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Agendamento } from '../models/agendamentos';
import { Notificacao } from '../models/notificacao';
import type { CadastroLivro, Reserva, Emprestimo } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:'; // Base da API

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
