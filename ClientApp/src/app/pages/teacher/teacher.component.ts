import { Component, OnInit, ViewChild } from '@angular/core';
import {SelectionModel} from '@angular/cdk/collections';
import {MatTableDataSource} from '@angular/material/table';
import { PeriodicElement } from 'app/shared/support/support.model';
import { TeachersService } from 'app/shared/teacher/teachers.service';
import { Teachers } from 'app/shared/teacher/teachers.model';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ToastrService } from 'ngx-toastr';
 
@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {

  constructor(public service: TeachersService ,private toastr: ToastrService) { }
  ngOnInit(): void {
  }
  // ELEMENT_DATA: Teachers[] = [
  //   {age:1,educationalBackground:12,fName:"asas",fieldName:"sds",lName:"sadsad",pathImg:"dsd",registerDate:null ,teachingExperience:121,userId:121 }
  // ];
  displayedColumns: string[] = ['select','userId', 'pathImg' , 'fName', 'lName','fieldName','age', 'educationalBackground' ,'registerDate' ,'teachingExperience'];
  //dataSource = new MatTableDataSource<Teachers>(this.ELEMENT_DATA);
  selection = new SelectionModel<Teachers>(true, []);
  dataSource:any;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  
  ngAfterViewInit()
  {
      this.service.requestGets(0,10).subscribe(
        res=>{
          this.dataSource = new MatTableDataSource<Teachers>(res['data']); 
         // this.dataSource.paginator = this.paginator;
         // this.dataSource.sort = this.sort;
        },
        err=>{
          this.toastr.error('خطا', err['error'].Message);
        })
  }

  
  selectRowTable(value : Teachers)
  {
    alert(value.fName)
  }
}
