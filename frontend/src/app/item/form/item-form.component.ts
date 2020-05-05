import { Component } from "@angular/core";
import { ItemService } from "../item.service";
import { FormManager } from "prime-ngx-ar";
import { AreaFormComponent } from "../../area/form/area-form.component";
import { ManufacturerFormComponent } from "../../manufacturer/form/manufacturer-form.component";
import { LocationFormComponent } from "../../location/form/location-form.component";
import { TransactionType } from "../../transaction/transactiontype.enum";

@Component({
  selector: "item-form",
  templateUrl: "./item-form.component.html",
})
export class ItemFormComponent extends FormManager {
  NEW_STOCK = TransactionType.NewStock;

  constructor(public service: ItemService) {
    super(service);
  }

  addNewArea() {
    this.createFormManagerInstance(AreaFormComponent, (args) => {
      this.service.cacheData.areas.push(args.model);
      this.service.model.AreaId = args.model.AreaId;
    });
  }

  addNewManufacturer() {
    this.createFormManagerInstance(ManufacturerFormComponent, (args) => {
      this.service.cacheData.manufacturers.push(args.model);
      this.service.model.AreaId = args.model.AreaId;
    });
  }

  addNewLocation() {
    this.createFormManagerInstance(LocationFormComponent, (args) => {
      this.service.cacheData.locations.push(args.model);
      this.service.model.Transaction.LocationId = args.model.LocationId;
    });
  }
  onChangeTransactionType() {
    this.service.model.Transaction.UnitCost = undefined;
    this.service.model.Transaction.UnitSale = undefined;
  }
}
