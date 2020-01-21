import { createAction, props } from '@ngrx/store';
import { Link } from './link.model';

export const fetchLink = createAction('[Link] Fetch Link');
export const upvote = createAction('[Link] Upvote');
export const downvote = createAction('[Link] Downvote');
export const fetchConfigNames = createAction('[Link] Fetch Config Names');
export const setLink = createAction('[Link] Set Link', props<{link: Link}>());
export const setConfigNames = createAction('[Link] Set Config Names', props<{configNames: string[]}>());
export const setConfigLinks = createAction('[Link] Set Config Links', props<{configLinks: Link[]}>());
