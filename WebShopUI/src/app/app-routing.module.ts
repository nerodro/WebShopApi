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
import { ProductsForCategoryComponent } from './ProductModel/product-details/products-for-category/products-for-category.component';
import { AddCompanyComponent } from './CompanyModule/company-details/add-company/add-company.component';
import { ViewCompanyComponent } from './CompanyModule/company-details/view-company/view-company.component';

const routes: Routes = [
  { path: 'user',component: UserDetailsComponent },
  { path: 'user/adduser',component: UserDetailsFormComponent},
  { path: 'product/index',component: ProductDetailsComponent},
  { path: 'product/viewproduct', component: ProductDetailsFormComponent},
  { path: 'product/addproduct', component: ProductDetailsAddComponent},
  { path: 'product/allproduct', component: ProductDetailsAllviewComponent},
  { path: 'product/product-for-category',component:ProductsForCategoryComponent },
  { path: 'company/index', component: CompanyDetailsComponent},
  { path: 'comapy/addcompany', component: AddCompanyComponent},
  { path: 'company/viewcompany', component: ViewCompanyComponent},
  { path: 'account/register', component: RegisterDetailsComponent},
  { path: 'account/login', component:LoginDetailsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
