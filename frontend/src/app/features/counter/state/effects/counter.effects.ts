import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { z } from 'zod';
import { map, tap, filter, catchError, of } from 'rxjs';
import { selectCounterBranch } from '..';
import {
  counterCommands,
  counterDocuments,
  counterEvents,
} from '../actions/counter.actions';
import { CounterState } from '../reducers/counter.reducer';

@Injectable()
export class CounterEffects {
  private readonly CountDataSchema = z.object({
    current: z.number(),
    by: z.union([
      z.literal(1),
      z.literal(3),
      z.literal(5),
    ]),
  });
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
      map((theString) => JSON.parse(theString!)),
      map((susObject) => this.CountDataSchema.parse(susObject) as CounterState),
      map((counterState) =>
        counterDocuments.counterState({ payload: counterState }),
      ),
      catchError(() => {
        console.log('We have ourselves a hacker here!');
        localStorage.clear();
        return of({ type: 'Localstorage Error' });
      }),
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
