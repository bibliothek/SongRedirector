import { Component, OnInit } from '@angular/core';
import { State } from '../reducers';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { fetchConfigNames, selectConfig } from '../link.actions';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  
  configNames$: Observable<string[]>;
  
  private _currentConfig = "";

  ngOnInit(): void {
    this.configNames$ = this.store.pipe(select('link'), map(link => link.configs.slice().sort()));
    this.store.pipe(select('link'), map(link => link.selectedConfig)).subscribe((config) => this._currentConfig = config );
    this.store.dispatch(fetchConfigNames());
  }

  onSelect(event) {
    console.log(event);
  }

  get currentConfig(): string {
    return this._currentConfig;
  }

  set currentConfig(value: string) {
    if(value === this._currentConfig){
      return;
    }
    this.store.dispatch(selectConfig({name: value}));
  }

  constructor(private store: Store<State>) {}

}
