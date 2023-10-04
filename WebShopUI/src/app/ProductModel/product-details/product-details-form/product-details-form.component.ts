import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ProductDetailService } from '../../shared/product-detail.service';
import { ProductDetail } from '../../shared/product-detail.model';

@Component({
  selector: 'app-product-details-form',
  templateUrl: './product-details-form.component.html',
  styleUrls: ['./product-details-form.component.css']
})
export class ProductDetailsFormComponent {
  constructor(public service: ProductDetailService, private router: Router){}
  onSubmit(form:NgForm){
    if(form.valid){
    if(this.service.formData.id != 0)
    this.populate
  }
  
  }
  populate(user: ProductDetail){
    this.service.formData = Object.assign({}, user)
  }
}
