import { Component } from "@angular/core";
import { ItemService } from "../item.service";
import { ListManager } from "prime-ngx-ar";

@Component({
  selector: "item-list",
  templateUrl: "./item-list.component.html"
})
export class ItemListComponent extends ListManager {
  constructor(public service: ItemService) {
    super(service);
  }
}
