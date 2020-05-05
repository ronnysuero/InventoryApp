import { Component } from "@angular/core";
import { TransactionService } from "../transaction.service";
import { ListManager } from "prime-ngx-ar";
import { TransactionModel } from "../transaction.model";
import { TransactionType } from "../transactiontype.enum";

@Component({
  selector: "transaction-list",
  templateUrl: "./transaction-list.component.html",
})
export class TransactionListComponent extends ListManager {
  constructor(public service: TransactionService) {
    super(service);
  }

  edit(item: TransactionModel, list) {
    if (
      [TransactionType.TransferIn, TransactionType.TransferOut].includes(
        item.TransactionTypeId
      )
    ) {
      this.service.toastr.error(
        "No se puede editar una transferencia de inventario"
      );
      return;
    }

    list.edit(item);
  }
}
