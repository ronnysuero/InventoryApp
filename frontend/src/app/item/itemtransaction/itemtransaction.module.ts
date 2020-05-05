import { NgModule, ANALYZE_FOR_ENTRY_COMPONENTS } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../../shared/shared.module";
import { ItemTransactionComponent } from "./itemtransaction.component";
import { ItemService } from "../item.service";
import { FormTemplateModule } from "utilscore-ar";
import { ModalFormModule } from "prime-ngx-ar";
import { TransactionModule } from '../../transaction/transaction.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    FormTemplateModule,
    ModalFormModule,
    TransactionModule,
  ],
  declarations: [ItemTransactionComponent],
  exports: [ItemTransactionComponent],
  providers: [ItemService],
})
export class ItemTransactionModule {}
