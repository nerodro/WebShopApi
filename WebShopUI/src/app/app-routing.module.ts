import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDetailsFormComponent } from './UserModule/user-details/user-details-form/user-details-form.component';
import { UserDetailsComponent } from './UserModule/user-details/user-details.component';
import { ProductDetailsComponent } from './ProductModel/product-details/product-details.component';
import { ProductDetailsFormComponent } from './ProductModel/product-details/product-details-form/product-details-form.component';

const routes: Routes = [
  { path: 'user',component: UserDetailsComponent},
  { path: 'user/adduser',component: UserDetailsFormComponent},
  { path: 'product',component: ProductDetailsComponent},
  { path: 'product/viewproduct', component: ProductDetailsFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
