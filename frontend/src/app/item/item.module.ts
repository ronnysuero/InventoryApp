import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { ItemListComponent } from "./list/item-list.component";
import { ItemComponent } from "./item.component";
import { ItemRouting } from "./item.routing";
import { SharedModule } from "../shared/shared.module";
import { ItemFormModule } from "./form/item-form.module";
import { ItemTransactionModule } from './itemtransaction/itemtransaction.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ItemRouting,
    SharedModule,
    ItemFormModule,
    ItemTransactionModule,
  ],
  declarations: [ItemComponent, ItemListComponent],
})
export class ItemModule {}
