import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PostInList } from 'src/app/core/classes/post/post-in-list';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-top-posts',
  templateUrl: './top-posts.component.html',
  styleUrls: ['./top-posts.component.css']
})
export class TopPostsComponent implements OnInit {

  private _topPosts: PostInList[] = [];

  constructor(private _homeSrv: HomeService, private _toastr: ToastrService) { }

  get TopPosts(){return this._topPosts}

  ngOnInit(): void {
    this.getTopPosts();
  }

  getTopPosts(){

    this._homeSrv.getTopPosts('10')
    .subscribe(
      (res: any) => {
        this._topPosts = <PostInList[]>res
      },
      error => {
        this._toastr.error('', "Ошибка")
      }
    );
  }
}
