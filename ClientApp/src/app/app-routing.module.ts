import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { BlogsComponent } from './components/user/dashboard/blogs/blogs.component';
import { DashboardComponent } from './components/user/dashboard/dashboard.component';
import { PostsComponent } from './components/user/dashboard/posts/posts.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent },
    ]
  },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard],
  children: [
    { path: '', component: BlogsComponent },
    { path: 'posts', component: PostsComponent },
  ]
 },
  { path: 'home', loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule) },
  { path: 'blog', loadChildren: () => import('./modules/blog/blog.module').then(m => m.BlogModule) },
  { path: 'post', loadChildren: () => import('./modules/post/post.module').then(m => m.PostModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
