import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlogCreate } from '../core/classes/blog/blogCreate';
import { BlogEdit } from '../core/classes/blog/blogEdit';
import { BlogFilter } from '../core/classes/blog/blogFilter';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor(private http: HttpClient) { }

  createNewBlog(newBlog: BlogCreate){
    newBlog.UserId = <string>localStorage.getItem('userId');
  }

  updateBlog(edited: BlogEdit){
    edited.UserId = <string>localStorage.getItem('userId');

  }

  getAllUserBlogs(userId: string){

  }

  getTopBlogs(count: number){

  }

  getAllBlogs(filter: BlogFilter){

  }
}
