import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from 'app/shared.service';
import { Edu } from './edu.model';

@Injectable({
  providedIn: 'root'
})
export class EduService {

  constructor(private sharedService :SharedService , private httpClient:HttpClient) {}
    
  formDate:Edu=new Edu();
  requestCreate(){
   return this.httpClient.post( this.sharedService.baseUrlProject.concat("api/Edu/CreateEdu") ,this.formDate);
 }

 requestGetField(){
  return this.httpClient.get( this.sharedService.baseUrlProject.concat("api/Field/GetFields"));
 }
 
 requestGetTeachers(codeField:number){
  return this.httpClient.get( this.sharedService.baseUrlProject.concat("api/Teacher/GetTeachersByField?codeField="+codeField+""));
 }
}
