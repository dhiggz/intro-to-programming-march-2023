import { createReducer, on } from '@ngrx/store';
import { ValidCountByValues } from '../../models';
import { counterEvents } from '../actions/counter.actions';
// Describe it for TypeScript
export interface CounterState {
  current: number;
  by: ValidCountByValues;
}

// What is the "initial" state when the application starts.

const initialState: CounterState = {
  current: 0,
  by: 1,
};

// Here is where we decide that if a action happens, does that mean a new state needs created?
// We will have access to the current state, and the action that just happened, and we use that (if we want) to create a new state
// given the current state, you have to return a NEW state (you cannot modify the current state)
export const reducer = createReducer(
  initialState,
  on(counterEvents.incrementButtonClicked, (currentState: CounterState) => ({
    ...currentState,
    current: currentState.current + currentState.by,
  })),
  on(counterEvents.decrementButtonClicked, (s) => ({
    ...s,
    current: s.current - s.by,
  })),
  on(counterEvents.resetButtonClicked, () => initialState),
  on(counterEvents.countBySet, (s, a) => ({ ...s, by: a.by })),
);
