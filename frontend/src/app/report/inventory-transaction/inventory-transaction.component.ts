import { Component, Input } from "@angular/core";

@Component({
  selector: "inventory-transaction",
  templateUrl: "./inventory-transaction.component.html",
})
export class InventoryTransactionComponent {
  @Input() data: Array<any>;

  calculateSumData(key: string) {
    return this.data
      .map((m) => m[key])
      .reduce((accumulator, currentValue) => accumulator + currentValue);
  }

  exportExcel() {
    import("xlsx").then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.data);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ["data"] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: "xlsx",
        type: "array",
      });
      this._saveAsExcelFile(excelBuffer, "InventoryTransactions");
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
