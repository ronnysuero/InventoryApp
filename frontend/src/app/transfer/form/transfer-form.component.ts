import { Component, OnInit } from "@angular/core";
import { TransferService } from "../transfer.service";
import { FormManager } from "prime-ngx-ar";
import { TransferType } from "../transfer.model";
import { TransactionType } from "../../transaction/transactiontype.enum";

@Component({
  selector: "transfer-form",
  templateUrl: "./transfer-form.component.html",
})
export class TransferFormComponent extends FormManager implements OnInit {
  TRANSFER_INVENTORY = TransferType.TransferInventory;
  CUSTOMER_SALE = TransactionType.CustomerSale;

  constructor(public service: TransferService) {
    super(service);
  }
}
