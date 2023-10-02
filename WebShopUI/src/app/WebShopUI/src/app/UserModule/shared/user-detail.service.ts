import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { UserDetail } from './user-detail.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserDetailService {

  url:string = environment.apiBase+'/User/GetAllUsers'
  urladd:string = environment.apiBase+'/User/CreateUsers'
  urlupdate:string = environment.apiBase+'/User/EditUser'
  urldelete:string = environment.apiBase+'/User/DeleteUser'
  list:UserDetail[] = [];
  formData : UserDetail = new UserDetail();
  formSubmitted:boolean=false;
  constructor(private http:HttpClient) { }
  refreshList(){
    this.http.get(this.url).subscribe({
      next: res =>{
        this.list = res as UserDetail[]
      },
      error: err => {console.log(err)}
    })
  }
  AddUser(){
    
    return this.http.post(this.urladd,this.formData);
  }
  UpdateUser(){
    return this.http.put(this.urlupdate+'/' +
    this.formData.id,this.formData);
  }
  DeleteUser(id:number){
    return this.http.delete(this.urldelete+'/' +
    id);
  }
  resetForm(form:NgForm){
    form.form.reset();
    this.formData = new UserDetail();
    this.formSubmitted = false;
  }
}
