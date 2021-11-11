import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // this is needed!
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { ExamplesModule } from './examples/examples.module';
import { CookieService } from 'ngx-cookie-service';

import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { PagesComponent } from './pages/pages.component';
import { RegisterComponent } from './Pages/register/register.component';
import { LoginComponent } from './Pages/login/login.component';

import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './pages/home/home.component';
import { LandingComponent } from './pages/landing/landing.component';
import { SupportComponent } from './pages/support/support.component';
import {  MatTableModule } from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { TeacherComponent } from './pages/teacher/teacher.component';
import { AdminstudentComponent } from './pages/adminstudent/adminstudent.component';
import { PaymentComponent } from './pages/payment/payment.component';
import { AdminpaymentComponent } from './pages/adminpayment/adminpayment.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RegistereduComponent } from './pages/registeredu/registeredu.component';
import { AdminsupportComponent } from './pages/adminsupport/adminsupport.component';
import {MatSelectModule} from '@angular/material/select';

@NgModule({
    declarations: [
        
        AppComponent,
        NavbarComponent,
        PagesComponent,
        RegisterComponent,
        LoginComponent,
        HomeComponent,
        LandingComponent,
        SupportComponent,
        TeacherComponent,
        AdminstudentComponent,
        PaymentComponent,
        AdminpaymentComponent,
        ProfileComponent,
        RegistereduComponent,
        AdminsupportComponent,
        
        
    ],
    imports: [
        BrowserAnimationsModule,
        NgbModule,
        FormsModule,
        RouterModule,
        AppRoutingModule,
        ComponentsModule,
        ExamplesModule,
        HttpClientModule,
        MatTableModule,
        MatCheckboxModule,
        MatSortModule,
        MatPaginatorModule,
        MatSelectModule,
        ToastrModule.forRoot() // ToastrModule added
        ],
       
        
    providers: [CookieService ],
    bootstrap: [AppComponent]
})
export class AppModule { }
