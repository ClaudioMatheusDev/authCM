import { Component, inject, signal } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly form = this.fb.group({
    nome: ['', Validators.required],
    dataNascimento: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    documento: ['', Validators.required],
    telefone: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(8)]]
  });

  readonly carregando = signal(false);
  readonly erro = signal<string | null>(null);

  registrar(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.carregando.set(true);
    this.erro.set(null);

    this.authService.registrar(this.form.getRawValue() as any).subscribe({
      next: () => {
        this.carregando.set(false);
        this.router.navigate(['/login']);
      },
      error: (err) => {
        this.carregando.set(false);
        this.erro.set(err.error ?? 'Não foi possível concluir o cadastro.');
      }
    });
  }
}
