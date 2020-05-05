import { Component } from "@angular/core";
import { ReportService } from "../report.service";
import { ListManager } from "prime-ngx-ar";
import { ReportType } from "../report.model";

@Component({
  selector: "report-list",
  templateUrl: "./report-list.component.html",
})
export class ReportListComponent extends ListManager {
  REPORT = ReportType;
  data: Array<any>;
  showInventoryTransaction = false;
  showCurrentStock = false;

  constructor(public service: ReportService) {
    super(service);
  }

  print() {
    if (!this.service.model.ReportType) {
      this.service.toastr.error("Debe seleccionar un reporte");
      return;
    }

    if (
      this.service.model.Locations.length > 0 &&
      this.service.model.Locations[0] === this.service.locationGroup
    )
      this.service.model.LocationIds = [];
    else this.service.model.LocationIds = this.service.model.Locations;

    if (
      this.service.model.Areas.length > 0 &&
      this.service.model.Areas[0] === this.service.areaGroup
    )
      this.service.model.AreaIds = [];
    else this.service.model.AreaIds = this.service.model.Areas;

    switch (this.service.model.ReportType) {
      case ReportType.InventoryTransactions:
        if (
          new Date(this.service.model.StartDate).getTime() >
          new Date(this.service.model.EndDate).getTime()
        ) {
          this.service.toastr.error(
            "La fecha de inicio debe ser menor o igual que la final"
          );
          return;
        }
        break;

      default:
        break;
    }

    this.service.getData((response) => {
      this.data = response.DataSource;
      this.showInventoryTransaction = false;
      this.showCurrentStock = false;

      switch (this.service.model.ReportType) {
        case ReportType.InventoryTransactions:
          if (this.data.length == 0) {
            this.service.toastr.info("No hay registros disponibles");
            return;
          }
          this.showInventoryTransaction = true;
          break;

        case ReportType.CurrentStockList:
          if (this.data.length == 0) {
            this.service.toastr.info("No hay registros disponibles");
            return;
          }
          this.showCurrentStock = true;
          break;
      }
    });
  }
}
