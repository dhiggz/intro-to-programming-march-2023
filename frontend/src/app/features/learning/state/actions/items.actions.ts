// Events

import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ItemEntity } from '../reducers/items.reducer';

// Commands
export const itemsCommands = createActionGroup({
  source: '[Learning] Items Commands',
  events: {
    'Load The Items': emptyProps(),
  },
});

// Documents

export const itemsDocuments = createActionGroup({
  source: '[Learning] Items Documents',
  events: {
    items: props<{ payload: ItemEntity[] }>(),
  },
});
