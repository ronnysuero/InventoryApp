import { TransactionModel } from "../transaction/transaction.model";

export class ItemModel {
  ItemId: number;
  Name: string;
  SKU: string;
  Summary: string;
  AreaId: number;
  ManufacturerId: number;
  MinimumStockCount: number;
  Transaction: TransactionModel;
}
