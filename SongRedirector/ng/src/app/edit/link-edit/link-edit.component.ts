import { Component, OnInit } from "@angular/core";
import { Link } from "src/app/link.model";
import { Store, select } from "@ngrx/store";
import { State } from "src/app/reducers";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { fetchConfig, getLink, saveLink } from "src/app/link.actions";
import { switchMap, concatMap, withLatestFrom } from "rxjs/operators";
import * as fromLinks from "../../link.reducers";
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: "app-link-edit",
  templateUrl: "./link-edit.component.html"
})
export class LinkEditComponent implements OnInit {

  link: Link = {
    id: 0,
    displayName: "",
    uri: "",
    youTubeEmbedCode: "",
    youTubeStartTime: "",
    probability: 10
  };

  constructor(private store: Store<State>, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    this.store.select("link").subscribe(linkState => {
      if (linkState.currentEditLink) {
        this.link = linkState.currentEditLink;
      }
    });
    this.route.params.subscribe((params) => this.store.dispatch(getLink()));
  }

  onSave(link) {
    this.store.dispatch(saveLink({link}));
    this.router.navigate(['..'], {relativeTo: this.route});
  }

}
