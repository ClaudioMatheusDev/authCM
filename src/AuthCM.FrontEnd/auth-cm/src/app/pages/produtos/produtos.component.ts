import { Component, OnInit, signal } from '@angular/core';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { Produto } from '../../core/models/produto.model';
import { ProdutoService } from '../../core/services/produto.service';

@Component({
  selector: 'app-produtos',
  imports: [CurrencyPipe, DatePipe],
  templateUrl: './produtos.component.html',
  styleUrl: './produtos.component.css'
})
export class ProdutosComponent implements OnInit {
  readonly produtos = signal<Produto[]>([]);
  readonly carregando = signal(true);
  readonly erro = signal<string | null>(null);

  constructor(private readonly produtoService: ProdutoService) {}

  ngOnInit(): void {
    this.produtoService.listarTodos().subscribe({
      next: (produtos) => {
        this.produtos.set(produtos);
        this.carregando.set(false);
      },
      error: () => {
        this.erro.set('Não foi possível carregar os produtos.');
        this.carregando.set(false);
      }
    });
  }
}
