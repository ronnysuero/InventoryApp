import { Injectable } from "@angular/core";
import { AreaModel } from "./area.model";
import { ServiceManager } from "utilscore-ar";

@Injectable({ providedIn: "root" })
export class AreaService extends ServiceManager<AreaModel> {
  constructor() {
    super("api/area", AreaModel);

    this.setOptions({
      loadingOnAdd: false,
      identityPropertyName: "AreaId"
    });
  }
}
