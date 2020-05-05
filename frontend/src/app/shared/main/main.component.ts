import {
  Router,
  NavigationStart,
  NavigationEnd,
  NavigationCancel,
  NavigationError,
  RouterState
} from "@angular/router";
import { ConfigService, createBreadcrumbs } from "utilscore-ar";
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { filter } from "rxjs/operators";
import { Title } from "@angular/platform-browser";
import { environment } from "../../../environments/environment";

@Component({
  selector: "inventory-main",
  templateUrl: "./main.component.html"
})
export class MainComponent {
  loading = true;
  breadcrumbs: Array<any>;
  status: { isopen: boolean } = { isopen: false };

  constructor(
    public router: Router,
    route: ActivatedRoute,
    public configService: ConfigService,
    private titleService: Title
  ) {
    router.events.subscribe(event => this.navigationInterceptor(event));

    router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => (this.breadcrumbs = createBreadcrumbs(route.root)));

    configService.emitter.subscribe(data => {
      if ("BlockUI" in data) {
        this.createBlocker(data.BlockUI);
      }
    });
  }

  toggled(open: boolean): void {}

  public toggleDropdown($event: MouseEvent): void {
    $event.preventDefault();
    $event.stopPropagation();
    this.status.isopen = !this.status.isopen;
  }

  navigationInterceptor($event: Object): void {
    if ($event instanceof NavigationStart) {
      this.createBlocker(true);
    }

    if (
      $event instanceof NavigationEnd ||
      $event instanceof NavigationCancel ||
      $event instanceof NavigationError
    ) {
      setTimeout(() => this.createBlocker(false), 10);

      const title = this.getTitle(
        this.router.routerState,
        this.router.routerState.root
      ).join(" | ");

      if (title && title.length > 0) {
        this.titleService.setTitle(`${environment.appName} | ${title}`);
      } else {
        this.titleService.setTitle(environment.appName);
      }
    }
  }

  getTitle(state: RouterState, parent: ActivatedRoute) {
    const data = [];

    if (parent && parent.snapshot.data && parent.snapshot.data.title) {
      data.push(parent.snapshot.data.title);
    }

    if (state && parent) {
      data.push(...this.getTitle(state, (state as any).firstChild(parent)));
    }

    return data;
  }

  createBlocker(value: boolean) {
    if (value === this.loading) {
      return;
    }

    this.loading = value;

    if (this.loading) {
      document.body.style.cursor = "wait";
    } else {
      document.body.style.cursor = "initial";
    }
  }
}
