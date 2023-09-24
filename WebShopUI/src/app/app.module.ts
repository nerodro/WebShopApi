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

@NgModule({
  declarations: [
    AppComponent,
    UserDetailsComponent,
    UserDetailsFormComponent,
    NavbarComponent,
    ProductDetailsComponent,
    ProductDetailsFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
