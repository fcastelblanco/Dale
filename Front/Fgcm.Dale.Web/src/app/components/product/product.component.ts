import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductModel } from 'src/app/models/product.model';
import { DaleService } from 'src/app/services/dale.service';

@Component({
    templateUrl: './product.component.html'
})

export class ProductComponent implements OnInit {

    product: FormGroup;
    producList: ProductModel[];

    constructor(private daleService: DaleService, private formBuilder: FormBuilder) {

    }

    ngOnInit(): void {

        this.product = this.formBuilder.group({
            name: new FormControl('', [Validators.required]),
            cost: new FormControl('', [Validators.required])
        });

        this.initProducts();
    }

    save() {
        let productModel = new ProductModel();

        productModel.name = this.product.get("name").value;
        productModel.cost = this.product.get("cost").value;

        this.daleService.createProduct(productModel).subscribe(res => {

            console.log(res);
            this.initProducts();
        });       
    }

    initProducts(){

        this.daleService.getProductList().subscribe(res => {
            this.producList = res;
        });
    }
}