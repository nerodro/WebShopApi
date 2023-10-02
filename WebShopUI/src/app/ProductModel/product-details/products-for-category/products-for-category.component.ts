import { Component } from '@angular/core';
import { ProductDetailService } from '../../shared/product-detail.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products-for-category',
  templateUrl: './products-for-category.component.html',
  styleUrls: ['./products-for-category.component.css']
})
export class ProductsForCategoryComponent {
  constructor(public service: ProductDetailService, private router: Router){}
  ngOnInit(): void {
    this.service.viewproductcategory(this.service.formData.categoryId);
  }
}
