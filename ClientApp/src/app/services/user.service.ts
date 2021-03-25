import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppSettings } from '../apsettings';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient, private appSettings: AppSettings) { }

  regFormModel = this.fb.group({
      UserName: ['', Validators.required],
      Email: ['', Validators.email],
      Passwords: this.fb.group({
        Password: ['', [Validators.required, Validators.minLength(8)]],
        ConfirmPassword: ['']
      }, {validator: this.comparePasswords})
  });

  comparePasswords(fg: FormGroup){
    let confirmCtrl = fg.get('ConfirmPassword');

    if(confirmCtrl?.errors == null || 'mismatch' in confirmCtrl?.errors)
    {
      if(fg.get('Password')?.value != confirmCtrl?.value)
        confirmCtrl?.setErrors({mismatch: true});
      else
        confirmCtrl?.setErrors(null);
    }
  }

  register(){
    var newUser = {
      UserName: this.regFormModel.value.UserName,
      Email: this.regFormModel.value.Email,
      Password: this.regFormModel.value.Password
    }
    //this.http.get(this.appSettings.apiUri);
    console.log(newUser);
  }
}
