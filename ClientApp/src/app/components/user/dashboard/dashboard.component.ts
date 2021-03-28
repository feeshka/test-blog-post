import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';
import { UserInfo } from 'src/app/core/classes/user/user-info';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  private _userInfo: UserInfo = new UserInfo;

  constructor(private _router: Router, private _userSrv: UserService, private _toastr: ToastrService) { }

  get UserInfo() { return this._userInfo }

  ngOnInit(): void {
    this._userSrv.getDashboardInfo().subscribe(
      (res: any) => {
        this._userInfo.email = res.email;
        this._userInfo.fullName = res.fullName;
        this._userInfo.userName = res.userName;
      },
      error => {
        this._toastr.error('', "Ошибка")
      });

    console.log(this._userInfo);
  }
  newBlog() {
    this._router.navigateByUrl('blog/new/0')
  }

  newPost() {
    this._router.navigateByUrl('post/new/0')
  }
}
