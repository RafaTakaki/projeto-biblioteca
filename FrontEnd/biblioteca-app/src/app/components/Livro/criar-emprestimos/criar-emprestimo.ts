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
    ImagemPadraoComponent
],
  templateUrl: './criar-emprestimo.html',
  styleUrls: ['./criar-emprestimo.css'],
  providers: [provideNativeDateAdapter()],
})
export class CriarEmprestimoComponent {
  nomeDoLivro: string = '';

  constructor(private apiService: ApiService, private router: Router) { }

  onSubmit() {

  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
