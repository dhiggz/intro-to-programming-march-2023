import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectErrorMessage, selectHasError } from '../../state';
import { errorsEvents } from '../../state/actions/errors.actions';

@Component({
  selector: 'app-error-display',
  templateUrl: './error-display.component.html',
  styleUrls: ['./error-display.component.css'],
})
export class ErrorDisplayComponent {
  hasError$ = this.store.select(selectHasError);
  errorMessage$ = this.store.select(selectErrorMessage);
  constructor(private readonly store: Store) {}

  clear() {
    this.store.dispatch(errorsEvents.errorCleared());
  }
}
