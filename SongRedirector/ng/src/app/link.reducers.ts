import { Link } from "./link.model";
import { Action, createReducer, on } from "@ngrx/store";
import * as LinkActions from "./link.actions";

export interface State {
  configs: string[];
  currentLink: Link;
  configLinks: Link[];
  newLink: boolean;
}

export const initialState: State = {
  configs: [],
  currentLink: null,
  configLinks: [],
  newLink: false
};

export function linkReducer(linkState: State | undefined, linkAction: Action) {
  return createReducer(
    initialState,
    on(LinkActions.setConfigNames, (state, action) => { return { ...state, configs: action.configNames, newLink: false };}),
    on(LinkActions.setConfigLinks, (state, action) => { return { ...state, configLinks: action.configLinks, newLink: false };}),
    on(LinkActions.setLink, (state, action) => { return { ...state, currentLink: action.link, newLink: true };}),
    on(LinkActions.deleteLink, (state, action) => {return {...state, configLinks: state.configLinks.filter(x=> x.id !== action.id) }}),
    on(LinkActions.saveLink, (state, action) => {return {...state, configLinks: state.configLinks.filter(x=> x.id !== action.link.id).concat([action.link]) }}),
    on(LinkActions.addLink, (state, action) => {return {...state, configLinks: state.configLinks.concat([action.link]) }}),
    on(LinkActions.upvote, (state) => { return { ...state, currentLink: {...state.currentLink, probability: state.currentLink.probability + 1}, newLink: false };}),
    on(LinkActions.downvote, (state) => { return { ...state, currentLink: {...state.currentLink, probability: state.currentLink.probability + -1}, newLink: false };}),
  )(linkState, linkAction);
}
