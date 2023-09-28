import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { UserDetailsComponent } from './UserModule/user-details/user-details.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { UserDetailsFormComponent } from './UserModule/user-details/user-details-form/user-details-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { ProductDetailsComponent } from './ProductModel/product-details/product-details.component';
import { ProductDetailsFormComponent } from './ProductModel/product-details/product-details-form/product-details-form.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductDetailsAddComponent } from './ProductModel/product-details/product-details-add/product-details-add.component';
import { ProductDetailsAllviewComponent } from './ProductModel/product-details/product-details-allview/product-details-allview.component';
import { ProductDetailsEditStatusComponent } from './ProductModel/product-details/product-details-edit-status/product-details-edit-status.component';
import { CompanyDetailsComponent } from './CompanyModule/company-details/company-details.component';
import { CartDetailsComponent } from './CartModule/cart-details/cart-details.component';
import { CategoryDetailsComponent } from './CategoryModule/category-details/category-details.component';
import { RegisterDetailsComponent } from './AccountModule/register-details/register-details.component';
import { LoginDetailsComponent } from './AccountModule/login-details/login-details.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDetailsComponent,
    UserDetailsFormComponent,
    NavbarComponent,
    ProductDetailsComponent,
    ProductDetailsFormComponent,
    ProductDetailsAddComponent,
    ProductDetailsAllviewComponent,
    ProductDetailsEditStatusComponent,
    CompanyDetailsComponent,
    CartDetailsComponent,
    CategoryDetailsComponent,
    RegisterDetailsComponent,
    LoginDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
