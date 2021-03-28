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

  updateBlog(updated: BlogCreate) {
    return this._http.post("https://localhost:44343/api/blog/update", updated);
  }

  getPostById(id: string) {
    return this._http.get("https://localhost:44343/api/blog/get-blog", {params: {id: id}});
  }

  getAll(filter: BlogFilter) {
    return this._http.post("https://localhost:44343/api/blog/list", filter);
  }
}
