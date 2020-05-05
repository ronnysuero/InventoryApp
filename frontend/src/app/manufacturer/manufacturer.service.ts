import { Injectable } from "@angular/core";
import { ManufacturerModel } from "./manufacturer.model";
import { ServiceManager } from "utilscore-ar";

@Injectable({ providedIn: "root" })
export class ManufacturerService extends ServiceManager<ManufacturerModel> {
  constructor() {
    super("api/manufacturer", ManufacturerModel);

    this.setOptions({
      loadingOnAdd: false,
      identityPropertyName: "ManufacturerId"
    });
  }
}
