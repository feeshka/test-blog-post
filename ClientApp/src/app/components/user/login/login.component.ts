import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserLogin } from 'src/app/core/classes/user/user-login';
import { UserLoginResult } from 'src/app/core/classes/user/user-login-result';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _fb: FormBuilder, private _userSrv: UserService, private _router: Router, private _toastr: ToastrService) { }

  ngOnInit(): void {
  }

  loginFormModel = this._fb.group({
    Email: [''],
    Password: ['']
  });

  onSubmit(){
    let user: UserLogin = {
      Email: this.loginFormModel.value.Email,
      Password: this.loginFormModel.value.Password
    }
    this._userSrv.login(user).subscribe(
      (result: any)=>{
        console.log(result);
        if(result.success == true){
          localStorage.setItem("token", result.token);
          localStorage.setItem("token", result.UserId);
          this._router.navigateByUrl('/home')
          this._toastr.success("Вход выполнен!", "Успешно")
        }
        else{
          this._toastr.error(result.message, "Ошибка")
        }
      },
      error=>{
        this._toastr.error('' ,"Ошибка")

      }
    )
  }

}
