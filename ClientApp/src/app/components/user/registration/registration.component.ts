import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  private _registerSuccess: boolean = false;

  get registered(){return this._registerSuccess}

  constructor(public userSrv: UserService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.userSrv.register().subscribe(
      (result: any) => {
        if(result.succeeded){
          this._registerSuccess = true;
          this.userSrv.regFormModel.reset();
        }
        else{
          result.errors.forEach((item: any) => {
            switch (item.code) {
              case "DuplicateUserName":
                console.log("DuplicateUserName");
                break;
            
              default:
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

}
