import { Injectable } from "@angular/core";
import { ItemModel } from "./item.model";
import { ServiceManager, FilterOperator, Filter } from "utilscore-ar";

@Injectable({ providedIn: "root" })
export class ItemService extends ServiceManager<ItemModel> {
  constructor() {
    super("api/item", ItemModel);

    this.setOptions({
      loadingOnAdd: false,
      cacheDataProvider: {
        providers: [
          "areas",
          "manufacturers",
          "locations",
          "transactionTypes",
          {
            key: "states",
            method: "GetStatesRD",
          },
          {
            key: "transactions as defaultData",
            method: "GetDefaultData",
          },
        ],
      },
      identityPropertyName: "ItemId",
    });
  }

  getFilter() {
    const filter = new Filter();

    filter.PropertyName = "ItemId";
    filter.Operator = FilterOperator.Equals;
    filter.Value = this.current.ItemId;

    return [filter];
  }
}
