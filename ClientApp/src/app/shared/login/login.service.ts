import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from 'app/shared.service';
import { Login } from './login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(public sharedService :SharedService , private httpClient:HttpClient) { }
  readonly url= this.sharedService.baseUrlProject.concat("api/User/Login");
  formDate:Login=new Login();

  requestLogin(){
    return this.httpClient.post(this.url,this.formDate);
  }
}
