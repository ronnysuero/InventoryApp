import { Component, OnInit } from "@angular/core";
import { ComponentManager, ModalFormService } from "prime-ngx-ar";
import { ItemModel } from "./item.model";
import { ItemService } from "./item.service";
import { ItemFormComponent } from "./form/item-form.component";
import { NavigationMode, ModelState } from "utilscore-ar";

@Component({
  selector: "item",
  templateUrl: "./item.component.html",
})
export class ItemComponent extends ComponentManager<ItemModel>
  implements OnInit {
  constructor(
    public service: ItemService,
    public modalFormService: ModalFormService
  ) {
    super(service, "/items");
  }

  ngOnInit() {
    super.ngOnInit();
    this.setModalContent(ItemFormComponent);

    this.navigateOptions.set("add", {
      openWith: NavigationMode.Modal,
    });
    this.modalOptions.class = "modal-xl";
  }

  onAdd(args: any) {
    const { TransactionTypeId, TransactionDate } = {
      ...this.service.cacheData.defaultData.List,
    } as any;

    this.service.model = <any>{
      Transaction: {
        TransactionTypeId: TransactionTypeId,
        TransactionDate: TransactionDate,
      },
    };

    super.onAdd(args);
  }

  onAdded(args: any) {
    super.onAdded(args);

    if (!this.service.saveAndNew) {
      this.service.edit(this.service.current);
    }
  }

  onEdited(args: any) {
    this.service.current = args.model;
    this.service.model = Object.assign({}, this.service.model);
    this.service.stateChange(ModelState.Edit);
  }
}
