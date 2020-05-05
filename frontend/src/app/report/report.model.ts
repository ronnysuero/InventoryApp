export class ReportModel {
  ReportType: number;
  LocationIds?: Array<number>;
  Locations = [];
  AreaIds?: Array<number>;
  Areas = [];
  StartDate?: Date;
  EndDate?: Date;
  Date?: Date;
}

export enum ReportType {
  InventoryTransactions = 1,
  CurrentStockList,
}
