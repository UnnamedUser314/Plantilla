import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/Auth.service';
import { LoginDTO } from '../../models/loginDTO';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  isFadingOut = false;

  constructor(private authService: AuthService, private router: Router) {}

  async login() {
    const loginDto: LoginDTO = {
      email: this.email, 
      password: this.password,
      token: ''
    };
    try {
      const response = await firstValueFrom(this.authService.login(loginDto));
      if (response?.result?.token) {
        localStorage.setItem('token', response.result.token);
        this.isFadingOut = true;
        setTimeout(() => {
          this.router.navigate(['/principal']);
        }, 500);        
      } else {
        alert('Error: Usuario o contraseña incorrectos.');
      }      
    } catch (error: any) {
      alert(error.message);
    }
  }

  goToRegister() {
    this.isFadingOut = true;
    setTimeout(() => {
      this.router.navigate(['/registro']);
    }, 500); 
  }
}