import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AccountDetail } from './account-detail.model';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountDetailService {
  urlregister:string = environment.apiBase+'/Account/Register'
  urlogin:string = environment.apiBase+'/Account/LoginUser'
  urlogout:string = environment.apiBase+'/Account/Logout'
  urlget: string = environment.apiBase+'/User/GetOneUser'
  formData: AccountDetail = new AccountDetail()
  formSubmitted:boolean=false;
  constructor(private http:HttpClient) {}
  user: any=null
  Register(){
    return this.http.post(this.urlregister, this.formData)
  }
  Login(){
    return this.http.get(this.urlogin + '/' + this.formData.FirstName + ','+ this.formData.Password)
  }
}
