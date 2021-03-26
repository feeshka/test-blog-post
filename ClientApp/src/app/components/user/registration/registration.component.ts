import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserReg } from 'src/app/core/classes/user/user-reg';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private _fb: FormBuilder, private _userSrv: UserService, private _toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    var newUser: UserReg = {
      UserName: this.regFormModel.value.UserName,
      Email: this.regFormModel.value.Email,
      Password: this.regFormModel.value.Passwords.Password
    };

    this._userSrv.register(newUser).subscribe(
      (result: any) => {
        if(result.succeeded){
          this.regFormModel.reset();
          this._toastr.success("Регистрация прошла успешно!", "Успешно")
        }
        else{
          result.errors.forEach((item: any) => {
            switch (item.code) {
              case "DuplicateUserName":
                this._toastr.error("Пользователь с таким именем уже зарегистрирован", "Ошибка")
                break;
            
              default:
                this._toastr.error(item.description, "Ошибка")
                break;
            }
          });;
          
        }
      },
      error => {
        console.log(error);
      }
    )
  }


  regFormModel = this._fb.group({
    UserName: ['', Validators.required],
    Email: ['', [Validators.email, Validators.required]],
    Passwords: this._fb.group({
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

}
