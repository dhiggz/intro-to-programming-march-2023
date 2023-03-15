import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SupportComponent } from './components/support/support.component';
import { CounterComponent } from './features/counter/counter.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'support',
    component: SupportComponent,
  },
  {
    path: 'counter',
    component: CounterComponent,
  },
  {
    path: 'learning',
    loadChildren: () =>
      import('./features/learning/learning.module').then(
        (m) => m.LearningModule,
      ),
  },
  {
    path: '**',
    redirectTo: 'dashboard',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
