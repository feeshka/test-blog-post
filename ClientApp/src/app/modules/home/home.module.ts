import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './components/home/home.component';
import { TopBlogsComponent } from './components/top-blogs/top-blogs.component';
import { TopPostsComponent } from './components/top-posts/top-posts.component';


@NgModule({
  declarations: [HomeComponent, TopBlogsComponent, TopPostsComponent],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
