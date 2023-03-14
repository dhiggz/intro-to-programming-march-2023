import { createActionGroup, emptyProps } from '@ngrx/store';
export const counterEvents = createActionGroup({
  source: 'Counter',
  events: {
    'Increment Button Clicked': emptyProps(),
    'Decrement Button Clicked': emptyProps(),
  },
});
