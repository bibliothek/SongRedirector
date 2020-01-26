import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import * as fromLinks from '../link.reducers';
import { routerReducer, RouterReducerState } from '@ngrx/router-store';

export interface State {
  link: fromLinks.State,
  router: RouterReducerState
}

export const reducers: ActionReducerMap<State> = {
  link: fromLinks.linkReducer,
  router: routerReducer
};

export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
