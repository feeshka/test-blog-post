import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PostFilter } from 'src/app/core/classes/post/post-filter';
import { PostInList } from 'src/app/core/classes/post/post-in-list';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  private _posts: PostInList[] = [];

  constructor(private _postSrv: PostService, private _fb:FormBuilder, private _toastr: ToastrService) { }

  get Posts(){return this._posts}

  ngOnInit(): void {
    this.getPosts();
    
  }

  filterFormModel = this._fb.group({
    AuthorName: [''],
    PostName: [''],
    RatingFrom: [],
    RatingTo: []
  });

  getPosts(){
    let filter: PostFilter = {
      postName: this.filterFormModel.value.PostName,
      ratingFrom: this.filterFormModel.value.RatingFrom,
      ratingTo: this.filterFormModel.value.RatingTo,
      dateFrom: '',
      dateTo: ''
    }

    this._postSrv.getAll(filter)
    .subscribe(
      (res: any) => {
        this._posts = <PostInList[]>res
      },
      error => {
        this._toastr.error('', "Ошибка")
      }
    );
  }
}
