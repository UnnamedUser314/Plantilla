import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ObjetoService } from 'src/app/service/objeto.service';
import { propuestaModel } from '../../models/propuestaModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UsuarioModel } from 'src/app/models/usuario-model';

@Component({
  selector: 'app-propuesta-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './propuesta-page.component.html',
  styleUrls: ['./propuesta-page.component.css']
})
export class PropuestaPageComponent implements OnInit {
  propuestaId: number | null = null;
  propuesta: UsuarioModel = { id: 0, nombre: '', email: ''};
  isFadingOut = false;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private objetoService: ObjetoService
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.propuestaId = +id;
        this.cargarPropuesta();
      }
    });
  }

  async cargarPropuesta() {
    if (this.propuestaId) {
      const objetoData = await this.objetoService.getProductById(this.propuestaId);
      if (objetoData) {
        this.propuesta = objetoData;
      }
      console.log(this.propuesta.email.length)
    }
  }

  async actualizarPropuesta() {
    if (this.propuestaId) {
      try {
        await this.objetoService.updateProduct(this.propuestaId, this.propuesta);
        alert('Propuesta actualizado correctamente.');
      } catch (error) {
        console.error('Error al actualizar el proyecto', error);
        alert('Hubo un error al actualizar el proyecto.');
      }
    }
  }

  async eliminarPropuesta() {
    if (this.propuestaId) {
      const confirmacion = confirm('¿Estás seguro de que deseas eliminar este proyecto?');
      if (confirmacion) {
        try {
          await this.objetoService.deleteProduct(this.propuestaId);
          alert('Objeto eliminado correctamente.');
          this.location.back();
        } catch (error) {
          console.error('Error al eliminar el proyecto', error);
          alert('Hubo un error al eliminar el proyecto.');
        }
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
