import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { ReportListComponent } from "./list/report-list.component";
import { ReportComponent } from "./report.component";
import { ReportRouting } from "./report.routing";
import { SharedModule } from "../shared/shared.module";
import { InventoryTransactionComponent } from "./inventory-transaction/inventory-transaction.component";
import { CurrentStockComponent } from "./current-stock/current-stock.component";

@NgModule({
  imports: [CommonModule, FormsModule, ReportRouting, SharedModule],
  declarations: [
    ReportComponent,
    ReportListComponent,
    InventoryTransactionComponent,
    CurrentStockComponent,
  ],
})
export class ReportModule {}
