import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY, of } from 'rxjs';
import { fetchData, setLink } from './link.actions';
import { switchMap, map, withLatestFrom, concatMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Link } from './link.service';
import { State } from './reducers';
import { Store, select } from '@ngrx/store';

@Injectable()
export class LinkEffects {

    
  private endpoint = "/api/config";

    fetchData$ = createEffect(() => this.actions$.pipe(
        ofType(fetchData),
        concatMap(action => of(action).pipe(
            withLatestFrom(this.store.pipe(select('link')))
          )),
        switchMap(([_, link]) => {
            return this.httpClient.get<Link>(`${this.endpoint}/${link.selectedConfig}/link`);
        }),
        map(link => {
            return setLink({link});
        })
        )
    );

    constructor(private actions$: Actions, private httpClient: HttpClient, private store: Store<State>) {}

    
}