import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MaterialModule } from './shared/material.module';

import { ListComponent } from './list/list.component';

import { WelcomeComponent } from './welcome/welcome.component';
// import { DetailComponent } from './detail/detail.component';
// import { FavouritesComponent } from './favourites/favourites.component';

// TODO to implement routing 
// const appRoutes: Routes =[
//   { path: '', component: AppComponent},
//   { path: 'details', component: DetailComponent},
//   { path: 'favourite', component: FavouritesComponent }
// ];

@NgModule({
  imports: [
    BrowserModule,
    FormsModule, 
    HttpClientModule, 
    // TODO for routing implementation
    // RouterModule.forRoot(appRoutes)
  ],
  declarations: [AppComponent],
  bootstrap: [AppComponent]
})
export class AppModule {}
