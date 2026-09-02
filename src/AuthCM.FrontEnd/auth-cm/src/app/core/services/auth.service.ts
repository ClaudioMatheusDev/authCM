import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { LoginRequest, LoginResponse, RegisterRequest } from '../models/auth.model';

const TOKEN_KEY = 'authcm_token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = `${environment.apiUrl}/auth`;

  readonly logado = signal<boolean>(this.temToken());

  constructor(private readonly http: HttpClient) {}

  registrar(dados: RegisterRequest): Observable<{ idUsuario: number }> {
    return this.http.post<{ idUsuario: number }>(`${this.apiUrl}/register`, dados);
  }

  login(dados: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, dados).pipe(
      tap((resposta) => {
        localStorage.setItem(TOKEN_KEY, resposta.token);
        this.logado.set(true);
      })
    );
  }

  logout(): void {
    localStorage.removeItem(TOKEN_KEY);
    this.logado.set(false);
  }

  getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }

  private temToken(): boolean {
    return !!localStorage.getItem(TOKEN_KEY);
  }
}
