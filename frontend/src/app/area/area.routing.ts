import { Routes, RouterModule } from "@angular/router";
import { AreaComponent } from "./area.component";
import { AreaListComponent } from "./list/area-list.component";
import { AreaFormComponent } from "./form/area-form.component";

const APP_ROUTES: Routes = [
  {
    path: "",
    component: AreaComponent,
    data: { title: "" },
    children: [
      { path: "", component: AreaListComponent },
      {
        path: "edit",
        component: AreaFormComponent,
        data: { title: "Editar" },
      },
      {
        path: "add",
        component: AreaFormComponent,
        data: { title: "Agregar nuevo" },
      },
    ],
  },
];

export const AreaRouting = RouterModule.forChild(APP_ROUTES);
