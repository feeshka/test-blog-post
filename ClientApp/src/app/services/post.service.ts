import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private fb: FormBuilder) { }

  createNewFormModel = this.fb.group({
    PostName: ['', [Validators.required, Validators.minLength(10)]],
    PostContent: ['', [Validators.required, Validators.minLength(100)]],
  })
}
