import { Routes, RouterModule } from "@angular/router";
import { ItemComponent } from "./item.component";
import { ItemListComponent } from "./list/item-list.component";
import { ItemFormComponent } from "./form/item-form.component";
import { ItemTransactionComponent } from './itemtransaction/itemtransaction.component';

const APP_ROUTES: Routes = [
  {
    path: "",
    component: ItemComponent,
    data: { title: "" },
    children: [
      { path: "", component: ItemListComponent },
      {
        path: "edit",
        component: ItemTransactionComponent,
        data: { title: "Editar artículo" },
      },
      {
        path: "add",
        component: ItemFormComponent,
        data: { title: "Agregar nuevo" },
      },
    ],
  },
];

export const ItemRouting = RouterModule.forChild(APP_ROUTES);
