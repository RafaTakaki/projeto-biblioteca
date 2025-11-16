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
import type { Reserva } from '../../../models/cadastro-pet';

@Component({
  selector: 'app-gerenciar-reservas',
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
  templateUrl: './gerenciar-reservas.html',
  styleUrls: ['./gerenciar-reservas.css'],
  providers: [provideNativeDateAdapter()],
})
export class GerenciarReservasComponent {
  emailUsuario: string = '';
  tituloLivro: string = '';
  dataExpiracaoReserva: string = '';
  status: string = '';
  displayedColumns: string[] = ['emailUsuario', 'tituloLivro', 'dataExpiracaoReserva', 'status', 'criarEmprestimo'];

  // TODO remover mock após o fluxo ficar pronto
  reservas: Reserva[] = [
    {
      id: '1',
      idUsuario: '1',
      emailUsuario: 'teste@teste.com.br',
      idLivro: '1',
      tituloLivro: 'Teste',
      dataReserva: '16/11/2025',
      dataExpiracaoReserva: '16/11/2025',
      status: '0'
    },
    {
      id: '2',
      idUsuario: '2',
      emailUsuario: 'teste2@teste2.com.br',
      idLivro: '2',
      tituloLivro: 'Teste2',
      dataReserva: '16/11/2025',
      dataExpiracaoReserva: '16/11/2025',
      status: '0'
    },
  ];

  constructor(private apiService: ApiService, private router: Router,  private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.apiService.buscarReservasAtivas().subscribe({
      next: (response: Reserva[]) => {
        if (response != null) {
          this.reservas = response;
        }
      },
      error: (error) => {
        this.snackBar.open('Erro ao listar reservas.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }

  onCreate(reserva: Reserva): void {
    this.apiService.criarEmprestimo(reserva).subscribe({
      next: (response) => {
        this.snackBar.open('Emprestimo gerado com sucesso!', 'Fechar', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
          panelClass: ['success-snackbar']
        });
      },
      error: (error) => {
        this.snackBar.open('Erro ao gerar emprestimo. Tente novamente.', 'Fechar', {
          duration: 3000,
          panelClass: ['error-snackbar']
        });
      }
    });
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
