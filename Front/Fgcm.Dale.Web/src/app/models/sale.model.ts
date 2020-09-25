import { SaleDetailModel } from './sale-detail.model';

export class SaleModel{
    customerId: string;
    total: number;
    saleDetailDtos: SaleDetailModel[];
}