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
@Component({
  selector: 'app-meus-livros',
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
    ImagemPadraoComponent
  ],
  templateUrl: './meus-livros.html',
  styleUrls: ['./meus-livros.css'],
  providers: [provideNativeDateAdapter()],
})
export class MeusLivrosComponent {
  titulo: string = '';
  autor: string = '';
  categoria: string = '';
  isbn: string = '';
  quantidadeEstoque: string = '';
  mensagem: string = '';
  displayedColumns: string[] = [  'titulo', 'autor', 'quantidadeEstoque', 'editar', 'excluir'];

  livrosCadastrados = [
    {
      titulo: 'Teste',
      autor: 'Teste',
      quantidadeEstoque: '10'
    },
    {
      titulo: 'Teste2',
      autor: 'Teste2',
      quantidadeEstoque: '5'
    },
  ];

  constructor(private apiService: ApiService, private router: Router) {
  }

  onSubmit() {
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
