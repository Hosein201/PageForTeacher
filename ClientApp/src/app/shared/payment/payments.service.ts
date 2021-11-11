import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from 'app/shared.service';
import { Payments } from './payments.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {

 

  constructor(private sharedService :SharedService , private httpClient:HttpClient) {}

    formDate: Payments=new Payments();
    requestGets(userId :number , skip:number ,take:number){
    return this.httpClient.get( this.sharedService.baseUrlProject.concat("api/Student/GetPayment?userId="+userId+"&skip="+skip+"&take="+take+""));
  }
}
