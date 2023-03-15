import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CounterComponent } from './counter.component';
import { StoreModule } from '@ngrx/store';
import { featureName, reducers } from './state';
import { CounterPrefsComponent } from './components/counter-prefs/counter-prefs.component';
import { EffectsModule } from '@ngrx/effects';
import { CounterEffects } from './state/effects/counter.effects';
@NgModule({
  declarations: [
    CounterComponent,
    CounterPrefsComponent,
  ],
  imports: [
    CommonModule,
    StoreModule.forFeature(featureName, reducers),
    EffectsModule.forFeature([CounterEffects]),
  ],
  exports: [CounterComponent],
})
export class CounterModule {}
