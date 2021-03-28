import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Post } from 'src/app/core/classes/post/post';
import { PostService } from 'src/app/services/post.service';
import { getPositionOfLineAndCharacter } from 'typescript';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  private _post: Post = new Post();

  constructor(private _postSrv: PostService, private _route: ActivatedRoute, private _toastr: ToastrService) { }

  get Post() { return this._post; }
  ngOnInit(): void {
    this.getPost()
  }

  getPost() {
    this._postSrv.getPostById(this._route.snapshot.params.id)
      .subscribe((result: any) => {
        this._post = result;
        console.log(result);
      },
        error => {
          this._toastr.error('Не удалось загрузить пост', "Ошибка")

        });
  }
}
