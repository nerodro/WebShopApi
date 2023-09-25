import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserDetailService } from '../../shared/user-detail.service';
import { UserDetail } from '../../shared/user-detail.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-details-form',
  templateUrl: './user-details-form.component.html',
  styleUrls: ['./user-details-form.component.css']
})
export class UserDetailsFormComponent {
  constructor(public service: UserDetailService, private router: Router){

  }
  onSubmit(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    if(this.service.formData.id == 0)
    this.insertRecord(form),
    this.router.navigate(['/user'])
    else
    this.updateRecord(form),
    this.router.navigate(['/user'])
  }
  }
  insertRecord(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.service.AddUser().subscribe({
      next:res=>{
       this.service.list = res as UserDetail[];
       this.service.resetForm(form);
      },
      error:err=>{console.log(err, this.service.formData)}
    })
  }
}
  populate(user: UserDetail){
    this.service.formData = Object.assign({}, user)
  }
  updateRecord(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.service.UpdateUser().subscribe({
      next:res=>{
       this.service.list = res as UserDetail[];
       this.service.resetForm(form);
      },
      error:err=>{console.log(err, this.service.formData)}
    })
  }
  }
}
