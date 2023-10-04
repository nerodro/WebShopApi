import { Component } from '@angular/core';
import { CompanyDetailService } from '../../shared/company-detail.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CompanyDetail } from '../../shared/company-detail.model';

@Component({
  selector: 'app-view-company',
  templateUrl: './view-company.component.html',
  styleUrls: ['./view-company.component.css']
})
export class ViewCompanyComponent {
  constructor(public service: CompanyDetailService, private router: Router){}
  onSubmit(form:NgForm){
    if(form.valid){
    if(this.service.formData.id != 0)
    this.populate
  }
  
  }
  populate(user: CompanyDetail){
    this.service.formData = Object.assign({}, user)
  }
}
