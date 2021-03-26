import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BlogService } from 'src/app/services/blog.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { BlogEdit } from 'src/app/core/classes/blog/blog-edit';
import { BlogCreate } from 'src/app/core/classes/blog/blog-create';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  private _editing: boolean = false;

  get edit(){return this._editing}

  constructor(private _fb: FormBuilder, private _blogSrv: BlogService, private _location: Location, private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this._editing = this._route.snapshot.params.id > 0;
    if(this._editing)
      this.loadBlogInfo();
  }

  createNewFormModel = this._fb.group({
    BlogName: ['', [Validators.required, Validators.minLength(10)]],
    BlogComment: ['', [Validators.required, Validators.minLength(30)]],
    BlogImage: []
  });

  loadBlogInfo(){
    // let blog: BlogEdit = this._blogSrv.getBlogById(this._route.snapshot.params.id);
    // this.createNewFormModel.patchValue({
    //   BlogName: blog.BlogName,
    //   BlogComment: blog.BlogComment
    // });
  }

  onSubmit(){
    this._editing ? this.editBlog() : this.createNewBlog();
  }

  editBlog(){
    let editItem: BlogEdit = {
      BlogName: this.createNewFormModel.value.BlogName,
      BlogComment: this.createNewFormModel.value.BlogComment,
      BlogId: 0,//TODO
      UserId: ''
    };

    this._blogSrv.updateBlog(editItem);
  }

  createNewBlog(){

    let newBlog: BlogCreate = {
      BlogName: this.createNewFormModel.value.BlogName,
      BlogComment: this.createNewFormModel.value.BlogComment,
      UserId: ''
    };

    this._blogSrv.createNewBlog(newBlog);

  }

  goBack(){
    this._location.back();
  }
}
