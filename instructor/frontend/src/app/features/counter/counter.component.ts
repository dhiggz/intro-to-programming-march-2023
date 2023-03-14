import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCounterCurrent, selectCounterResetDisabled } from './state';
import { counterEvents } from './state/actions/counter.actions';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css'],
})
export class CounterComponent {
  // TODO: Make this an observable of some data in the store.
  current$ = this.store.select(selectCounterCurrent);
  resetDisabled$ = this.store.select(selectCounterResetDisabled);

  constructor(private readonly store: Store) {}

  increment() {
    // TODO: Dispatch an action to the store to say the count incremented
    this.store.dispatch(counterEvents.incrementButtonClicked());
  }

  decrement() {
    // TODO: Dispatch an action to the store to say the count was decremented
    this.store.dispatch(counterEvents.decrementButtonClicked());
  }

  reset() {
    this.store.dispatch(counterEvents.resetButtonClicked());
  }
}
