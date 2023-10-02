import { Component } from '@angular/core';
import { CoreDetailService } from './shared/core-detail.service';
import { Router } from '@angular/router';
import { CoreDetail } from './shared/core-detail.model';
import { ProductDetail } from 'src/app/ProductModel/shared/product-detail.model';
import { ProductDetailService } from 'src/app/ProductModel/shared/product-detail.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  constructor(public service: CoreDetailService, private router:Router, public product: ProductDetailService){}
  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(id:number){
    this.product.viewproductcategory(id)
    this.router.navigate(['product/product-for-category'])
  }
}
