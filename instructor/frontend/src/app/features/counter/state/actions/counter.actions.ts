import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { CounterState } from '../reducers/counter.reducer';
import { ValidCountByValues } from '../../models';

// Events are things that happen.
export const counterEvents = createActionGroup({
  source: 'Counter',
  events: {
    'Increment Button Clicked': emptyProps(),
    'Decrement Button Clicked': emptyProps(),
    'Reset Button Clicked': emptyProps(),
    'Count By Set': props<{ by: ValidCountByValues }>(),
  },
});

// Commands - Clear Cause and Effect
export const counterCommands = createActionGroup({
  source: 'Counter Commands',
  events: {
    'Load Counter State': emptyProps(),
  },
});

// Documents - just pure state

export const counterDocuments = createActionGroup({
  source: 'Counter Documents',
  events: {
    'Counter State': props<{ payload: CounterState }>(),
  },
});
