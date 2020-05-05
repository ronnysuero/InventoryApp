import { Component } from "@angular/core";
import { TransferService } from "../transfer.service";
import { ListManager } from "prime-ngx-ar";
import { TransferType } from "../transfer.model";

@Component({
  selector: "transfer-button",
  templateUrl: "./transfer-button.component.html",
})
export class TransferButtonComponent extends ListManager {
  constructor(public service: TransferService) {
    super(service);
  }

  addTransfer(list) {
    this.service.type = TransferType.TransferInventory;
    list.add();
  }

  removeInventory(list) {
    this.service.type = TransferType.RemoveExisting;
    list.add();
  }
}
