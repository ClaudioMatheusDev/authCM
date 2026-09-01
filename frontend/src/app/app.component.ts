import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(
    protected readonly authService: AuthService,
    private readonly router: Router
  ) {}

  sair(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
