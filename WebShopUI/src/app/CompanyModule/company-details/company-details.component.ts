import { Component } from '@angular/core';
import { CompanyDetailService } from '../shared/company-detail.service';
import { Router } from '@angular/router';
import { CompanyDetail } from '../shared/company-detail.model';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent {
  constructor(public service: CompanyDetailService, private router: Router){}
  ngOnInit(): void {
    this.service.allProduct();
  }
  populateForm(selectedRecord: CompanyDetail){
    this.router.navigate(['/company/viewcompany']),
    this.service.formData = Object.assign({},selectedRecord)
  }
  populateFormEdit(selectedRecord: CompanyDetail){
    this.router.navigate(['comapy/addcompany']),
    this.service.formData = Object.assign({},selectedRecord)
  }
  deleteproduct(id:number){
    this.service.DeleteComapyn(id)
    .subscribe({
      next:res=>{
        window.location.reload()
       this.service.list = res as CompanyDetail[];
      },
      error:err=>{console.log(err, this.service.formData)}
    })
  }
}
