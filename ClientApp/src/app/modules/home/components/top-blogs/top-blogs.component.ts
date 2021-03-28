import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BlogInList } from 'src/app/core/classes/blog/blog-in-list';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-top-blogs',
  templateUrl: './top-blogs.component.html',
  styleUrls: ['./top-blogs.component.css']
})
export class TopBlogsComponent implements OnInit {

  private _topBlogs: BlogInList[] = [];

  constructor(private _homeSrv: HomeService, private _toastr: ToastrService) { }

  get TopBlogs() { return this._topBlogs }

  ngOnInit(): void {
    this.getTopBlogs();
  }

  getTopBlogs() {

    this._homeSrv.getTopBlogs('10')
      .subscribe(
        (res: any) => {
          this._topBlogs = <BlogInList[]>res
        },
        error => {
          this._toastr.error('', "Ошибка")
        }
      );
  }
}
