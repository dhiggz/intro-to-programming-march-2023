import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { ValidCountByValues } from '../../models';
import { selectCountingBy } from '../../state';
import { counterEvents } from '../../state/actions/counter.actions';

@Component({
  selector: 'app-counter-prefs',
  templateUrl: './counter-prefs.component.html',
  styleUrls: ['./counter-prefs.component.css'],
})
export class CounterPrefsComponent {
  by$ = this.store.select(selectCountingBy);

  constructor(private readonly store: Store) {}
  setCountBy(by: ValidCountByValues) {
    this.store.dispatch(counterEvents.countBySet({ by }));
  }
}
