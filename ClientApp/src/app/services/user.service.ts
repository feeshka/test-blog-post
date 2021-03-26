import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserReg } from '../core/classes/user/user-reg';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  register(newUser: UserReg){
    return this.http.post("https://localhost:44343/api/auth/registration", newUser);
  }
}
