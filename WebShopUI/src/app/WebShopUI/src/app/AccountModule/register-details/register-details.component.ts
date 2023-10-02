import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountDetailService } from '../shared/account-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-details',
  templateUrl: './register-details.component.html',
  styleUrls: ['./register-details.component.css']
})
export class RegisterDetailsComponent {
  constructor(public service: AccountDetailService, private router: Router){}
  onSubmit(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.Register(form),
    this.router.navigate(['product/index'])
 }
}
  ngOnInit(): void {
    this.service.Register();
  }
  Register(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.service.Register().subscribe({
      next:res=>{},
      error:err=>{console.log(err, this.service.formData)}
    })
  }
}
}
