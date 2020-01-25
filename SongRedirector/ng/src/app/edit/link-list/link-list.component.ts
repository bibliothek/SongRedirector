import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { State } from '../../reducers';
import { ActivatedRoute, Router } from '@angular/router';
import { Link } from '../../link.model';
import { fetchConfig, deleteLink } from '../../link.actions';

@Component({
  selector: 'app-link-list',
  templateUrl: './link-list.component.html',
  styleUrls: ['./link-list.component.scss']
})
export class LinkListComponent implements OnInit {

  links: Link[] = [];

  displayedColumns: string[] = ['displayName', 'uri', 'probability', 'actions'];

  constructor(private store: Store<State>, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    this.store.pipe(select("link")).subscribe(link => {
      if (link) {
        this.links = link.configLinks;
      }
    });
    this.route.params.subscribe(() => this.store.dispatch(fetchConfig()));
  }

  delete(id: number) {
    this.store.dispatch(deleteLink({id}));
  }

  edit(id: number) {
    this.router.navigate([id], {relativeTo: this.route});
  }

}
