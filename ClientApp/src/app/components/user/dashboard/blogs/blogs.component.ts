import { Component, OnInit } from '@angular/core';
import { BlogInList } from 'src/app/core/classes/blog/blog-in-list';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css']
})
export class BlogsComponent implements OnInit {

  private _blogs: BlogInList[] = [];

  constructor(private _userSrv: UserService, private _toastr: ToastrService) { }

  get Blogs(){return this._blogs}

  ngOnInit(): void {
    this.getBlogs();
  }

  getBlogs() {
    this._userSrv.getCurrentUserBlogs()
    .subscribe(
      (res: any) => {
        console.log(res);
        this._blogs = <BlogInList[]>res
        console.log(this._blogs);
      },
      error => {
        this._toastr.error('', "Ошибка")
      });;
  }

}
