import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule,FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})

export class LoginComponent {

  loginForm = new FormGroup({ 
  email: new FormControl(''),
  password: new FormControl('')
  });

  onSubmit() {
    console.log(this.loginForm.value);
  } 

}
