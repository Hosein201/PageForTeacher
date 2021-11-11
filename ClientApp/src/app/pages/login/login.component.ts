import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'app/shared/login/login.service';
import { CookieService } from 'ngx-cookie-service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  data : Date = new Date();
  focus;
  focus1;

  constructor(public loginService : LoginService ,private router : Router ,
                 private toastr: ToastrService,private cookieService: CookieService ) { }

  ngOnInit() {
    var body = document.getElementsByTagName('body')[0];
    body.classList.add('login-page');
    body.querySelectorAll(".navbar").forEach(el => el.remove());
  }
  ngOnDestroy(){
      var body = document.getElementsByTagName('body')[0];
      body.classList.remove('login-page');

      body.querySelectorAll(".navbar").forEach(el => el.remove());

  }

  onSubmit(form:NgForm){

    this.router.navigate(['index']);
    // this.loginService.requestLogin().subscribe(
          //  res=>{
          //         this.cookieService.delete('Bearer');
          //        // this.cookieService.delete('expires_in');

          //         this.cookieService.set('Bearer',res["data"].access_token);
          //          //this.cookieService.set('Bearer',res["data"].expires_in);
                  
          //         this.router.navigate(['index']);
          //       },
          // err=>{
          //        this.toastr.error('خطا', err['error'].Message);
          //      }
    //)
  } 
}
