import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CoreDetail } from './core-detail.model';
import { HttpClient } from '@angular/common/http';
import { ProductDetail } from 'src/app/ProductModel/shared/product-detail.model';

@Injectable({
  providedIn: 'root'
})
export class CoreDetailService {
  url:string = environment.apiBase+'/Category/GetAllCategories'
  urlproduct:string = environment.apiBase+'/Category/GetProductsForCategory'
  list:CoreDetail[] = []
  formData: CoreDetail = new  CoreDetail()
  prodData: ProductDetail = new ProductDetail()
  constructor(private http:HttpClient) { }
  refreshList(){
    this.http.get(this.url).subscribe({
      next: res =>{
        this.list = res as CoreDetail[]
      },
      error: err => {console.log(err)}
    })
}
viewproductforcategory(id:number){
  return this.http.get(this.urlproduct + '/' + id).subscribe({
    next: rex =>{
      this.prodData
    }
  })
}
}
