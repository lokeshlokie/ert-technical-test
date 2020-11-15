import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { ListComponent } from './list/list.component';
import { FavouritesComponent } from './favourites/favourites.component';
import { DetailComponent } from './detail/detail.component';


const routes: Routes = [
  { path: 'list', component: ListComponent },
  { path: 'favorate', component: FavouritesComponent },
  { path: 'details/:id', component: DetailComponent },
  { path: 'home', component: WelcomeComponent },
  { path: '', redirectTo: '/list', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }