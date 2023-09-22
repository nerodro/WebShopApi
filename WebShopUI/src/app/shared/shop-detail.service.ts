import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { ShopDetail } from './shop-detail.model';

@Injectable({
  providedIn: 'root'
})
export class ShopDetailService {

  url:string = environment.apiBase+'/User/GetAllUsers'
  list:ShopDetail[] = [];

  constructor(private http:HttpClient) { }
  refreshList(){
    this.http.get(this.url).subscribe({
      next: res =>{
        this.list = res as ShopDetail[]
      },
      error: err => {console.log(err)}
    })
  }
}
