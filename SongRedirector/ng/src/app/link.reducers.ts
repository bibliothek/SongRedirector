import { Link } from "./link.model";
import { Action, createReducer, on } from "@ngrx/store";
import * as LinkActions from "./link.actions";

export interface State {
  selectedConfig: string;
  configs: string[];
  currentLink: Link;
  configLinks: Link[];
  newLink: boolean;
}

export const initialState: State = {
  selectedConfig: "default",
  configs: [],
  currentLink: null,
  configLinks: [],
  newLink: false
};

export function linkReducer(linkState: State | undefined, linkAction: Action) {
  return createReducer(
    initialState,
    on(LinkActions.selectConfig, (state, action) => { return { ...state, selectedConfig: action.name, newLink: false };}),
    on(LinkActions.setConfigNames, (state, action) => { return { ...state, configs: action.configNames, newLink: false };}),
    on(LinkActions.setConfigLinks, (state, action) => { return { ...state, configLinks: action.configLinks, newLink: false };}),
    on(LinkActions.setLink, (state, action) => { return { ...state, currentLink: action.link, newLink: true };}),
    on(LinkActions.upvote, (state) => { return { ...state, currentLink: {...state.currentLink, probability: state.currentLink.probability + 1}, newLink: false };}),
    on(LinkActions.downvote, (state) => { return { ...state, currentLink: {...state.currentLink, probability: state.currentLink.probability + -1}, newLink: false };}),
  )(linkState, linkAction);
}
