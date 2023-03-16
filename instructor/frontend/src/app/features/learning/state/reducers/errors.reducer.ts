import { createReducer, on } from '@ngrx/store';
import { errorsEvents } from '../actions/errors.actions';

export interface ErrorsState {
  hasError: boolean;
  errorMessage?: string;
}

const initialState: ErrorsState = {
  hasError: false,
};

export const reducer = createReducer(
  initialState,
  on(errorsEvents.errorCleared, () => initialState),
  on(errorsEvents.errorHappened, (s, a) => ({
    ...s,
    hasError: true,
    errorMessage: a.message,
  })),
);
