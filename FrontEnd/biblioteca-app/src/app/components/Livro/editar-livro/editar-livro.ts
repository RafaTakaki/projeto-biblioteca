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
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';
import type { CadastroLivro } from '../../../models/cadastro-pet';
import { input } from '@angular/core';

@Component({
  selector: 'app-editar-livro',
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
  templateUrl: './editar-livro.html',
  styleUrls: ['./editar-livro.css'],
  providers: [provideNativeDateAdapter()],
})
export class EditarLivroComponent {
  livroRecebido: CadastroLivro = {} as CadastroLivro;
  id: string = '';
  titulo: string = '';
  autor: string = '';
  isbn: string = '';
  categoria: string = '';
  quantidadeEstoque: string = '';
  mensagem: string = '';

  constructor(private apiService: ApiService, private router: Router, private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.preencheCamposDoFormularioComLivro();
  }

  onSubmit(): void {
    this.apiService.editarLivro({
      id: this.id,
      titulo: this.titulo,
      autor: this.autor,
      isbn: this.isbn,
      categoria: this.categoria,
      quantidadeEstoque: this.quantidadeEstoque
    } as CadastroLivro).subscribe({
      next: (response) => {
        this.snackBar.open('Livro cadastrado com sucesso!', 'Fechar', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
          panelClass: ['success-snackbar']
        });
      },
      error: (error) => {
        this.snackBar.open('Erro ao cadastrar livro. Tente novamente.', 'Fechar', {
          duration: 5000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  private preencheCamposDoFormularioComLivro(): void {
    const state = history.state;

    if (state && state['livro']) {
      const livroParaDeletar = state['livro'];
      this.id = livroParaDeletar.id;
      this.titulo = livroParaDeletar.titulo;
      this.autor = livroParaDeletar.autor;
      this.isbn = livroParaDeletar.isbn;
      this.categoria = livroParaDeletar.categoria;
      this.quantidadeEstoque  = livroParaDeletar.quantidadeEstoque;
    }
  }
}
