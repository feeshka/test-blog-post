import { Component, OnInit } from '@angular/core';
import { BlogInList } from 'src/app/core/classes/blog/blogInList';
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
	    Id: 0,
      OwnerName: 'OwnerName',
      BlogName: 'BlogName',
      BlogShortComment: 'BlogShortComment',
      BlogCreationDate: '03-01-2020',
      PostsCount: 1,
      BlogRating: 2,
    },
    {
	    Id: 1,
      OwnerName: 'OwnerName2',
      BlogName: 'BlogName2',
      BlogShortComment: 'BlogShortComment2',
      BlogCreationDate: '03-01-2020',
      PostsCount: 1000,
      BlogRating: 2,
    }]
    //return this._homeSrv.getTopBlogs(10);
  }

}
