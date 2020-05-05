import { Component, OnInit } from "@angular/core";
import { SidebarService } from "./sidebar.service";

@Component({
  selector: "inventory-sidebar",
  templateUrl: "./sidebar.component.html",
  providers: [SidebarService],
})
export class SidebarComponent implements OnInit {
  public constructor(public service: SidebarService) {
    service.validateChangePassword();
  }

  ngOnInit() {
    this.service.getMenuByUserId(() => {
      setTimeout(() => {
        try {
          const element = <HTMLElement>(
            document.querySelector("a.nav-link.active").parentNode.parentNode
              .parentNode
          );

          (element.firstElementChild as any).click();
        } catch (e) {}
      });
    });
  }

  collapseMenu(current: any) {
    try {
      if (current.classList.contains("open")) {
        return;
      }

      const nodes = document.querySelectorAll(".nav-item.nav-dropdown.open");
      nodes.forEach((f) => (f.children[0] as any).click());
    } catch (e) {}
  }
}
