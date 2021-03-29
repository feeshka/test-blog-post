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
    return this._http.post("http://localhost:5000/api/blog/new-blog", newBlog);
  }

  updateBlog(updated: BlogCreate) {
    return this._http.post("http://localhost:5000/api/blog/update", updated);
  }

  getBlogById(id: string) {
    return this._http.get("http://localhost:5000/api/blog/get-blog", {params: {id: id}});
  }

  getBlogPosts(id: string) {
    return this._http.get("http://localhost:5000/api/blog/get-blog-posts", {params: {id: id}});
  }

  getAll(filter: BlogFilter) {
    return this._http.post("http://localhost:5000/api/blog/list", filter);
  }
}
