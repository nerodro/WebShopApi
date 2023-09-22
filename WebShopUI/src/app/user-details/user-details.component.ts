import { Component,OnInit } from '@angular/core';
import { ShopDetailService } from '../shared/shop-detail.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  constructor(public service: ShopDetailService){

  }
  ngOnInit(): void {
    this.service.refreshList();
  }
}
