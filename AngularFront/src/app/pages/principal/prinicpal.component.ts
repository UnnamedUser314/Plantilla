import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PropuestaComponent } from 'src/app/component/propuesta/propuesta.component';
import { propuestaModel } from 'src/app/models/propuestaModel';
import { UsuarioModel } from 'src/app/models/usuario-model';
import { ObjetoService } from 'src/app/service/objeto.service';

@Component(
{
  selector: 'app-principal',
  imports: [CommonModule, PropuestaComponent, RouterLink],
  standalone: true,
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})

export class PrincipalComponent{

  porpuestasList: UsuarioModel[] = [];

  constructor(private objetoService: ObjetoService){ 
    this.objetoService.getAllProduct().then((porpuestasList: UsuarioModel[]) => {
      this.porpuestasList = porpuestasList;
  });
}
}