import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BlogFilter } from 'src/app/core/classes/blog/blog-filter';
import { BlogInList } from 'src/app/core/classes/blog/blog-in-list';
import { BlogService } from 'src/app/services/blog.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  private _blogs: BlogInList[] = [];

  constructor(private _blogSrv: BlogService, private _toastr: ToastrService, private _fb: FormBuilder) { }

  get Blogs() { return this._blogs }

  ngOnInit(): void {
    this.getBlogs();
  }

  filterFormModel = this._fb.group({
    AuthorName: [''],
    PostName: [''],
    RatingFrom: [],
    RatingTo: []
  });

  getBlogs() {
    let filter: BlogFilter = {
      blogName: this.filterFormModel.value.PostName,
      ratingFrom: this.filterFormModel.value.RatingFrom,
      ratingTo: this.filterFormModel.value.RatingTo,
      dateFrom: '',
      dateTo: ''
    }

    this._blogSrv.getAll(filter)
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
