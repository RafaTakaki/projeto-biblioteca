import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5016/api/Usuario/Login';

  private http = inject(HttpClient);

  login(email: string, password: string): Observable<any> {
    console.info('Login:', email, password);

    const body = {
      email: email,
      senha: password
    };

    // Configura o cabeçalho para especificar o tipo de conteúdo como JSON
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    // Envia a requisição POST com o cabeçalho correto
    return this.http.post<any>(this.apiUrl, body, { headers }).pipe(
      catchError(error => {
        console.error('Erro no login:', error);
        const errorMessage = error.error ? error.error : 'Erro desconhecido. Tente novamente.';
        return throwError(() => new Error(errorMessage));
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }
}
