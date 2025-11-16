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

  // TODO remover mock após o fluxo ficar pronto
  livrosCadastrados: CadastroLivro[] = [
    {
      id: '1',
      titulo: 'Teste',
      autor: 'Teste',
      isbn: 'Teste',
      categoria: 'Teste',
      quantidadeEstoque: '10'
    },
    {
      id: '2',
      titulo: 'Teste2',
      autor: 'Teste2',
      isbn: 'Teste2',
      categoria: 'Teste2',
      quantidadeEstoque: '5'
    },
  ];

  constructor(private apiService: ApiService, private router: Router,  private snackBar: MatSnackBar) {
  }

  onDelete(livroParaDeletar: any): void {
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

  onEdit(livroParaDeletar: CadastroLivro): void {
    this.router.navigate(['/editar-livro'], {
      state: {
        livro: livroParaDeletar
      }
    });
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
