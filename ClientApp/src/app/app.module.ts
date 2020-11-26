import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrewdogbeerlistComponent } from './Beer/brewdogbeer-list/brewdogbeerlist.component';
import { BrewdogserService } from './Beer/brewdogser.service';
import { HttpClientModule } from '@angular/common/http';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { NgxPaginationModule } from 'ngx-pagination';
import { BeerDetailsComponent } from './Beer/brewdogbeer-details/beer-details.component';


@NgModule({
  declarations: [
    AppComponent,
    BrewdogbeerlistComponent,
    BeerDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxPaginationModule,
    FormsModule
  ],
  providers: [BrewdogserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
