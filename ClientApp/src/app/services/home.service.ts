import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private _http: HttpClient) { }

  getTopPosts(count: number){
    //this._http.get("uri", count)
  }
}
