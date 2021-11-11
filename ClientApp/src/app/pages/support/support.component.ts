import { Component, OnInit, ViewChild } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import * as Rellax from 'rellax';
import { PeriodicElement, Support } from 'app/shared/support/support.model';
import { SupportService } from 'app/shared/support/support.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons }from '@ng-bootstrap/ng-bootstrap';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class SupportComponent implements OnInit {
  data : Date = new Date();
  focus;
  focus1;
  closeResult: string;
  numberDetail:number;
  titelDetail:string;
  messageDetail:string;
  answerDetail:string;
  dataSource:any;
  
   
  displayedColumns: string[] = [ 'select','id', 'titel', 'message', 'isReadAdmin','answer','registerDate'];
  
  //expandedElement: PeriodicElement | null;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  constructor(public supportService : SupportService ,private router : Router ,private modalService: NgbModal,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.settingHtmlOnInit();
  }

  ngOnDestroy(){
    this.settingHtmlOnDestroy();
  }
  // ELEMENT_DATA: Support[] = [
  //   {id:1,titel:"asas",message:"sds",isReadAdmin:false,answer:"dsd",registerDate:null  }
  // ];
  // dataSource = new MatTableDataSource<Support>(this.ELEMENT_DATA); 
  ngAfterViewInit()
  {    
    this.supportService.requestGet().subscribe(
        res=>{
          this.dataSource = new MatTableDataSource<Support>(res['data']); 
          // this.dataSource.paginator = this.paginator;
          // this.dataSource.sort = this.sort;
        },
        err=>{
          this.toastr.error('خطا', err['error'].Message);
        })
}
 
  selectRowTable(value : Support)
  { 
    alert(value.id)
  }

  onSubmit(form:NgForm){
    this.supportService.requestCreate().subscribe(
    res=>{
           this.toastr.success('موفق', res['message']);
           
            this.ngAfterViewInit()
         },
   err=>{
          this.toastr.error('خطا', err['error'].Message);
        })
  }

  onSubmitUpdate(formUpdate:NgForm , element:any)
  {
    formUpdate.controls['id'].setValue(element.id);
 
    this.supportService.requestUpdate().subscribe(
      res=>{
        this.toastr.success('موفق', res['message']);
        this.ngAfterViewInit();
      },
     err=>{
            this.toastr.error('خطا', err['error'].Message);
          })
  }



  open(content ,data : Support) {
    
   
        this.modalService.open(content).result.then((result) => {
            this.closeResult = `Closed with: ${result}`;
        }, (reason) => {
            this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
    if(data !=null && data !=undefined)
    {
      this.numberDetail=data.id;
      this.titelDetail=data.titel;
      this.messageDetail=data.message;
      this.answerDetail=data.answer;
    }
  }

  private getDismissReason(reason: any): string {
      if (reason === ModalDismissReasons.ESC) {
          return 'by pressing ESC';
      } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
          return 'by clicking on a backdrop';
      } else {
          return  `with: ${reason}`;
      }
  }

  settingHtmlOnInit()
  {
    var rellaxHeader = new Rellax('.rellax-header');

    var body = document.getElementsByTagName('body')[0];
    body.classList.add('profile-page');
    //var navbar = document.getElementsByTagName('nav')[0];
    //navbar.classList.add('navbar-transparent');
  }

  settingHtmlOnDestroy()
  {
    var body = document.getElementsByTagName('body')[0];
    body.classList.remove('profile-page');
    //var navbar = document.getElementsByTagName('nav')[0];
    //navbar.classList.remove('navbar-transparent');
  }
}

