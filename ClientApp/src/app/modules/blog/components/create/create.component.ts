import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BlogService } from 'src/app/services/blog.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogEdit } from 'src/app/core/classes/blog/blog-edit';
import { BlogCreate } from 'src/app/core/classes/blog/blog-create';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  private _editing: boolean = false;

  get Edit() { return this._editing }

  constructor(private _fb: FormBuilder, private _blogSrv: BlogService, private _location: Location, private _route: ActivatedRoute, private _router: Router, private _toastr: ToastrService) { }

  ngOnInit(): void {
    this._editing = this._route.snapshot.params.id > 0;
    if (this._editing)
      this.loadBlogInfo();
  }

  createNewFormModel = this._fb.group({
    BlogName: ['', [Validators.required, Validators.minLength(10)]],
    BlogComment: ['', [Validators.required, Validators.minLength(30)]],
    BlogImage: []
  });

  loadBlogInfo() {
    // let blog: BlogEdit = this._blogSrv.getBlogById(this._route.snapshot.params.id);
    // this.createNewFormModel.patchValue({
    //   BlogName: blog.BlogName,
    //   BlogComment: blog.BlogComment
    // });
  }

  onSubmit() {
    this._editing ? this.editBlog() : this.createNewBlog();
  }

  editBlog() {
    let editItem: BlogEdit = {
      blogName: this.createNewFormModel.value.BlogName,
      blogComment: this.createNewFormModel.value.BlogComment,
      blogId: 0,//TODO
      userId: ''
    };

    this._blogSrv.updateBlog(editItem);
  }

  createNewBlog() {
console.log(localStorage.getItem("UserId"));
    let newBlog: BlogCreate = {
      blogName: this.createNewFormModel.value.BlogName,
      blogComment: this.createNewFormModel.value.BlogComment,
      userId: <string>localStorage.getItem("UserId")
    };

    this._blogSrv.createNewBlog(newBlog).subscribe((result: any) => {
      console.log(result);
      this._router.navigateByUrl('/blog/view/' + result);
      this._toastr.success("Новый блог создан!", "Успешно");
    },
      error => {
        this._toastr.error('', "Ошибка")

      });

  }

  goBack() {
    this._location.back();
  }
}
