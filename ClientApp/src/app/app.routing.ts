import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { ComponentsComponent } from './components/components.component';
import { NucleoiconsComponent } from './components/nucleoicons/nucleoicons.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './Pages/login/login.component';
import { RegisterComponent } from './Pages/register/register.component';
import { LandingComponent } from './pages/landing/landing.component';
import { SupportComponent } from './pages/support/support.component';
import { AdminpaymentComponent } from './pages/adminpayment/adminpayment.component';
import { AdminsupportComponent } from './pages/adminsupport/adminsupport.component';
import { PaymentComponent } from './pages/payment/payment.component';
import { RegistereduComponent } from './pages/registeredu/registeredu.component';
import { TeacherComponent } from './pages/teacher/teacher.component';
import { ProfileComponent } from './pages/profile/profile.component';

const routes: Routes =[
    { path: '', redirectTo: 'landing', pathMatch: 'full' },


    { path: 'index',       component: HomeComponent },
    { path: 'login',       component: LoginComponent },
    { path: 'register',    component: RegisterComponent },
    { path: 'components',  component: ComponentsComponent },
    { path: 'nucleoicons', component: NucleoiconsComponent },
    { path:'landing',       component:LandingComponent},
    
    { path:'adminpayment',  component:AdminpaymentComponent},
    { path:'adminstudent',  component:AdminpaymentComponent}, 
    { path:'adminsupport',  component:AdminsupportComponent},
     
    { path:'payments',       component:PaymentComponent},
    { path:'register-edu',   component:RegistereduComponent}, 
    { path:'teachers',       component:TeacherComponent},
    { path:'supports',       component:SupportComponent},
    { path:'profile',       component:ProfileComponent}
];

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        RouterModule.forRoot(routes)
    ],
    exports: [
    ],
})
export class AppRoutingModule { }
