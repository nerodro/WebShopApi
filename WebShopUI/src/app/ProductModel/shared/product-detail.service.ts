import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {
  url:string = environment.apiBase+'/Product/ViewAllActiveProducts'
  urlall: string = environment.apiBase+'/Product/ViewAllProducts'
  urlhalt: string = environment.apiBase+'/Product/ViewAllHaltProducts'
  urlview: string = environment.apiBase +'/Product/GetSingleProduct'
  urladd: string = environment.apiBase + '/Product/CreateProduct'
  urledit: string = environment.apiBase + '/Product/EditProduct'
  list:ProductDetail[] = []
  formData: ProductDetail = new ProductDetail()
  formSubmitted:boolean=false;
  constructor(private http:HttpClient) {}
  refreshList(){
    this.http.get(this.url).subscribe({
      next: res =>{
        this.list = res as ProductDetail[]
      },
      error: err => {console.log(err)}
    })
}
allProduct(){
  this.http.get(this.urlall).subscribe({
    next: res =>{
      this.list = res as ProductDetail[]
    },
    error: err => {console.log(err)}
  })
}
  viewproduct(){
    return this.http.get(this.url + '/' + this.formData.id).subscribe({
      next: rex =>{
        this.formData
      }
    })
  }
  CreateProduct(){
    return this.http.post(this.urladd, this.formData)
  }
  UpdateProduct(){
    return this.http.put(this.urledit + '/' + this.formData.id, this.formData)
  }
}
