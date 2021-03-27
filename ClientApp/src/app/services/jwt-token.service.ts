import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class JwtTokenService {

  constructor() { }

  isTokenValid(){
    // let token = localStorage.getItem("token");
    // let decoded: any = {};
    // let now =this.getNowUTC();
    // if(token != null){
    //   decoded = jwt_decode(token);
    //   console.log(decoded);
    //   console.log(now);
    //   console.log(decoded.ExpDate < now);
    //   if(decoded.ExpDate < now)
    //     return false;
    //   else
    //     return true;
    // }
    // else{
    //   return false;
    // }
    return true;
  }

  private getNowUTC() {
    const now = new Date();
    return new Date(now.getTime() + (now.getTimezoneOffset() * 60000));
  }
}
