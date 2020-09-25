import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerModel } from 'src/app/models/customer.model';
import { ProductModel } from 'src/app/models/product.model';
import { SaleDetailModel } from 'src/app/models/sale-detail.model';
import { SaleModel } from 'src/app/models/sale.model';
import { DaleService } from 'src/app/services/dale.service';

@Component({
    templateUrl: './sale.component.html'
})

export class SaleComponent implements OnInit {

    saleHeader: FormGroup;
    saleDetail: FormGroup;
    productList: ProductModel[];
    customerList: CustomerModel[];

    saleModel: SaleModel;
    customerSaved: boolean;

    constructor(private daleService: DaleService, private formBuilder: FormBuilder) {
        this.saleModel = new SaleModel();
        this.saleModel.total = 0;
        this.saleModel.saleDetailDtos = [];
    }

    ngOnInit(): void {

        this.saleHeader = this.formBuilder.group({
            customer: new FormControl('', [Validators.required])
        });

        this.saleDetail = this.formBuilder.group({
            product: new FormControl('', [Validators.required]),
            quantity: new FormControl('', [Validators.required])
        });

        this.initList();
    }

    initList() {

        this.daleService.getProductList().subscribe(res => {
            this.productList = res;
        });

        this.daleService.getCustomerList().subscribe(res => {
            this.customerList = res;
        });
    }

    save() {

        let saleDetail = new SaleDetailModel();

        saleDetail.quantity = this.saleDetail.get("quantity").value;
        saleDetail.productId = this.saleDetail.get("product").value;

        this.saleModel.saleDetailDtos.push(saleDetail);

        this.getTotal();
    }

    saveCustomer() {
        this.customerSaved = true;
        this.saleModel.customerId = this.saleHeader.get("customer").value;
    }

    newSale() {

        if (this.customerSaved) {

            this.daleService.createSale(this.saleModel).subscribe(res => {

                if (res) {
                    this.customerSaved = false;
                    this.saleModel = new SaleModel();
                    this.saleModel.total = 0;
                    this.saleModel.saleDetailDtos = [];

                    alert("Venta creada correctamente");
                }
            });
        }
    }

    getProductCost(productId: string): number {
        let product = this.productList.filter(x => {
            return x.id === productId;
        })[0]

        return product.cost;
    }

    getProductName(productId: string): string {
        let product = this.productList.filter(x => {
            return x.id === productId;
        })[0]

        return product.name;
    }

    getTotal() {

        this.saleModel.saleDetailDtos.forEach(item => {

            this.saleModel.total += item.quantity * this.getProductCost(item.productId);
        });
    }
}