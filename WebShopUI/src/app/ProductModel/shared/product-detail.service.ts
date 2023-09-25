import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {
  url:string = environment.apiBase+'/ViewAllActiveProducts'
  urlview: string = environment.apiBase +'/GetSingleProduct'
  list:ProductDetail[] = []
  formData: ProductDetail = new ProductDetail()
  constructor(private http:HttpClient) {}
  refreshList(){
    this.http.get(this.url).subscribe({
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
}
