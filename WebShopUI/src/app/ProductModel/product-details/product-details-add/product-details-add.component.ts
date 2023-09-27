import { Component } from '@angular/core';
import { ProductDetailService } from '../../shared/product-detail.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ProductDetail } from '../../shared/product-detail.model';

@Component({
  selector: 'app-product-details-add',
  templateUrl: './product-details-add.component.html',
  styleUrls: ['./product-details-add.component.css']
})
export class ProductDetailsAddComponent {
  constructor(public service: ProductDetailService, private router: Router){}
  addProduct(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
    this.service.CreateProduct().subscribe({
      next:res=>{
       this.service.list = res as ProductDetail[];
      },
      error:err=>{console.log(err, this.service.formData)}
    })
  }
}
updateProduct(form:NgForm){
  this.service.formSubmitted = true;
  if(form.valid){
  this.service.UpdateProduct().subscribe({
    next:res=>{
     this.service.list = res as ProductDetail[];
    },
    error:err=>{console.log(err, this.service.formData)}
  })
}
}
onSubmit(form:NgForm){
  this.service.formSubmitted = true;
  if(form.valid){
  if(this.service.formData.id == 0)
  this.addProduct(form),
  this.router.navigate(['product/allproduct'])
  else
  this.updateProduct(form)
  this.router.navigate(['product/allproduct'])
  }
}
}
