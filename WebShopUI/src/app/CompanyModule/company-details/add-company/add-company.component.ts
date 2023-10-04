import { Component } from '@angular/core';
import { CompanyDetailService } from '../../shared/company-detail.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CompanyDetail } from '../../shared/company-detail.model';

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent {
  constructor(public service: CompanyDetailService, private router: Router){}
  addCompany(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.service.CreateCompany().subscribe({
      next:res=>{
       this.service.list = res as CompanyDetail[];
       this.service.allProduct();
      },
      error:err=>{console.log(err, this.service.formData)}
    })
  }
}
updateCompany(form:NgForm){
  this.service.formSubmitted = true;
  if(form.valid){
  this.service.EditCompany().subscribe({
    next:res=>{
     this.service.list = res as CompanyDetail[];
     this.service.allProduct();
    },
    error:err=>{console.log(err, this.service.formData)}
  })
}
}
onSubmit(form:NgForm){
  this.service.formSubmitted = true;
  if(form.valid){
  if(this.service.formData.id == 0)
  this.addCompany(form),
  this.router.navigate(['company/index'])
  else
  this.updateCompany(form),
  this.router.navigate(['company/index'])
  }
}
}
