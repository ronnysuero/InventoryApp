import { Component } from "@angular/core";
import { ItemService } from "../item.service";
import { FormManager } from "prime-ngx-ar";

@Component({
  selector: "itemtransaction",
  templateUrl: "./itemtransaction.component.html",
})
export class ItemTransactionComponent extends FormManager {
  constructor(public service: ItemService) {
    super(service);
  }
}
