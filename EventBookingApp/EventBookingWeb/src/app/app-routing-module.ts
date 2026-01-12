import { NgModule, signal } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Layout } from './pages/layout/layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { SignUp } from './pages/sign-up/sign-up';
import { ControlFlow } from './DummyPages/control-flow/control-flow';
import { LifecycleEvent } from './DummyPages/lifecycle-event/lifecycle-event';
import { Signal } from './DummyPages/signal/signal';
import { NotFound } from './DummyPages/not-found/not-found';
import { Photos } from './DummyPages/photos/photos';
import { Events } from './pages/events/events';

const routes: Routes = [
  {path:'',redirectTo:'login', pathMatch:'full'},
  {path:'login',component:Login},
  {path:'signUp',component:SignUp},
  {
    path:'',
    component:Layout,
    children:[
      {
      path:'dashboard',
      component:Dashboard
      }
    ]
},
{path:'control-flow', component:ControlFlow},
{path:'life-cycle',component:LifecycleEvent},
{path:'signal',component:Signal},
{path:'photos',component:Photos},
{path:"events",component:Events},
{path:"**",component:NotFound}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
