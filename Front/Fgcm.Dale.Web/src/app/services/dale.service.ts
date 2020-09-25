import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { ProductModel } from '../models/product.model';
import { CustomerModel } from '../models/customer.model';
import { SaleModel } from '../models/sale.model';

@Injectable({
    providedIn: "root"
})

export class DaleService {

    constructor(private http: HttpClient) {

    }

    createProduct(product: ProductModel) {

        return this.http.post(environment.apiUrl + "/api/dale/createProduct/", product).pipe(map((response: ProductModel) => {
            return response;
        }));
    }

    createCustomer(product: CustomerModel) {

        return this.http.post(environment.apiUrl + "/api/dale/createCustomer/", product).pipe(map((response: ProductModel) => {
            return response;
        }));
    }

    getProductList() {

        return this.http.get(environment.apiUrl + "/api/dale/getAllProducts/").pipe(map((response: ProductModel[]) => {
            return response;
        }));
    }

    getCustomerList() {

        return this.http.get(environment.apiUrl + "/api/dale/getAllCustomers/").pipe(map((response: CustomerModel[]) => {
            return response;
        }));
    }

    getSaleList() {

        return this.http.get(environment.apiUrl + "/api/dale/getAllSales/").pipe(map((response: SaleModel[]) => {
            return response;
        }));
    }

    createSale(sale: SaleModel){

        return this.http.post(environment.apiUrl + "/api/dale/createSale/", sale).pipe(map((response: boolean) => {
            return response;
        }));
    }
}