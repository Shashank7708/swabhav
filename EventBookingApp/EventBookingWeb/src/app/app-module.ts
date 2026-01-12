import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Login } from './pages/login/login';
import { Layout } from './pages/layout/layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { SignUp } from './pages/sign-up/sign-up';
import { NgClass } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LifecycleEvent } from './DummyPages/lifecycle-event/lifecycle-event';
import { Signal } from './DummyPages/signal/signal';
import { ControlFlow } from './DummyPages/control-flow/control-flow';
import { RouterLink } from '@angular/router';
import { NotFound } from './DummyPages/not-found/not-found';
import { Photos } from './DummyPages/photos/photos';
import { Events } from './pages/events/events';

import { ReactiveFormsModule } from '@angular/forms';
import { Booking } from './pages/booking/booking';
import { NotifierModule } from 'angular-notifier';
@NgModule({
  declarations: [
    App,
    Login,
    Layout,
    Dashboard,
    SignUp,
    LifecycleEvent,
    Signal,
    ControlFlow,
    NotFound,
    Photos,
    Events,
    Booking
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgClass,
    FormsModule,
    HttpClientModule ,
    RouterLink,
    ReactiveFormsModule,
    NotifierModule
  ],
  providers: [
    HttpClientModule,
    provideBrowserGlobalErrorListeners(),
    
  ],
  bootstrap: [App]
})
export class AppModule { }
