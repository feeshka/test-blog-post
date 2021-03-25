import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogComponent } from './components/blog/blog.component';
import { ListComponent } from './components/list/list.component';

const routes: Routes = 
[
  { path: '', component: ListComponent },
  { path: ':id', component: BlogComponent },
  { path: ':id/posts', loadChildren: () => import('../post/post.module').then(m => m.PostModule) },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BlogRoutingModule { }
