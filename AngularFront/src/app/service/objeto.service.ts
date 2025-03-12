import { Injectable } from '@angular/core';
import { propuestaModel } from '../models/propuestaModel';
import { CreatePropuestaModel } from '../models/CreatePropuestaModel';
import { CreateUsuarioModel } from '../models/create-usuario-model';
import { UsuarioModel } from '../models/usuario-model';

@Injectable({
  providedIn: 'root'
})
export class ObjetoService {
  readonly baseUrl = 'https://localhost:7016/api/Usuario';

  constructor() { }

  private getAuthHeaders(): { [key: string]: string } {
    const token = localStorage.getItem('token');
    return {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    };
  }

  async getAllProduct(): Promise<UsuarioModel[]> {
    const response = await fetch(this.baseUrl, {
      method: 'GET',
      headers: this.getAuthHeaders()
    });
    return (await response.json()) ?? [];
  }

  async getProductById(id: number): Promise<UsuarioModel | undefined> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: 'GET',
      headers: this.getAuthHeaders()
    });
    return (await response.json()) as UsuarioModel | undefined;
  }

  async getProductByUsuario(): Promise<UsuarioModel[]> {
    const response = await fetch(`${this.baseUrl}/user`, {
      method: 'GET',
      headers: this.getAuthHeaders()
    });
    return (await response.json()) ?? [];
  }

  async updateProduct(id: number, partialProduct: Partial<UsuarioModel>): Promise<UsuarioModel> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: "PUT",
      headers: this.getAuthHeaders(),
      body: JSON.stringify(partialProduct)
    });

    return await response.json();
  }

  async createProduct(product: CreateUsuarioModel): Promise<CreateUsuarioModel> {
    const response = await fetch(this.baseUrl, {
      method: "POST",
      headers: this.getAuthHeaders(),
      body: JSON.stringify(product)
    });

    if (!response.ok) {
     
      const errorText = await response.text();
      console.error("API error response:", errorText);

      try {
        
        const errorJson = JSON.parse(errorText);
        throw new Error(errorJson.error || "Error desconocido en la API");
      } catch {
        throw new Error(errorText || "Error desconocido");
      }
    }

    try {
      return await response.json(); 
    } catch {
      throw new Error("La respuesta del servidor no es JSON válido");
    }
  }

  async deleteProduct(id: number): Promise<boolean> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: "DELETE",
      headers: this.getAuthHeaders()
    });

    return response.ok;
  }

}
