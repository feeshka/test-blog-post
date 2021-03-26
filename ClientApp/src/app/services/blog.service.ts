import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlogCreate } from '../core/classes/blog/blog-create';
import { BlogEdit } from '../core/classes/blog/blog-edit';
import { BlogFilter } from '../core/classes/blog/blog-filter';

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

  getBlogById(blogId: number){
    
  }

  getAllUserBlogs(userId: string){

  }

  getTopBlogs(count: number){

  }

  getAllBlogs(filter: BlogFilter){

  }
}
