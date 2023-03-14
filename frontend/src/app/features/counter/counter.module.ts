import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CounterComponent } from './counter.component';
import { StoreModule } from '@ngrx/store';
import { featureName, reducers } from './state';

@NgModule({
  declarations: [CounterComponent],
  imports: [
    CommonModule,
    StoreModule.forFeature(featureName, reducers),
  ],
  exports: [CounterComponent],
})
export class CounterModule {}
