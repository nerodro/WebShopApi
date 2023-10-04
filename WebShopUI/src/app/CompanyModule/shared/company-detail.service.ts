import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CompanyDetail } from './company-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompanyDetailService {
  urlindex: string = environment.apiBase + '/Company/GelAllCompanys'
  urladd: string = environment.apiBase + '/Company/CreateCompany'
  urledit: string = environment.apiBase + '/Company/EditCompany'
  urldelete: string = environment.apiBase + '/Company/DeleteCompany'
  urlview: string = environment.apiBase + '/Company/GetSingleCompany'
  list:CompanyDetail[] = []
  formData: CompanyDetail = new CompanyDetail()
  formSubmitted:boolean=false;
  constructor(private http:HttpClient) { }
  allProduct(){
    this.http.get(this.urlindex).subscribe({
      next: res =>{
        this.list = res as CompanyDetail[]
      },
      error: err => {console.log(err)}
    })
  }
  viewcompany(data: CompanyDetail) {
    return this.http.get(this.urlview + '/' + data.id)/*.subscribe({
      next: rex =>{
        this.router.navigate(['/product/viewproduct'])
        this.formData = Object.assign({},data)
      }
    })*/
  }
  CreateCompany(){
    return this.http.post(this.urladd, this.formData)
  }
  EditCompany(){
    return this.http.put(this.urledit + '/' + this.formData.id, this.formData)
  }
  DeleteComapyn(id:number){
    return this.http.delete(this.urldelete + '/' + id)
  }
}
