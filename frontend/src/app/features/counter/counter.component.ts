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
  current$ = this.store.select(selectCounterCurrent);
  resetDisabled$ = this.store.select(selectCounterResetDisabled);

  constructor(private readonly store: Store) {}

  increment() {
    //this.current += 1;
    this.store.dispatch(counterEvents.incrementButtonClicked());
  }

  decrement() {
    //this.current -= 1;
    this.store.dispatch(counterEvents.decrementButtonClicked());
  }

  reset() {
    this.store.dispatch(counterEvents.resetButtonClicked());
  }
}
