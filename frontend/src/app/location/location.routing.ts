import { Routes, RouterModule } from "@angular/router";
import { LocationComponent } from "./location.component";
import { LocationListComponent } from "./list/location-list.component";
import { LocationFormComponent } from "./form/location-form.component";

const APP_ROUTES: Routes = [
  {
    path: "",
    component: LocationComponent,
    data: { title: "" },
    children: [
      { path: "", component: LocationListComponent },
      {
        path: "edit",
        component: LocationFormComponent,
        data: { title: "Editar" },
      },
      {
        path: "add",
        component: LocationFormComponent,
        data: { title: "Agregar nuevo" },
      },
    ],
  },
];

export const LocationRouting = RouterModule.forChild(APP_ROUTES);
