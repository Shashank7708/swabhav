import { Routes } from '@angular/router';
import { Search } from './pages/search/search';
import { Booking } from './pages/booking/booking';

export const routes: Routes = [

    {path:'',redirectTo:'search',pathMatch:"full"},
    {path:'search',component:Search},
    {path:"booking",component:Booking}
];
