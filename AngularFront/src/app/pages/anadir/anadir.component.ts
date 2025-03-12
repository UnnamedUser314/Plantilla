import { Component } from '@angular/core';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ObjetoService } from 'src/app/service/objeto.service';
import { CreatePropuestaModel } from 'src/app/models/CreatePropuestaModel';
import { CreateUsuarioModel } from 'src/app/models/create-usuario-model';
import { Location } from '@angular/common';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-anadir',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './anadir.component.html',
  styleUrls: ['./anadir.component.css']
})
export class AnadirComponent {
  propuesta: CreatePropuestaModel = { nombre: '', descripcion: '', tipo: '', estado: '' };
  usuario: CreateUsuarioModel = { nombre: '', email: '' };
  isFadingOut = false;

  constructor(private router: Router,private objetoService: ObjetoService, private location: Location,) { }

  async crearObjeto() {
    if (!this.usuario.nombre.trim() || !this.usuario.email.trim()) {
      alert('Rellene todos los campos, por favor.');
      return;
    }

    try {
      await this.objetoService.createProduct(this.usuario);
      alert('Usuario creado exitosamente'); 
      this.router.navigate(['/principal']);
    } catch (error: any) {
      // console.error('Error al crear el usuario:' + error);
      // alert('Hubo un error al crear el usuario.');

      if (error.error instanceof ProgressEvent) {
        console.error('No JSON response. Possible server error:', error.message);
        alert('Error del servidor. Inténtelo más tarde.');
      } else {
        console.error('Error del API:', error.error);
        alert(error.error?.error || 'Hubo un error al crear el usuario.');
      }
    }
  }
  goBack() {
    this.isFadingOut = true;
    setTimeout(() => {
      this.location.back();
    }, 500); // Match the animation duration
  }
}
