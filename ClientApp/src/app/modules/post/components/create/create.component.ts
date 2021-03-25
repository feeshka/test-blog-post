import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/services/post.service';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(private fb: FormBuilder, public postSrv: PostService) { }


  createNewFormModel = this.fb.group({
    PostName: ['', [Validators.required, Validators.minLength(10)]],
    PostContent: ['', [Validators.required, Validators.minLength(100)]],
  });

  ngOnInit(): void {
  }
  editorConfig: AngularEditorConfig = {
    editable: true,
      spellcheck: true,
      height: 'auto',
      minHeight: '120px',
      maxHeight: '600px',
      width: 'auto',
      minWidth: '120',
      translate: 'yes',
      enableToolbar: true,
      showToolbar: true,
      placeholder: 'Что Вы хотите сказать?',
    // uploadUrl: 'v1/image',
    // upload: (file: File) => { ... }
    // uploadWithCredentials: false,
    // sanitize: true,
    // toolbarPosition: 'top',
    // toolbarHiddenButtons: [
    //   ['bold', 'italic'],
    //   ['fontSize']
    // ]
}

}
