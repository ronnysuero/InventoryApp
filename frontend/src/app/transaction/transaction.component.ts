import { Component, OnInit } from "@angular/core";
import { ComponentManager, ModalFormService } from "prime-ngx-ar";
import { TransactionModel } from "./transaction.model";
import { TransactionService } from "./transaction.service";
import { TransactionFormComponent } from "./form/transaction-form.component";
import { ItemService } from "../item/item.service";

@Component({
  selector: "transaction",
  templateUrl: "./transaction.component.html",
})
export class TransactionComponent extends ComponentManager<TransactionModel>
  implements OnInit {
  constructor(
    public service: TransactionService,
    public modalFormService: ModalFormService,
    private itemService: ItemService
  ) {
    super(service);
  }

  ngOnInit() {
    super.ngOnInit();
    this.modalContent = TransactionFormComponent;
  }

  onAdd(args: any) {
    const { TransactionTypeId, TransactionDate } = {
      ...this.service.cacheData.defaultData.List,
    } as any;

    this.service.model = <any>{
      TransactionTypeId: TransactionTypeId,
      TransactionDate: TransactionDate,
      ItemId: this.itemService.current.ItemId,
      LocationId: this.service.locationId
    };
    super.onAdd(args);
  }

  onAdded(args: any) {
    super.onAdded(args);
    this.service.loadByLocation();
  }

  onEdited(args: any) {
    super.onEdited(args);
    this.service.loadByLocation();
  }

  onDeleted(args: any) {
    super.onDeleted(args);
    this.service.loadByLocation();
  }
}
