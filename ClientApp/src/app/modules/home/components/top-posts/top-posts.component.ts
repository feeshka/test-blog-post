import { Component, OnInit } from '@angular/core';
import { PostInList } from 'src/app/core/classes/post/postInList';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-top-posts',
  templateUrl: './top-posts.component.html',
  styleUrls: ['./top-posts.component.css']
})
export class TopPostsComponent implements OnInit {

  private _topPosts: PostInList[] = [];

  constructor(private _homeSrv: HomeService) { }

  get TopPosts(){return this._topPosts}

  ngOnInit(): void {
    this.getTopPosts();
  }

  getTopPosts(){
    this._topPosts = [
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
    //return this._homeSrv.getTopPosts(10);
  }
}
