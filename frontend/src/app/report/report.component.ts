import { Component, OnInit } from "@angular/core";
import { ComponentManager } from "prime-ngx-ar";
import { ReportModel } from "./report.model";
import { ReportService } from "./report.service";

@Component({
  selector: "report",
  templateUrl: "./report.component.html",
})
export class ReportComponent extends ComponentManager<ReportModel>
  implements OnInit {
  constructor(public service: ReportService) {
    super(service);
  }
}
