import { Injectable, EventEmitter } from "@angular/core";
import { TransactionModel } from "./transaction.model";
import { ServiceManager, Filter, FilterOperator } from "utilscore-ar";
import { ItemService } from "../item/item.service";

@Injectable({ providedIn: "root" })
export class TransactionService extends ServiceManager<TransactionModel> {
  locationId: number;
  onLocationChange = new EventEmitter();

  constructor(private itemService: ItemService) {
    super("api/transaction", TransactionModel);

    this.setOptions({
      loadingOnAdd: false,
      identityPropertyName: "TransactionId",
      cacheDataProvider: {
        providers: [
          "locations",
          "transactionTypes",
          {
            key: "transactions as defaultData",
            method: "GetDefaultData",
          },
        ],
      },
    });
  }

  load() {
    this.loadByLocation();
  }

  loadByLocation() {
    this.requestSetting.Filters = this.itemService.getFilter();

    if (this.locationId) {
      this.requestSetting.Filters.push(this._getLocationFilter());
    }

    this.onLocationChange.emit(this.locationId);

    super.load();
    this.current = null;
  }

  private _getLocationFilter() {
    const filter = new Filter();

    filter.PropertyName = "LocationId";
    filter.Operator = FilterOperator.Equals;
    filter.Value = this.locationId;

    return filter;
  }
}
