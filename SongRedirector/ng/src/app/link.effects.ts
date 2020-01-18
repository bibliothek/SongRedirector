import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { EMPTY, of } from "rxjs";
import {
  fetchLink,
  setLink,
  fetchConfigNames,
  setConfigNames,
  selectConfig,
  upvote,
  downvote
} from "./link.actions";
import { switchMap, map, withLatestFrom, concatMap } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";
import { Link } from "./link.model";
import { State } from "./reducers";
import { Store, select } from "@ngrx/store";

@Injectable()
export class LinkEffects {
  private endpoint = "/api/config";

  fetchLink$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchLink),
      concatMap(action =>
        of(action).pipe(withLatestFrom(this.store.pipe(select("link"))))
      ),
      switchMap(([_, link]) => {
        return this.httpClient.get<Link>(
          `${this.endpoint}/${link.selectedConfig}/link`
        );
      }),
      map(link => {
        return setLink({ link });
      })
    )
  );

  fetchConfigNames$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchConfigNames),
      switchMap(() => {
        return this.httpClient.get<string[]>(`${this.endpoint}`);
      }),
      map(configNames => {
        return setConfigNames({ configNames });
      })
    )
  );

  upvoteLink$ = createEffect(() =>
    this.actions$.pipe(
      ofType(upvote),
      concatMap(action =>
        of(action).pipe(withLatestFrom(this.store.pipe(select("link"))))
      ),
      switchMap(([_, link]) => {
        return this.httpClient.post(`${this.endpoint}/${link.selectedConfig}/link/${link.currentLink.id}/upvote`, {});
      })
    ), {dispatch: false}
  );

  downvoteLink$ = createEffect(() =>
    this.actions$.pipe(
      ofType(downvote),
      concatMap(action =>
        of(action).pipe(withLatestFrom(this.store.pipe(select("link"))))
      ),
      switchMap(([_, link]) => {
        return this.httpClient.post(`${this.endpoint}/${link.selectedConfig}/link/${link.currentLink.id}/downvote`, {});
      })
    ), {dispatch: false}
  );

  selectConfig$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectConfig),
      map(_ => {
        return fetchLink();
      })
    )
  );

  constructor(
    private actions$: Actions,
    private httpClient: HttpClient,
    private store: Store<State>
  ) {}
}
