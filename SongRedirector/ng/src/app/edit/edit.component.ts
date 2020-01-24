import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { State } from '../reducers';
import { ActivatedRoute } from '@angular/router';
import { Link } from '../link.model';
import { fetchConfig } from '../link.actions';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  links: Link[] = [];

  displayedColumns: string[] = ['displayName', 'uri', 'probability'];

  constructor(private store: Store<State>, private route: ActivatedRoute) { }

  ngOnInit() {

    this.store.pipe(select("link")).subscribe(link => {
      if (link) {
        this.links = link.configLinks;
      }
    });
    this.route.params.subscribe(() => this.store.dispatch(fetchConfig()));
  }

}
