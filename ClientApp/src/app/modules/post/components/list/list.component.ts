import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
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

  constructor(private _postSrv: PostService, private _fb:FormBuilder) { }

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
      PostName: this.filterFormModel.value.PostName,
      RatingFrom: this.filterFormModel.value.RatingFrom,
      RatingTo: this.filterFormModel.value.RatingTo,
      DateFrom: '',
      DateTo: ''
    }
    this._posts = [
      {
	    Id: 0,
      OwnerUserId: '0000',
      OwnerName: 'OwnerName',
      PostName: 'PostName',
      PostShortComment: 'PostShortComment',
      PostCreationDate: '03-01-2020',
      PostRating: 2,
    },
    {
	    Id: 1,
      OwnerUserId: '0000',
      OwnerName: 'OwnerName2',
      PostName: 'PostName2',
      PostShortComment: 'PostShortComment2',
      PostCreationDate: '03-01-2020',
      PostRating: 2,
    }]
    //return this._postSrv.getPosts(filter);
  }
}
