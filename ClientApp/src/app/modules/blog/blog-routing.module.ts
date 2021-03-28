import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/auth/auth.guard';
import { BlogComponent } from './components/blog/blog.component';
import { CreateComponent } from './components/create/create.component';
import { ListComponent } from './components/list/list.component';

const routes: Routes = 
[
  { path: '', component: ListComponent },
  { path: 'new/:id', component: CreateComponent, canActivate: [AuthGuard] },
  { path: 'view/:id', component: BlogComponent },
  { path: 'view/:id/posts', loadChildren: () => import('../post/post.module').then(m => m.PostModule) },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BlogRoutingModule { }
