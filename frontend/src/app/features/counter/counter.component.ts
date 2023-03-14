import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css'],
})
export class CounterComponent {
  current = 0;

  increment() {
    this.current += 1;
  }

  decrement() {
    this.current -= 1;
  }
}
