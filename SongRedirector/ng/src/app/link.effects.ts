import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { EMPTY, of, empty } from "rxjs";
import {
  fetchLink,
  setLink,
  fetchConfigNames,
  setConfigNames,
  upvote,
  downvote,
  fetchConfig,
  setConfigLinks,
  getLink,
  deleteLink,
  saveLink,
  addLink,
  setEditLink
} from "./link.actions";
import {
  switchMap,
  map,
  withLatestFrom,
  concatMap,
  tap,
  take,
  filter
} from "rxjs/operators";
import { HttpClient } from "@angular/common/http";
import { Link, Config } from "./link.model";
import { State } from "./reducers";
import { Store, select } from "@ngrx/store";

@Injectable()
export class LinkEffects {
  private endpoint = "/api/config";

  fetchLink$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchLink),
      switchMap(_ =>
        this.store
          .select("router", "state", "root", "firstChild", "params", "config")
          .pipe(take(1))
      ),
      switchMap(config => {
        return this.httpClient.get<Link>(`${this.endpoint}/${config}/link`);
      }),
      map(link => setLink({ link }))
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

  fetchConfig$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchConfig),
      switchMap(_ =>
        this.store
          .select("router", "state", "root", "firstChild", "params", "config")
          .pipe(take(1))
      ),
      switchMap(config => {
        return this.httpClient.get<Config>(`${this.endpoint}/${config}`);
      }),
      map(config => setConfigLinks({ configLinks: config.links }))
    )
  );

  upvoteLink$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(upvote),
        switchMap(_ =>
          this.store.pipe(
            select("link"),
            take(1),
            withLatestFrom(
              this.store.select(
                "router",
                "state",
                "root",
                "firstChild",
                "params",
                "config"
              )
            )
          )
        ),
        switchMap(([link, config]) => {
          return this.httpClient.post(
            `${this.endpoint}/${config}/link/${link.currentLink.id}/upvote`,
            {}
          );
        })
      ),
    { dispatch: false }
  );

  downvoteLink$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(downvote),
        switchMap(_ =>
          this.store.pipe(
            select("link"),
            take(1),
            withLatestFrom(
              this.store.select(
                "router",
                "state",
                "root",
                "firstChild",
                "params",
                "config"
              )
            )
          )
        ),
        switchMap(([link, config]) => {
          return this.httpClient.post(
            `${this.endpoint}/${config}/link/${link.currentLink.id}/downvote`,
            {}
          );
        })
      ),
    { dispatch: false }
  );

  getLink$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getLink),
      switchMap(_ =>
        this.store.select("router", "state", "root", "firstChild", "params")
      ),
      filter(params => !!params["id"]),
      switchMap(params => {
        return this.httpClient.get<Link>(
          `${this.endpoint}/${params["config"]}/link/${params["id"]}`
        );
      }),
      map(link => {
        return setLink({ link });
      })
    )
  );

  getEditLink$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getLink),
      switchMap(_ =>
        this.store.select("router", "state", "root", "firstChild", "params")
      ),
      filter(params => !!params["id"]),
      switchMap(params => {
        return this.httpClient.get<Link>(
          `${this.endpoint}/${params["config"]}/link/${params["id"]}`
        );
      }),
      map(link => {
        return setEditLink({ link });
      })
    )
  );

  deleteLink$ = createEffect(() =>
  this.actions$.pipe(
      ofType(deleteLink),
      concatMap(action => {
        return of(action).pipe(withLatestFrom(this.store.select(
          "router",
          "state",
          "root",
          "firstChild",
          "params",
          "config"
        )))
      }
      ),
      switchMap(([action, config]) => {
        return this.httpClient.delete(`${this.endpoint}/${config}/link/${action.id}`);
      }
      )
  ), {dispatch: false});

  saveLink$ = createEffect(() =>
  this.actions$.pipe(
      ofType(saveLink),
      concatMap(action => {
        return of(action).pipe(withLatestFrom(this.store.select(
          "router",
          "state",
          "root",
          "firstChild",
          "params",
          "config"
        )))
      }
      ),
      switchMap(([action, config]) => {
        return this.httpClient.put(`${this.endpoint}/${config}/link/${action.link.id}`, action.link);
      }
      )
  ), {dispatch: false});

  addLink$ = createEffect(() =>
  this.actions$.pipe(
      ofType(addLink),
      concatMap(action => {
        return of(action).pipe(withLatestFrom(this.store.select(
          "router",
          "state",
          "root",
          "firstChild",
          "params",
          "config"
        )))
      }
      ),
      switchMap(([action, config]) => {
        return this.httpClient.post(`${this.endpoint}/${config}/link`, action.link);
      }
      )
  ), {dispatch: false});

  constructor(
    private actions$: Actions,
    private httpClient: HttpClient,
    private store: Store<State>
  ) {}
}
