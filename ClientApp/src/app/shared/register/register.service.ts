import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from 'app/shared.service';
import { Register } from './register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(public sharedService :SharedService ,private httpClient:HttpClient) { }

  readonly url= this.sharedService.baseUrlProject.concat("api/User/Regsiter");
  formDate:Register=new Register();



  requestRegsiter(){
    return this.httpClient.post(this.url,this.formDate);
  }
}

