import { Routes } from '@angular/router';
import { LoginComponent } from './components/login-page/login/login.component';
import { CriarContaComponent } from './components/login-page/criar-conta/criar-conta.component';
import { RecuperarSenhaComponent } from './components/login-page/recuperar-senha/recuperar-senha.component';
import { CadastrarLivroComponent } from './components/Livro/cadastrar-livro/cadastrar-livro';
import { AuthGuard } from './auth.guard';
import { FrontPageComponent } from './components/front-page/front-page.component';
import { CriarEmprestimoComponent } from './components/Livro/criar-emprestimos/criar-emprestimo';
import { CadastroAgendamentoComponent } from './components/agendamento/cadastro-agendamento/cadastro-agendamento.component';
import { NotificacoesComponent } from './components/notificacoes/notificacoes.component';
import { DetalhesPetComponent } from './components/Livro/detalhes-pet/detalhes-pet.component';


export const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'pet/:id',
        component: DetalhesPetComponent
    },
    {
        path: 'criar-conta',
        component: CriarContaComponent
    },
    {
        path: 'recuperar-senha',
        component: RecuperarSenhaComponent
    },
    {
        path: 'cadastrar-livro',
        component: CadastrarLivroComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'front-page',
        component: FrontPageComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'criar-emprestimos',
        component: CriarEmprestimoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'cadastro-agendamento',
        component: CadastroAgendamentoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'notificacoes',
        component: NotificacoesComponent,
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        redirectTo: 'front-page',
    }
];
