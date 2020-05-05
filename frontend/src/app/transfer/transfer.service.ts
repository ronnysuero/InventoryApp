import { Injectable } from "@angular/core";
import { TransferModel, TransferType } from "./transfer.model";
import { ServiceManager, Filter, FilterOperator } from "utilscore-ar";
import { ItemService } from "../item/item.service";
import { TransactionService } from "../transaction/transaction.service";

@Injectable({ providedIn: "root" })
export class TransferService extends ServiceManager<TransferModel> {
  quantity = 0;
  type: TransferType;

  constructor(
    private itemService: ItemService,
    private transactionService: TransactionService
  ) {
    super("api/transfer", TransferModel);

    this.setOptions({
      loadingOnAdd: false,
      identityPropertyName: "TransferId",
      cacheDataProvider: {
        providers: [
          "locations",
          {
            key: "transfers as defaultData",
            method: "GetDefaultData",
          },
        ],
      },
    });

    this.transactionService.onLocationChange.subscribe(() => this.load());

    this.loadEmitter.subscribe(() => {
      try {
        this.quantity = (this.data[0] as any).Quantity;
      } catch (error) {
        this.quantity = 0;
      }
    });
  }

  load() {
    const item = new Filter();
    item.PropertyName = "ItemId";
    item.Operator = FilterOperator.Equals;
    item.Value = this.itemService.current.ItemId;

    const location = new Filter();

    location.PropertyName = "LocationId";
    location.Operator = FilterOperator.Equals;
    location.Value = this.transactionService.locationId;

    this.requestSetting.Filters = [item, location];
    super.load();
    this.current = null;
  }
}
