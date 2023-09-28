import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDetailsFormComponent } from './UserModule/user-details/user-details-form/user-details-form.component';
import { UserDetailsComponent } from './UserModule/user-details/user-details.component';
import { ProductDetailsComponent } from './ProductModel/product-details/product-details.component';
import { ProductDetailsFormComponent } from './ProductModel/product-details/product-details-form/product-details-form.component';
import { ProductDetailsAddComponent } from './ProductModel/product-details/product-details-add/product-details-add.component';
import { ProductDetailsAllviewComponent } from './ProductModel/product-details/product-details-allview/product-details-allview.component';

const routes: Routes = [
  { path: 'user',component: UserDetailsComponent },
  { path: 'user/adduser',component: UserDetailsFormComponent},
  { path: 'product',component: ProductDetailsComponent},
  { path: 'product/viewproduct', component: ProductDetailsFormComponent},
  { path: 'product/addproduct', component: ProductDetailsAddComponent},
  { path: 'product/allproduct', component: ProductDetailsAllviewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
