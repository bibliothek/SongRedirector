import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Link } from 'src/app/link.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-link-form',
  templateUrl: './link-form.component.html',
  styleUrls: ['./link-form.component.scss']
})
export class LinkFormComponent implements OnInit {

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

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.title = this.isNew ? 'New link' : 'Edit link';
    this.initForm();
  }

  initForm() {
    this.linkForm = new FormGroup({
      name: new FormControl(this.link.displayName, Validators.required),
      uri: new FormControl(this.link.uri, [Validators.required, Validators.pattern('https?://.+')])
    });
  }
  
  onDiscard() {
    this.router.navigate(['..'], {relativeTo: this.route});
  }

  onSubmit() {
    const link = {...this.link, displayName: this.linkForm.value.name, uri: this.linkForm.value.uri};
    this.save.emit(link);
  }

}
