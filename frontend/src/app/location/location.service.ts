import { Injectable } from "@angular/core";
import { LocationModel } from "./location.model";
import { ServiceManager } from "utilscore-ar";

@Injectable({ providedIn: "root" })
export class LocationService extends ServiceManager<LocationModel> {
  constructor() {
    super("api/location", LocationModel);

    this.setOptions({
      loadingOnAdd: false,
      cacheDataProvider: {
        providers: [
          {
            key: "states",
            method: "GetStatesRD",
          },
          {
            key: "locations as defaultData",
            method: "GetDefaultData",
          },
        ],
      },
      identityPropertyName: "LocationId",
    });
  }
}
