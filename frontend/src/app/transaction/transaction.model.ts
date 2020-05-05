import { TransactionType } from "./transactiontype.enum";

export class TransactionModel {
  TransactionId: number;
  LocationId: number;
  TransactionDate: Date;
  TransactionTypeId: TransactionType;
  Quantity: number;
  UnitCost: number;
  UnitSale: number;
  Comments: string;
}
