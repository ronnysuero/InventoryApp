import { Component } from "@angular/core";
import { TransactionService } from "../transaction.service";
import { FormManager } from "prime-ngx-ar";
import { TransactionType } from "../transactiontype.enum";

@Component({
  selector: "transaction-form",
  templateUrl: "./transaction-form.component.html",
})
export class TransactionFormComponent extends FormManager {
  TRANSACTION_TYPE = TransactionType;

  constructor(public service: TransactionService) {
    super(service);
  }
}
