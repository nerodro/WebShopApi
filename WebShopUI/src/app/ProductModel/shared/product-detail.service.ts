import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

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
  urldelete: string = environment.apiBase + '/Product/DeleteProduct'
  urlproduct:string = environment.apiBase+'/Category/GetProductsForCategory'
  list:ProductDetail[] = []
  formData: ProductDetail = new ProductDetail()
  formSubmitted:boolean=false;
  constructor(private http:HttpClient,public router:Router) {}
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
  viewproduct(data: ProductDetail) {
    return this.http.get(this.urlview + '/' + data.id)/*.subscribe({
      next: rex =>{
        this.router.navigate(['/product/viewproduct'])
        this.formData = Object.assign({},data)
      }
    })*/
  }
  viewproductcategory(categoryId:number){
    return this.http.get(this.urlproduct + '/' + categoryId).subscribe({
      next: res =>{
        this.list = res as ProductDetail[]
      },
      error: err => {console.log(err)}
    })
  }
  CreateProduct(){
    return this.http.post(this.urladd, this.formData)
  }
  UpdateProduct(){
    return this.http.put(this.urledit + '/' + this.formData.id, this.formData)
  }
  DeleteProduct(id:number){
    return this.http.delete(this.urldelete + '/' + id)
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.formData = new ProductDetail();
    this.formSubmitted = false;
  }
}
