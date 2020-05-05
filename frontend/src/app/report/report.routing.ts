import { Routes, RouterModule } from "@angular/router";
import { ReportComponent } from "./report.component";
import { ReportListComponent } from "./list/report-list.component";

const APP_ROUTES: Routes = [
  {
    path: "",
    component: ReportComponent,
    data: { title: "" },
    children: [{ path: "", component: ReportListComponent }],
  },
];

export const ReportRouting = RouterModule.forChild(APP_ROUTES);
