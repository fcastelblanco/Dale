import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerModel } from 'src/app/models/customer.model';
import { DaleService } from 'src/app/services/dale.service';

@Component({
    templateUrl: './customer.component.html'
})

export class CustomerComponent implements OnInit {

    customer: FormGroup;
    customerList: CustomerModel[];

    constructor(private daleService: DaleService, private formBuilder: FormBuilder) {

    }

    ngOnInit(): void {

        this.customer = this.formBuilder.group({
            name: new FormControl('', [Validators.required]),
            lastName: new FormControl('', [Validators.required]),
            documentNumber: new FormControl('', [Validators.required]),
            phone: new FormControl('', [Validators.required])
        });

        this.initCustomerList();
    }

    save() {

        let customerModel = new CustomerModel();

        customerModel.name = this.customer.get("name").value;
        customerModel.lastName = this.customer.get("lastName").value;
        customerModel.documentNumber = this.customer.get("documentNumber").value;
        customerModel.phone = this.customer.get("phone").value;

        this.daleService.createCustomer(customerModel).subscribe(res => {

            console.log(res);
            this.initCustomerList();
        });
    }

    initCustomerList() {
        this.daleService.getCustomerList().subscribe(res => {

            this.customerList = res;
        });
    }

}