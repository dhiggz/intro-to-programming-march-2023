import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MastheadComponent } from './components/masthead/masthead.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { SupportComponent } from './components/support/support.component';
import { HttpClientModule } from '@angular/common/http';
import { OnCallDataService } from './services/oncall-data.service';
import { CounterModule } from './features/counter/counter.module';
import { StoreModule } from '@ngrx/store';
import { reducers } from './state';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
@NgModule({
  declarations: [
    AppComponent,
    MastheadComponent,
    DashboardComponent,
    NavigationComponent,
    SupportComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CounterModule,
    StoreModule.forRoot(reducers),
    StoreDevtoolsModule.instrument(), // this is the HAWTNESS for development.
    EffectsModule.forRoot([]),
  ],
  providers: [OnCallDataService],
  bootstrap: [AppComponent],
})
export class AppModule {}
