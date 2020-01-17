import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import * as fromLinks from '../link.reducers';

export interface State {
  link: fromLinks.State
}

export const reducers: ActionReducerMap<State> = {
  link: fromLinks.linkReducer
};

export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
