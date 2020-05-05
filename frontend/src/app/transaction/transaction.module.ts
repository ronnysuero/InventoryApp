import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { TransactionListComponent } from "./list/transaction-list.component";
import { TransactionComponent } from "./transaction.component";
import { SharedModule } from "../shared/shared.module";
import { TransactionFormModule } from "./form/transaction-form.module";
import { TransferModule } from "../transfer/transfer.module";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    TransactionFormModule,
    TransferModule,
  ],
  declarations: [TransactionComponent, TransactionListComponent],
  exports: [TransactionComponent, TransactionListComponent],
})
export class TransactionModule {}
