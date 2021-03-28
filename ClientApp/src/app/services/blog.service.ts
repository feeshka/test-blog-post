import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlogCreate } from '../core/classes/blog/blog-create';
import { BlogEdit } from '../core/classes/blog/blog-edit';
import { BlogFilter } from '../core/classes/blog/blog-filter';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor(private _http: HttpClient) { }

  createNewBlog(newBlog: BlogCreate) {
    return this._http.post("https://localhost:44343/api/blog/new-blog", newBlog);
  }

  updateBlog(edited: BlogEdit) {
    edited.userId = <string>localStorage.getItem('userId');

  }

  getBlogById(blogId: number) {

  }

  getAllUserBlogs(userId: string) {

  }

  getTopBlogs(count: number) {

  }

  getAllBlogs(filter: BlogFilter) {

  }
}
