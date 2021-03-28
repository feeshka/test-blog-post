import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private _http: HttpClient) { }

  getTopBlogs(count: string){
    return this._http.get("https://localhost:44343/api/home/top-blogs", {params: {count: count}});
  }

  getTopPosts(count: string){
    return this._http.get("https://localhost:44343/api/home/top-posts", {params: {count: count}});
  }
}
