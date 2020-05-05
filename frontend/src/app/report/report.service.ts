import { Injectable } from "@angular/core";
import { ReportModel } from "./report.model";
import { ServiceManager } from "utilscore-ar";

@Injectable({ providedIn: "root" })
export class ReportService extends ServiceManager<ReportModel> {
  readonly areaGroup = "todas las areas";
  readonly locationGroup = "todos los almacenes";

  constructor() {
    super("api/report", ReportModel);

    this.setOptions({
      loadingOnAdd: false,
      identityPropertyName: "ReportId",
      cacheDataProvider: {
        providers: [
          "areas",
          "locations",
          {
            key: "reports as defaultData",
            method: "GetDefaultData",
          },
        ],
      },
    });

    const subscription = this.loadEmitter.subscribe(() => {
      this.cacheData.locations.List.forEach(
        (f) => (f.group = this.locationGroup)
      );

      this.cacheData.areas.List.forEach((f) => (f.group = this.areaGroup));

      const { StartDate, EndDate, Date } = {
        ...this.cacheData.defaultData.List,
      } as any;

      this.model.StartDate = StartDate;
      this.model.EndDate = EndDate;
      this.model.Date = Date;
      subscription.unsubscribe();
    });
  }

  getData(callback: Function) {
    this.postMethod("GetData", this.model, callback);
  }
}
