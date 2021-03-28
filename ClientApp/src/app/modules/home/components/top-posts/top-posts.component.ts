import { Component, OnInit } from '@angular/core';
import { PostInList } from 'src/app/core/classes/post/post-in-list';
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
    //return this._homeSrv.getTopPosts(10);
  }
}
