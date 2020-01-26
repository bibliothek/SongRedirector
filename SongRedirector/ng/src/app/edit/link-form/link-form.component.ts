import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Link } from 'src/app/link.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { State } from 'src/app/reducers';
import { Store } from '@ngrx/store';
import { setEditLink } from 'src/app/link.actions';

@Component({
  selector: 'app-link-form',
  templateUrl: './link-form.component.html',
  styleUrls: ['./link-form.component.scss']
})
export class LinkFormComponent implements OnInit, OnDestroy {
  ngOnDestroy(): void {
    this.store.dispatch(setEditLink({link: null}));
  }

  @Input()
  isNew = false;

  _link: Link;

  @Input()
  set link(link: Link) {
    this._link = link;
    this.initForm();
  }

  get link() {
    return this._link;
  }

  @Output()
  save = new EventEmitter<Link>();

  title = '';

  linkForm: FormGroup;

  waiting = true;

  constructor(private store: Store<State>, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.title = this.isNew ? 'New link' : 'Edit link';
    this.initForm();
  }

  initForm() {
    this.waiting = this.isNew ? false : this.link.id === 0;
    this.linkForm = new FormGroup({
      name: new FormControl(this.link.displayName, Validators.required),
      uri: new FormControl(this.link.uri, [Validators.required, Validators.pattern('https?://.+')]),
      weight: new FormControl(this.link.probability, Validators.required)
    });
  }
  
  onDiscard() {
    this.router.navigate(['..'], {relativeTo: this.route});
  }

  onSubmit() {
    const link = {...this.link, displayName: this.linkForm.value.name, uri: this.linkForm.value.uri, probability: this.linkForm.value.weight};
    this.save.emit(link);
  }

}
