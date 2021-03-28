import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/services/post.service';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { FormBuilder, Validators } from '@angular/forms';
import { BlogInSelect } from 'src/app/core/classes/blog/blog-in-select';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { PostCreate } from 'src/app/core/classes/post/post-create';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  private _blogs: BlogInSelect[] = [];
  private _blogId: string = '';
  private _editing: boolean = false;

  constructor(private _fb: FormBuilder, private _postSrv: PostService, private _location: Location, private _route: ActivatedRoute, private _toastr: ToastrService, private _router: Router) { }

  get Blogs(): BlogInSelect[] { return this._blogs }
  get Edit() { return this._editing }

  createNewFormModel = this._fb.group({
    PostName: ['', [Validators.required, Validators.minLength(10)]],
    PostContent: ['', [Validators.required, Validators.minLength(100)]],
    BlogId: ['', Validators.required]
  });

  ngOnInit(): void {
    this.setBlogSelectOptions();
    this.setEditMode();
  }

  setEditMode() {
    this._editing = this._route.snapshot.params.id > 0;
    if (this._editing)
      this.loadPostInfo();
  }

  loadPostInfo() {

  }

  setBlogSelectOptions() {
    this._postSrv.getBlogsForSelect()
      .subscribe(
        (res: any) => {
          this._blogs = <BlogInSelect[]>res
        },
        error => {
          this._toastr.error('Список блогов не загружен', "Ошибка");
        }
      )
  }

  onSubmit() {
    this._editing ? this.editPost() : this.createNewPost();
  }
  editPost() {
    let postEdit: PostCreate = {
      postName: this.createNewFormModel.value.PostName,
      postComment: this.createNewFormModel.value.PostContent,
      blogId: this._blogId,
      ownerUserId: <string>localStorage.getItem("UserId")
    }
    this._postSrv.updatePost(postEdit)
    .subscribe((result: any) => {
      console.log(result);
      this._router.navigateByUrl('/post/view/' + result);
      this._toastr.success("Новый пост создан!", "Успешно");
    },
      error => {
        this._toastr.error('', "Ошибка")

      });
  }
  createNewPost() {
    let postNew: PostCreate = {
      postName: this.createNewFormModel.value.PostName,
      postComment: this.createNewFormModel.value.PostContent,
      blogId: <string>this.createNewFormModel.value.BlogId,
      ownerUserId: <string>localStorage.getItem("UserId")
    }

    console.log(postNew);
    this._postSrv.createNewPost(postNew)
    .subscribe((result: any) => {
      console.log(result);
      this._router.navigateByUrl('/post/view/' + result);
      this._toastr.success("Новый пост создан!", "Успешно");
    },
      error => {
        this._toastr.error('', "Ошибка")

      });
  }

  goBack() {
    this._location.back();
  }
}
