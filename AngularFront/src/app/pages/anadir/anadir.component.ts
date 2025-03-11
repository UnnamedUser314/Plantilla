import { Component } from '@angular/core';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { ObjetoService } from 'src/app/service/objeto.service';
import { CreatePropuestaModel } from 'src/app/models/CreatePropuestaModel';
import { CreateUsuarioModel } from 'src/app/models/create-usuario-model';
import { Location } from '@angular/common';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-anadir',
  standalone: true,
  imports: [FormsModule, CommonModule], 
  templateUrl: './anadir.component.html',
  styleUrls: ['./anadir.component.css']
})
export class AnadirComponent { 
  propuesta: CreatePropuestaModel = { nombre: '', descripcion: '', tipo: '', estado: '' };
  usuario: CreateUsuarioModel = {nombre: '', email: ''};
  isFadingOut = false;

  constructor(private objetoService: ObjetoService, private location: Location,) {} 

  async crearObjeto() 
  {
    if (!this.usuario.nombre.trim() || !this.usuario.email.trim()) {
      alert('Rellene todos los campos, por favor.');
      return;
    }   

    try {
      await this.objetoService.createProduct(this.usuario).then(result =>{
        alert('Proyecto creado exitosamente');
      
      });
     // if (resultado) {
       // console.log('Producto creado:', resultado);
        alert('Producto creado exitosamente');
    //  } else {
        alert('Error al crear el producto.');
      }catch (error: any) {
      console.error('Error al crear el producto:', error);
     alert('Error al conectar con el servidor.');
   // }           
      }  
 }
    goBack() {
      this.isFadingOut = true;
      setTimeout(() => {
        this.location.back();
      }, 500); // Match the animation duration
    }
}
