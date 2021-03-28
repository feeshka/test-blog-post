import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PostCreate } from '../core/classes/post/post-create';
import { PostFilter } from '../core/classes/post/post-filter';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _http: HttpClient) { }

  getBlogsForSelect() {
    return this._http.get("https://localhost:44343/api/post/get-blog-select-options", {params: {userId: <string>localStorage.getItem('UserId')}});
  }

  getPostById(id: string) {
    return this._http.get("https://localhost:44343/api/post/get-post", {params: {id: id}});
  }

  getAll(filter: PostFilter) {
    return this._http.post("https://localhost:44343/api/post/list", filter);
  }

  createNewPost(newPost: PostCreate) {
    return this._http.post("https://localhost:44343/api/post/create", newPost);
  }

  updatePost(updated: PostCreate) {
    return this._http.post("https://localhost:44343/api/post/update", updated);
  }
}
