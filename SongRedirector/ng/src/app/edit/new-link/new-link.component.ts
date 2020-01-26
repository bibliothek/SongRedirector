import { Component, OnInit } from '@angular/core';
import { Link } from 'src/app/link.model';
import { Store } from '@ngrx/store';
import { ActivatedRoute, Router } from '@angular/router';
import { addLink } from 'src/app/link.actions';
import { State } from 'src/app/reducers';

@Component({
  selector: 'app-new-link',
  templateUrl: './new-link.component.html'
})
export class NewLinkComponent implements OnInit {

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

  ngOnInit() {}

  onSave(link) {
     this.store.dispatch(addLink({link}));
    this.router.navigate(['..'], {relativeTo: this.route});
  }

}
