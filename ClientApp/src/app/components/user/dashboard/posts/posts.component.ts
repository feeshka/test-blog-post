import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PostInList } from 'src/app/core/classes/post/post-in-list';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  private _posts: PostInList[] = [];

  constructor(private _userSrv: UserService, private _toastr: ToastrService) { }

  get Posts(){return this._posts}

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts() {
    this._userSrv.getCurrentUserPosts()
    .subscribe(
      (res: any) => {
        console.log(res);
        this._posts = <PostInList[]>res
      },
      error => {
        this._toastr.error('', "Ошибка")
      });;
  }

}
