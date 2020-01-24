import { Component, OnInit } from "@angular/core";
import { Link } from "src/app/link.model";
import { Store, select } from "@ngrx/store";
import { State } from "src/app/reducers";
import { ActivatedRoute, Params } from "@angular/router";
import { fetchConfig, getLink } from "src/app/link.actions";
import { switchMap, concatMap, withLatestFrom } from "rxjs/operators";
import * as fromLinks from "../../link.reducers";

@Component({
  selector: "app-link-edit",
  templateUrl: "./link-edit.component.html",
  styleUrls: ["./link-edit.component.scss"]
})
export class LinkEditComponent implements OnInit {
  link: Link = {
    id: 0,
    displayName: "",
    uri: "",
    youTubeEmbedCode: "",
    youTubeStartTime: "",
    probability: 0
  };

  constructor(private store: Store<State>, private route: ActivatedRoute) {}

  ngOnInit() {
    this.store.select("link").subscribe(linkState => {
      if (linkState.currentLink) {
        this.link = linkState.currentLink;
      }
    });

    // this.store.select('link').pipe(withLatestFrom(this.route.queryParams)).subscribe(([linkState, params]) => {
    //   this.update(linkState, params);
    // });

    // this.route.queryParams
    //   .pipe(withLatestFrom(this.store.select("link")))
    //   .subscribe(([params, linkState]) => this.update(linkState, params));

    // this.route.params.subscribe(params => {
    //   return this.store.dispatch(fetchConfig());
    // });
    this.route.params.subscribe(params => this.store.dispatch(getLink()));
  }

  private update(linkState: fromLinks.State, params: Params): void {
    if (linkState) {
      console.log(linkState);
      console.log(params["id"]);
      const linkInConfig = linkState.configLinks.find(
        x => x.id === params["id"]
      );
      if (linkInConfig) {
        this.link = linkInConfig;
      }
    }
  }
}
