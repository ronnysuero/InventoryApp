import { TransactionModel } from "../transaction/transaction.model";

export class TransferModel extends TransactionModel {
  LocationToId: number;
}

export enum TransferType {
  TransferInventory = 1,
  RemoveExisting
}
