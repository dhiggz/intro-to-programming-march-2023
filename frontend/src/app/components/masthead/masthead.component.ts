import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCounterCurrent } from 'src/app/features/counter/state';

@Component({
  selector: 'app-masthead',
  templateUrl: './masthead.component.html',
  styleUrls: ['./masthead.component.css'],
})
export class MastheadComponent {
  current$ = this.store.select(selectCounterCurrent);
  constructor(private store: Store) {}
}
