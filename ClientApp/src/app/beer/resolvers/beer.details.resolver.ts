import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { BeerService } from '../services/beer.service';

@Injectable({
  providedIn: 'root'
})
export class BeerDetailsResolver implements Resolve<any> {

  constructor(private service: BeerService) { }
  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.service.getBeerById(route.params.id);
  }
}