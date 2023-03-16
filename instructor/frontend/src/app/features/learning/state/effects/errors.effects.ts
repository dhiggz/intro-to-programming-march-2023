import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map } from 'rxjs';
import { errorsEvents } from '../actions/errors.actions';

@Injectable()
export class ErrorsEffects {
  // sendErrorToServer$ = createEffect(
  //   () => {
  //     return this.actions$.pipe(
  //       ofType(errorsEvents.errorHappened),
  //       map(({ message, innerError }) =>
  //         console.log(
  //           `This error should be sent to the API ${message}, ${JSON.stringify(
  //             innerError,
  //           )}`,
  //         ),
  //       ),
  //     );
  //   },
  //   { dispatch: false },
  // );

  sendErrorToServer$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(errorsEvents.errorHappened),
        map((action) =>
          console.log(
            `This error should be sent to the API ${
              action.message
            }, ${JSON.stringify(action.innerError)}`,
          ),
        ),
      );
    },
    { dispatch: false },
  );
  constructor(private readonly actions$: Actions) {}
}
