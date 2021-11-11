import { leadingComment } from '@angular/compiler';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSelect } from '@angular/material/select';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EduService } from 'app/shared/edu/edu.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registeredu',
  templateUrl: './registeredu.component.html',
  styleUrls: ['./registeredu.component.css']
})
export class RegistereduComponent implements OnInit {
  @ViewChild(MatSelect) fields: MatSelect;
  @ViewChild(MatSelect) teachers: MatSelect;
  dataField :any;
  dataTeacher:any;
  currentField:number;
  // data1:DropDown[]=[{id:1,name:"fdsfsd"},{id:2,name:"fdsxzxfsd"},{id:3,name:"fdszxzxzfsd"}];
  // data2:DropDown[]=[{id:1,name:"fdsfsdddddddddddd"},{id:2,name:"fdsxzxfsdddddddddddd"},{id:3,name:"fdszxzxzfsddddddddddd"}];
  disabledTeachers:boolean =true;
  constructor(private service: EduService ,private router : Router ,private modalService: NgbModal,
    private toastr: ToastrService) { }

  ngOnInit(): void {
   
  }
  ngAfterViewInit()
  {    
    // this.fields.id="fieldsid";
    // this.teachers.id="teachersid";

    this.service.requestGetField().subscribe(
      res=>{
        this.dataField= res['data']; 
      },
      err=>{
        this.toastr.error('خطا', err['error'].Message);
      })
  }

  onClickSelect(value:number, type : string){

        if(type=="optionField" && value > 0)
        {
          this.currentField=value;
          this.disabledTeachers=false;
          this.service.requestGetTeachers(this.currentField).subscribe(
            res=>{
              this.dataTeacher= res['data']; 
            },
            err=>{
              this.toastr.error('خطا', err['error'].Message);
            })
        }
        else if(type=="optionField" && value == 0){
          this.disabledTeachers=true;
          this.dataTeacher=[];
        }
  }

  onSubmit(form:NgForm){
    debugger;
    this.service.requestCreate().subscribe(
    res=>{
           this.toastr.success('موفق', res['message']);
           
            //this.ngAfterViewInit()
         },
   err=>{
          this.toastr.error('خطا', err['error'].Message);
        })
  }
}
