import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from 'app/shared.service';
import { Teachers } from './teachers.model';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {

  constructor(private sharedService :SharedService , private httpClient:HttpClient) {}
    
   formDate:Teachers=new Teachers();
   
 
  requestGets(skip:number,take:number){
    return this.httpClient.get( this.sharedService.baseUrlProject.concat("api/Teacher/GetTeachers?skip="+skip+"&take="+take+""));
  }
}
