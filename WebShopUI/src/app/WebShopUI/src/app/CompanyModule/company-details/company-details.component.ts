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
    this.router.navigate(['/product/viewproduct']),
    this.service.formData = Object.assign({},selectedRecord)
  }
}
