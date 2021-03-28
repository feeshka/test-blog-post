import { Component, OnInit } from '@angular/core';
import { BlogInList } from 'src/app/core/classes/blog/blog-in-list';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-top-blogs',
  templateUrl: './top-blogs.component.html',
  styleUrls: ['./top-blogs.component.css']
})
export class TopBlogsComponent implements OnInit {

  private _topBlogs: BlogInList[] = [];

  constructor(private _homeSrv: HomeService) { }

  get TopBlogs(){return this._topBlogs}

  ngOnInit(): void {
    this.getTopBlogs();
  }

  getTopBlogs(){
    this._topBlogs = [
      {
	    id: 0,
      ownerName: 'OwnerName',
      blogName: 'BlogName',
      blogShortComment: 'BlogShortComment',
      blogCreationDate: '03-01-2020',
      postsCount: 1,
      blogRating: 2,
    },
    {
	    id: 1,
      ownerName: 'OwnerName2',
      blogName: 'BlogName2',
      blogShortComment: 'BlogShortComment2',
      blogCreationDate: '03-01-2020',
      postsCount: 1000,
      blogRating: 2,
    }]
    //return this._homeSrv.getTopBlogs(10);
  }

}
