import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDetailsFormComponent } from './UserModule/user-details/user-details-form/user-details-form.component';
import { UserDetailsComponent } from './UserModule/user-details/user-details.component';
import { ProductDetailsComponent } from './ProductModel/product-details/product-details.component';
import { ProductDetailsFormComponent } from './ProductModel/product-details/product-details-form/product-details-form.component';
import { ProductDetailsAddComponent } from './ProductModel/product-details/product-details-add/product-details-add.component';
import { ProductDetailsAllviewComponent } from './ProductModel/product-details/product-details-allview/product-details-allview.component';
import { CompanyDetailsComponent } from './CompanyModule/company-details/company-details.component';
import { RegisterDetailsComponent } from './AccountModule/register-details/register-details.component';
import { LoginDetailsComponent } from './AccountModule/login-details/login-details.component';

const routes: Routes = [
  { path: 'user',component: UserDetailsComponent },
  { path: 'user/adduser',component: UserDetailsFormComponent},
  { path: 'product/index',component: ProductDetailsComponent},
  { path: 'product/viewproduct', component: ProductDetailsFormComponent},
  { path: 'product/addproduct', component: ProductDetailsAddComponent},
  { path: 'product/allproduct', component: ProductDetailsAllviewComponent},
  { path: 'company/index', component: CompanyDetailsComponent},
  { path: 'account/register', component: RegisterDetailsComponent},
  { path: 'account/login', component:LoginDetailsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
