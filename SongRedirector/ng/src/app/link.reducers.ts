import { Link } from "./link.service";
import { Action, createReducer, on } from "@ngrx/store";
import * as LinkActions from "./link.actions";

export interface State {
  selectedConfig: string;
  configs: string[];
  currentLink: Link;
  configLinks: Link[];
}

export const initialState: State = {
  selectedConfig: "default",
  configs: [],
  currentLink: null,
  configLinks: []
};

export function linkReducer(linkState: State | undefined, linkAction: Action) {
  return createReducer(
    initialState,
    on(LinkActions.selectConfig, (state, action) => { return { ...state, selectedConfig: action.name };}),
    on(LinkActions.setConfigNames, (state, action) => { return { ...state, configs: action.configNames };}),
    on(LinkActions.setConfigLinks, (state, action) => { return { ...state, configLinks: action.configLinks };}),
    on(LinkActions.setLink, (state, action) => { return { ...state, currentLink: action.link };}),
  )(linkState, linkAction);
}
