export interface RegisterRequest {
  nome: string;
  dataNascimento: string;
  email: string;
  documento: string;
  telefone: string;
  password: string;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  token: string;
}
