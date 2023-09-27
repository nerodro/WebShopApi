import { Component } from '@angular/core';
import { ProductDetailService } from '../../shared/product-detail.service';
import { Router } from '@angular/router';
import { ProductDetail } from '../../shared/product-detail.model';

@Component({
  selector: 'app-product-details-allview',
  templateUrl: './product-details-allview.component.html',
  styleUrls: ['./product-details-allview.component.css']
})
export class ProductDetailsAllviewComponent {
  constructor(public service: ProductDetailService, private router: Router){}
  ngOnInit(): void {
    this.service.allProduct();
  }
  populateForm(selectedRecord: ProductDetail){
    this.router.navigate(['/product/viewproduct']),
    this.service.formData = Object.assign({},selectedRecord)
  }
  populateFormEdit(selectedRecord: ProductDetail){
    this.router.navigate(['/product/addproduct']),
    this.service.formData = Object.assign({},selectedRecord)
  }
}
