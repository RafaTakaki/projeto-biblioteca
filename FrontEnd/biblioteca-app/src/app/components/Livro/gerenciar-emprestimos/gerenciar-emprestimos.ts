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
import type { Emprestimo } from '../../../models/model';

@Component({
  selector: 'app-gerenciar-emprestimos',
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
  templateUrl: './gerenciar-emprestimos.html',
  styleUrls: ['./gerenciar-emprestimos.css'],
  providers: [provideNativeDateAdapter()],
})
export class GerenciarEmprestimoComponent {
  idUsuario: string = '';
  idLivro: string = '';
  dataEmprestimo: string = '';
  dataDevolucaoPrevista: string = '';
  dataDevolucaoReal: string = '';
  status: string = '';
  displayedColumns: string[] = [
    'idUsuario',
    'idLivro',
    'dataEmprestimo',
    'dataDevolucaoPrevista',
    'dataDevolucaoReal',
    'status',
    'criarDevolucao'
  ];

  emprestimos: Emprestimo[] = [];

  constructor(private apiService: ApiService, private router: Router,  private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.buscarEmprestimosAtivos();
  }

  onDevolucao(emprestimo: Emprestimo): void {
    this.devolverEmprestimo(emprestimo);
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  private devolverEmprestimo(emprestimo: Emprestimo): void {
    this.apiService.devolverEmprestimo(emprestimo).subscribe({
      next: (response) => {
        this.snackBar.open('Devolução gerada com sucesso!', 'Fechar', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
          panelClass: ['success-snackbar']
        });
      },
      error: (error) => {
        this.snackBar.open('Erro ao gerar devolução. Tente novamente.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }

  private buscarEmprestimosAtivos(): void {
    this.apiService.buscarEmprestimosAtivos().subscribe({
      next: (response) => {
        if (response != null) {
          this.emprestimos = response.emprestimosAtivos;
        }
      },
      error: (error) => {
        this.snackBar.open('Erro ao listar emprestimos.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }
}
