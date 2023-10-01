import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CompanyDetail } from './company-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompanyDetailService {
  urlindex: string = environment.apiBase + '/Company/GelAllCompanys'
  list:CompanyDetail[] = []
  formData: CompanyDetail = new CompanyDetail()
  constructor(private http:HttpClient) { }
  allProduct(){
    this.http.get(this.urlindex).subscribe({
      next: res =>{
        this.list = res as CompanyDetail[]
      },
      error: err => {console.log(err)}
    })
  }
}
