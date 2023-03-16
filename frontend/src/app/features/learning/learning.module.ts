import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LearningComponent } from './learning.component';
import { RouterModule, Routes } from '@angular/router';
import { NavigationComponent } from './components/navigation/navigation.component';
import { ListComponent } from './components/list/list.component';
import { OverviewComponent } from './components/overview/overview.component';
import { NewComponent } from './components/new/new.component';
import { StoreModule } from '@ngrx/store';
import { featureName, reducers } from './state';
import { EffectsModule } from '@ngrx/effects';
import { HttpClientModule } from '@angular/common/http';
import { ItemsEffects } from './state/effects/items.effects';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorDisplayComponent } from './components/error-display/error-display.component';
import { ErrorsEffects } from './state/effects/errors.effects';

const routes: Routes = [
  {
    path: '',
    component: LearningComponent,
    children: [
      {
        path: 'overview',
        component: OverviewComponent,
      },
      {
        path: 'list',
        component: ListComponent,
      },
      {
        path: 'new',
        component: NewComponent,
      },
      {
        path: '**',
        redirectTo: 'overview',
      },
    ],
  },
];

@NgModule({
  declarations: [
    LearningComponent,
    NavigationComponent,
    ListComponent,
    OverviewComponent,
    NewComponent,
    ErrorDisplayComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature(featureName, reducers),
    EffectsModule.forFeature([
      ItemsEffects,
      ErrorsEffects,
    ]),
    HttpClientModule,
    ReactiveFormsModule,
  ],
})
export class LearningModule {}
