import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LearningComponent } from './learning.component';
import { RouterModule, Routes } from '@angular/router';
import { NavigationComponent } from './components/navigation/navigation.component';
import { NewComponent } from './components/new/new.component';
import { ListComponent } from './components/list/list.component';
import { OverviewComponent } from './components/overview/overview.component';
import { StateComponent } from './state/state.component';
import { featureName, reducers } from './state';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { HttpClientModule } from '@angular/common/http';

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
    NewComponent,
    ListComponent,
    OverviewComponent,
    StateComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature(featureName, reducers),
    EffectsModule.forFeature(),
    HttpClientModule,
  ],
})
export class LearningModule {}
