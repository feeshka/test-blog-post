import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from '../core/classes/user/user-login';
import { UserReg } from '../core/classes/user/user-reg';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  register(newUser: UserReg) {
    return this.http.post("http://localhost:5000/api/auth/registration", newUser);
  }

  login(user: UserLogin) {
    return this.http.post("http://localhost:5000/api/auth/login", user);
  }

  getDashboardInfo() {
    return this.http.get("http://localhost:5000/api/user/dashboard", { params: { userId: <string>localStorage.getItem('UserId') } });
  }

  getCurrentUserBlogs() {
    return this.http.get("http://localhost:5000/api/user/dashboard/current-user-blogs", { params: { userId: <string>localStorage.getItem('UserId') } });
  }

  getCurrentUserPosts() {
    return this.http.get("http://localhost:5000/api/user/dashboard/current-user-posts", { params: { userId: <string>localStorage.getItem('UserId') } });
  }

  userLoggedIn() {
    if (localStorage.getItem("token") == null)
      return false;
    else
      return true;
  }
}
