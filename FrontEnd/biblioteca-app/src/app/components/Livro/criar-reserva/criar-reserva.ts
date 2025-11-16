import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ApiService } from '../../../services/api.service';
import { Router } from '@angular/router';
import { ImagemPadraoComponent } from "../../imagem-padrao/imagem-padrao.component";
import {ChangeDetectionStrategy} from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';
import type { CadastroLivro, Reserva } from '../../../models/model';

@Component({
  selector: 'app-formulario-agendamento',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatSnackBarModule,
    ImagemPadraoComponent
],
  templateUrl: './criar-reserva.html',
  styleUrls: ['./criar-reserva.css'],
  providers: [provideNativeDateAdapter()],
})
export class CriarReservaComponent {
  livros: string[] = [];
  nomeDoLivro: string = '';

  constructor(private apiService: ApiService, private router: Router, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.listarLivrosDisponiveis();
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  private listarLivrosDisponiveis() {
    this.apiService.listarLivrosDisponiveis().subscribe({
      next: (response) => {
        this.livros = response.livrosDisponiveis;
      },
      error: (error) => {
        this.snackBar.open('Erro ao listar livros.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }
}
