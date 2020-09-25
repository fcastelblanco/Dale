import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './components/customer/customer.component';
import { ProductComponent } from './components/product/product.component';
import { SaleComponent } from './components/sale/sale.component';

const routes: Routes = [
  {
    path: 'product',
    component: ProductComponent
  },
  {
    path: 'customer',
    component: CustomerComponent
  },
  {
    path: 'sale',
    component: SaleComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
