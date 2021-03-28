import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BlogService } from 'src/app/services/blog.service';
import { Location } from '@angular/common';
import { Blog } from 'src/app/core/classes/blog/blog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PostInList } from 'src/app/core/classes/post/post-in-list';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  private _blog: Blog = new Blog();
  private _posts: PostInList[] = [];

  constructor(private _blogSrv: BlogService, private _route: ActivatedRoute, private _toastr: ToastrService) { }

  get Blog() { return this._blog; }
  get Posts() { return this._posts; }

  ngOnInit(): void {
    this.getBlog();
    this.getBlogPosts();
  }

  getBlog() {
    this._blogSrv.getBlogById(this._route.snapshot.params.id)
      .subscribe((result: any) => {
        this._blog = result;
        console.log(result);
      },
        error => {
          this._toastr.error('Не удалось загрузить блог', "Ошибка")
        });
  }

  getBlogPosts(){
    this._blogSrv.getBlogPosts(this._route.snapshot.params.id)
    .subscribe((result: any) => {
      this._posts = result;
      console.log(result);
    },
      error => {
        this._toastr.error('Не удалось загрузить gjcns', "Ошибка")
      });
  }
}
