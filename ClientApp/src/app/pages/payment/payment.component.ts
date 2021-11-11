import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Payments } from 'app/shared/payment/payments.model';
import { PaymentsService } from 'app/shared/payment/payments.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
 
  displayedColumns: string[] = ['paymentId', 'amount', 'typePayment','registerDate','dcs' ,'userId'];
  data : Date = new Date();
  focus;
  focus1;
  closeResult: string;
  numberDetail:number;
  titelDetail:string;
  messageDetail:string;
  answerDetail:string;
  dataSource:any;
  
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  constructor(public service : PaymentsService ,private router : Router ,private modalService: NgbModal,
    private toastr: ToastrService) { }


  ngOnInit(): void {
  }
  // ELEMENT_DATA: Payments[] = [
  //   {paymentId:1,amount:12111.25,typePayment:1, registerDate:null ,dcs:'adasd'  ,userId:0  }
  // ];
  // dataSource = new MatTableDataSource<Payments>(this.ELEMENT_DATA); 


  ngAfterViewInit()
  {    
    this.service.requestGets(1,0,3).subscribe(
        res=>{
          this.dataSource = new MatTableDataSource<Payments>(res['data']); 
          // this.dataSource.paginator = this.paginator;
          // this.dataSource.sort = this.sort;
        },
        err=>{
          this.toastr.error('خطا', err['error'].Message);
        })
  }
}
