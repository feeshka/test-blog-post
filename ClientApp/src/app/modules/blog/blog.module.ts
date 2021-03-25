import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlogRoutingModule } from './blog-routing.module';
import { BlogComponent } from './components/blog/blog.component';
import { ListComponent } from './components/list/list.component';
import { CreateComponent } from './components/create/create.component';


@NgModule({
  declarations: [BlogComponent, ListComponent, CreateComponent],
  imports: [
    CommonModule,
    BlogRoutingModule
  ]
})
export class BlogModule { }
