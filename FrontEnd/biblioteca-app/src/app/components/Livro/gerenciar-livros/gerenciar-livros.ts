import {Component} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {ApiService} from '../../../services/api.service';
import {Router} from '@angular/router';
import {ImagemPadraoComponent} from "../../imagem-padrao/imagem-padrao.component";
import {ChangeDetectionStrategy} from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';
import type { CadastroLivro } from '../../../models/model';

@Component({
  selector: 'app-gerenciar-livros',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatTableModule,
    MatIconModule,
    MatTooltipModule,
    MatSnackBarModule,
    ImagemPadraoComponent
  ],
  templateUrl: './gerenciar-livros.html',
  styleUrls: ['./gerenciar-livros.css'],
  providers: [provideNativeDateAdapter()],
})
export class GerenciarLivrosComponent {
  titulo: string = '';
  autor: string = '';
  categoria: string = '';
  isbn: string = '';
  quantidadeEstoque: string = '';
  mensagem: string = '';
  displayedColumns: string[] = [  'titulo', 'autor', 'quantidadeEstoque', 'editar', 'excluir'];

  livrosCadastrados: CadastroLivro[] = [];
  constructor(private apiService: ApiService, private router: Router,  private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.apiService.listarLivrosDisponiveis().subscribe({
      next: (response: CadastroLivro[]) => {
        this.livrosCadastrados = response;
      },
      error: (error) => {
        this.snackBar.open('Erro ao listar livros. Tente novamente.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }

  onDelete(livroParaDeletar: any): void {
    this.excluirLivro(livroParaDeletar);
  }

  onEdit(livroParaDeletar: CadastroLivro): void {
    this.abrirTelaDeEdicao(livroParaDeletar);
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('tipoUsuario');
    localStorage.removeItem('email');
    this.router.navigate(['/login']);
  }

  private excluirLivro(livroParaDeletar: any) {
    this.apiService.excluirLivro(livroParaDeletar.id).subscribe({
      next: (response) => {
        this.snackBar.open('Livro excluido com sucesso!', 'Fechar', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
          panelClass: ['success-snackbar']
        });
      },
      error: (error) => {
        this.snackBar.open('Erro ao excluir livro. Tente novamente.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }

  private abrirTelaDeEdicao(livroParaDeletar: CadastroLivro) {
    this.router.navigate(['/editar-livro'], {
      state: {
        livro: livroParaDeletar
      }
    });
  }
}
