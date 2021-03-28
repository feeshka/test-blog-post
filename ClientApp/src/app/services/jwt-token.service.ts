import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class JwtTokenService {

  constructor() { }

  isTokenValid(){
    let token = localStorage.getItem("token");
    let decoded: any = {};
      console.log(token);
      let now =this.getNowUTC();
    if(token != null){
      decoded = jwt_decode(token);
      if(decoded.ExpDate < now)
        return false;
      else
        return true;
    }
    else{
      return false;
    }
  }

  private getNowUTC() {
    const now = new Date();
    return new Date(now.getTime() + (now.getTimezoneOffset() * 60000));
  }
}
