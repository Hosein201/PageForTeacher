import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from 'app/shared.service';
import { SupportCreate } from './support.model';

@Injectable({
  providedIn: 'root'
})
export class SupportService {

  constructor(public sharedService :SharedService , private httpClient:HttpClient) {}
    
   formDateCreate:SupportCreate=new SupportCreate();
   formDateUpdate:SupportCreate=new SupportCreate();

   requestCreate(){
    return this.httpClient.post( this.sharedService.baseUrlProject.concat("api/Support/CreateSupport"),
                                 this.formDateCreate);
  }

  requestUpdate(){
    return this.httpClient.post( this.sharedService.baseUrlProject.concat("api/Support/UpdateSupport"),
                                 this.formDateUpdate);
  }

  requestGet(){
    return this.httpClient.get( this.sharedService.baseUrlProject.concat("api/Support/GetSupports?skip=0&take=10"));
  }

}
