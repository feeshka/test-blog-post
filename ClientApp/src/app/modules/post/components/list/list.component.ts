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
      postName: this.filterFormModel.value.PostName,
      ratingFrom: this.filterFormModel.value.RatingFrom,
      ratingTo: this.filterFormModel.value.RatingTo,
      dateFrom: '',
      dateTo: ''
    }
    this._posts = [
      {
	    id: 0,
      ownerUserId: '0000',
      ownerName: 'OwnerName',
      postName: 'PostName',
      postShortComment: 'PostShortComment',
      postCreationDate: '03-01-2020',
      postRating: 2,
    },
    {
	    id: 1,
      ownerUserId: '0000',
      ownerName: 'OwnerName2',
      postName: 'PostName2',
      postShortComment: 'PostShortComment2',
      postCreationDate: '03-01-2020',
      postRating: 2,
    }]
    //return this._postSrv.getPosts(filter);
  }
}
