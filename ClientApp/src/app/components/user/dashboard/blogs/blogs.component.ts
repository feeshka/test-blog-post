import { Component, OnInit } from '@angular/core';
import { BlogInList } from 'src/app/core/classes/blog/blog-in-list';
import { UserService } from 'src/app/services/user.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css']
})
export class BlogsComponent implements OnInit {

  private _blogs: BlogInList[] = [];

  constructor(private _userSrv: UserService) { }

  get Blogs(){return this._blogs}

  ngOnInit(): void {

  }

  getBlogs() {
    this._userSrv.getCurrentUserBlogs().pipe(map(res=> this._blogs));
  }

}
