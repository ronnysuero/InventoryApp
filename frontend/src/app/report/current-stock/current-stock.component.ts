import { Component, Input, OnInit } from "@angular/core";

@Component({
  selector: "current-stock",
  templateUrl: "./current-stock.component.html",
})
export class CurrentStockComponent implements OnInit {
  @Input() data: Array<any>;

  rowGroupMetadata: any;

  ngOnInit() {
    this.rowGroupMetadata = {};

    if (this.data) {
      for (let i = 0; i < this.data.length; i++) {
        const rowData = this.data[i];
        const locationName = rowData.LocationName;
        if (i == 0) {
          this.rowGroupMetadata[locationName] = { index: 0, size: 1 };
        } else {
          const previousRowData = this.data[i - 1];
          const previousRowGroup = previousRowData.LocationName;
          if (locationName === previousRowGroup)
            this.rowGroupMetadata[locationName].size++;
          else this.rowGroupMetadata[locationName] = { index: i, size: 1 };
        }
      }
    }
  }

  exportExcel() {
    import("xlsx").then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.data);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ["data"] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: "xlsx",
        type: "array",
      });
      this._saveAsExcelFile(excelBuffer, "CurrentStock");
    });
  }

  private _saveAsExcelFile(buffer: any, fileName: string): void {
    import("file-saver").then((FileSaver) => {
      const EXCEL_TYPE =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8";
      const EXCEL_EXTENSION = ".xlsx";
      const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE,
      });
      FileSaver.saveAs(
        data,
        fileName + "_export_" + new Date().getTime() + EXCEL_EXTENSION
      );
    });
  }
}
