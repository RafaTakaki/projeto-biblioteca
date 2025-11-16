import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ImagemPadraoComponent } from "../../imagem-padrao/imagem-padrao.component";


@Component({
  selector: 'app-detalhes-pet',
  standalone: true,
  imports: [CommonModule, FormsModule, ImagemPadraoComponent],
  templateUrl: './detalhes-pet.component.html',
  styleUrls: ['./detalhes-pet.component.css']
})
export class DetalhesPetComponent {
  private route = inject(ActivatedRoute);
  private http = inject(HttpClient);
  private router = inject(Router);
  
  pet: any = {};

  constructor() {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get(`http://localhost:5222/api/Pet/BuscaPetPorId?id=${id}`)
  .subscribe({
    next: (data: any) => {
      console.log('Dados recebidos:', data); // Verifique se os dados chegam aqui
      this.pet = data;
    },
    error: (error) => {
      console.error('Erro ao buscar os dados:', error);
    }
  });
  }

  salvar() {
    const id = this.route.snapshot.paramMap.get('id');
    
    // Adicionando parâmetros via query na URL
    const novoNome = this.pet.nomePet;
    const novaIdade = this.pet.idadePet;
  
    // Modificando a URL para incluir parâmetros de query
    const url = `http://localhost:5222/api/Pet/AtualizarPet?IdPet=${id}&novoNome=${novoNome}&novaIdade=${novaIdade}`;
    
    this.http.patch(url, this.pet).subscribe({
      next: () => {
        alert('Atualizado com sucesso!');
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('Erro ao atualizar:', err);
        alert('Erro ao salvar as informações.');
      }
    });
  }
}
