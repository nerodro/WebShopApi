import { Component } from '@angular/core';
import { AccountDetailService } from '../shared/account-detail.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-details',
  templateUrl: './login-details.component.html',
  styleUrls: ['./login-details.component.css']
})
export class LoginDetailsComponent {
  constructor(public service: AccountDetailService, private router: Router){}
  onSubmit(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.Login(form)
    }
}
ngOnInit(): void {
  this.service.Login();
}
Login(form:NgForm){
  this.service.formSubmitted = true;
  if(form.valid){
  this.service.Login().subscribe({
    next:res=>{
      
      this.router.navigate(['product/index'])
    },
    error:err=>{console.log(err, this.service.formData)}
  })
}
}
}
