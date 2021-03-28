import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/auth/auth.guard';
import { CreateComponent } from './components/create/create.component';
import { ListComponent } from './components/list/list.component';
import { PostComponent } from './components/post/post.component';

const routes: Routes = [
  { path: '', component: ListComponent },
  { path: 'view/:id', component: PostComponent },
  { path: 'new/:id', component: CreateComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PostRoutingModule { }
