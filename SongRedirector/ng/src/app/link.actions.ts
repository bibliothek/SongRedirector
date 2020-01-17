import { createAction, props } from '@ngrx/store';
import { Link } from './link.service';

export const selectConfig = createAction('[Link] Select Config', props<{name: string}>());
export const fetchData = createAction('[Link] Fetch Data');
export const setLink = createAction('[Link] Set Link', props<{link: Link}>());
export const setConfigNames = createAction('[Link] Set Config Names', props<{configNames: string[]}>());
export const setConfigLinks = createAction('[Link] Set Config Links', props<{configLinks: Link[]}>());
