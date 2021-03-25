import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostRoutingModule } from './post-routing.module';
import { PostComponent } from './components/post/post.component';
import { CreateComponent } from './components/create/create.component';
import { ListComponent } from './components/list/list.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [PostComponent, CreateComponent, ListComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AngularEditorModule,
    HttpClientModule,
    PostRoutingModule
  ]
})
export class PostModule { }
