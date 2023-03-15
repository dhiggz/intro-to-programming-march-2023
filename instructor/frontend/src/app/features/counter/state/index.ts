import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromCounter from './reducers/counter.reducer';
export const featureName = 'counterFeature';

// eslint-disable-next-line @typescript-eslint/no-empty-interface
export interface CounterState {
  counter: fromCounter.CounterState;
}

export const reducers: ActionReducerMap<CounterState> = {
  counter: fromCounter.reducer,
};

// Step 1 - how do we get to the feature?
const selectFeature = createFeatureSelector<CounterState>(featureName);

// Step 2 - another selector function per "branch" of the feature.

export const selectCounterBranch = createSelector(
  selectFeature, // this is the feature
  (f) => f.counter, // f = the feature
);

// Step 3 - (optional) helpers

// Step 4 - What the component needs
// component "counter" needs an observable of the counter -> current

export const selectCounterCurrent = createSelector(
  selectCounterBranch,
  (b) => b.current,
);

export const selectCounterResetDisabled = createSelector(
  selectCounterCurrent,
  (c) => c === 0,
);

export const selectCountingBy = createSelector(
  selectCounterBranch,
  (b) => b.by,
);
