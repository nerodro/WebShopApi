import { Component, OnInit } from '@angular/core';
import { ProductDetailService } from '../shared/product-detail.service';
import { ProductDetail } from '../shared/product-detail.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  constructor(public service: ProductDetailService, private router: Router){}
  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(selectedRecord: ProductDetail){
    this.router.navigate(['/product/viewproduct']),
    this.service.formData = Object.assign({},selectedRecord)
  }

}
