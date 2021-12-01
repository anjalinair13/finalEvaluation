import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient,private router :Router) { }

  //get an user

  getUserByPassword(user:User):Observable<any>{
    console.log(user.UserName);
    console.log(user.UserPassword);
    return this.httpClient.get(environment.apiUrl+"/api/user/getuser/"+user.UserName+"/"+user.UserPassword);
  }

    //Authorize retun token with roleId and username
    public loginVerify(user:User){
      //calling webservice url and passing username and password
      console.log("Attempt authenticate and authorize ::");
      console.log(user);
      return this.httpClient.get(environment.apiUrl+"/api/login/"+user.UserName+"/"+user.UserPassword);
    }


  public logout(){
    localStorage.removeItem('username');
    localStorage.removeItem('ACCESS_ROLE');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('jwtToken');
  }
}
