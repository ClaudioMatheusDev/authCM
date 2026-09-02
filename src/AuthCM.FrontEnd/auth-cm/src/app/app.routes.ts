import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./pages/home/home.component').then((m) => m.HomeComponent) },
  { path: 'login', loadComponent: () => import('./pages/login/login.component').then((m) => m.LoginComponent) },
  {
    path: 'registro',
    loadComponent: () => import('./pages/register/register.component').then((m) => m.RegisterComponent)
  },
  {
    path: 'produtos',
    loadComponent: () => import('./pages/produtos/produtos.component').then((m) => m.ProdutosComponent),
    canActivate: [authGuard]
  },
  { path: '**', redirectTo: '' }
];
