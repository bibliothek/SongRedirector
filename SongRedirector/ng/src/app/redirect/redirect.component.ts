import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { State } from '../reducers';
import { fetchLink } from '../link.actions';

@Component({
  selector: 'app-redirect',
  template: ''
})
export class RedirectComponent implements OnInit {

  constructor(
    private store: Store<State>,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.store.pipe(select("link")).subscribe(link => {
      if (link && link.currentLink) {
        window.location.href = link.currentLink.uri;
      }
    });
    this.route.params.subscribe(() =>this.store.dispatch(fetchLink()));
  }

}
