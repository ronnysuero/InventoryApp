import { Component, OnInit } from "@angular/core";
import { ComponentManager, ModalFormService } from "prime-ngx-ar";
import { TransferModel } from "./transfer.model";
import { TransferService } from "./transfer.service";
import { TransferFormComponent } from "./form/transfer-form.component";
import { TransactionService } from "../transaction/transaction.service";
import { ItemService } from "../item/item.service";

@Component({
  selector: "transfer",
  templateUrl: "./transfer.component.html",
})
export class TransferComponent extends ComponentManager<TransferModel>
  implements OnInit {
  constructor(
    public service: TransferService,
    public modalFormService: ModalFormService,
    private transactionService: TransactionService,
    private itemService: ItemService
  ) {
    super(service);
    this.scrollTopOnInit = false;
  }

  onAdd(args: any) {
    const { TransactionDate } = {
      ...this.service.cacheData.defaultData.List,
    } as any;

    this.service.model = <any>{
      LocationId: this.transactionService.locationId,
      ItemId: this.itemService.current.ItemId,
      TransactionDate: TransactionDate,
    };
    this.service.cacheData.locations.List = this.service.cacheData.locations.List.filter(
      (f) => f.LocationId != this.transactionService.locationId
    );
    super.onAdd(args);
  }

  onAdded(args: any) {
    this.service.load();
    this.transactionService.load();
    super.onAdded(args);
  }

  ngOnInit() {
    super.ngOnInit();
    this.modalContent = TransferFormComponent;
  }
}
