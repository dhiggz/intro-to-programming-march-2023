import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { itemsCommands } from './state/actions/items.actions';

@Component({
  selector: 'app-learning',
  templateUrl: './learning.component.html',
  styleUrls: ['./learning.component.css'],
})
export class LearningComponent {
  constructor(store: Store) {
    store.dispatch(itemsCommands.loadTheItems());
  }
}
