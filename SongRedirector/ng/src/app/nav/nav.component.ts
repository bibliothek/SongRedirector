import { Component, OnInit, ChangeDetectorRef, OnDestroy } from "@angular/core";
import { State } from "../reducers";
import { Store, select } from "@ngrx/store";
import { Observable } from "rxjs";
import { map, shareReplay } from "rxjs/operators";
import { fetchConfigNames } from "../link.actions";
import {
  Breakpoints,
  BreakpointObserver,
  MediaMatcher
} from "@angular/cdk/layout";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.scss"]
})
export class NavComponent implements OnInit, OnDestroy {
  configNames$: Observable<string[]>;

  private _currentConfig = "";

  ngOnInit(): void {
    this.configNames$ = this.store.pipe(
      select("link"),
      map(link => link.configs.slice().sort())
    );
    this.store
      .pipe(
        select('router', 'state', 'root', 'firstChild', 'params', 'config'),
      )
      .subscribe(config => (this._currentConfig = config));
    this.store.dispatch(fetchConfigNames());
  }

  get currentConfig(): string {
    return this._currentConfig;
  }

  set currentConfig(value: string) {
    if (value === this._currentConfig) {
      return;
    }
    this.router.navigate( [this.router.url.substring(0, this.router.url.lastIndexOf('/')) , value]);
  }

  mobileQuery: MediaQueryList;

  private _mobileQueryListener: () => void;

  constructor(
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    private store: Store<State>,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.mobileQuery = media.matchMedia("(max-width: 600px)");
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
}
