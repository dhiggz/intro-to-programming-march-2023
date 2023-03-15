import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { map, tap, filter } from 'rxjs';
import { selectCounterBranch } from '..';
import {
  counterCommands,
  counterDocuments,
  counterEvents,
} from '../actions/counter.actions';
import { CounterState } from '../reducers/counter.reducer';

@Injectable()
export class CounterEffects {
  // logItAll$ = createEffect(
  //   () => {
  //     return this.actions$.pipe(tap((action) => console.log(action.type))); // =>
  //   },
  //   { dispatch: false },
  // );   // Every time an action of type increment, decrement, reset, countBySet happens...
  // write the counter state to localstorage.

  loadCounterState$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(counterCommands.loadCounterState),
      map(() => localStorage.getItem('counter-state')),
      filter((storedValue) => storedValue !== null),
      map((theString) => JSON.parse(theString!) as CounterState),
      map((counterState) =>
        counterDocuments.counterState({ payload: counterState }),
      ),
    );
  });

  writeCounterState$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(
          counterEvents.countBySet,
          counterEvents.decrementButtonClicked,
          counterEvents.incrementButtonClicked,
          counterEvents.resetButtonClicked,
        ),
        concatLatestFrom(() => this.store.select(selectCounterBranch)), // { current: 99, by: 5}
        tap(
          ([
            ,
            data,
          ]) => localStorage.setItem('counter-state', JSON.stringify(data)),
        ),
      );
    },
    { dispatch: false },
  );
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store,
  ) {}
}
