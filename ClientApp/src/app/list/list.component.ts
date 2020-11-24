import { Component, OnInit } from '@angular/core';
import { Beer } from '../beer.model';
import { BeerService } from '../beer.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  page = 1;
  pageSize = 10;
  pageTitle = 'Beer List';
  collectionSize: number;
  beers: Beer[];
  filteredBeers: Beer[] = [];
  error: string;

  constructor(private beerService: BeerService) { }

  _filter = '';
  get listFilter(): string {
    return this._filter;
  }
  set listFilter(value: string) {
    this._filter = value;
    this.filteredBeers = this.listFilter ? this.filterBeers(this.listFilter) : this.beers;
  }


  ngOnInit() {
    this.getBeers(this.page);
  }

  getBeers(page: number) {
    return this.beerService.list().subscribe((beers) => {
      this.beers = this.filteredBeers.length !== 0 ? this.limitBeers(this.filteredBeers, page) : this.limitBeers(beers, page);
      this.collectionSize = beers.length;
      this.filteredBeers = this.beers;
    });
  }

  private limitBeers(beers: Beer[], page: number): Beer[] {
    return beers.slice((page - 1) * this.pageSize, (page - 1) * this.pageSize + this.pageSize);
  }

  filterBeers(filter: string): Beer[] {
    filter = filter.toLocaleLowerCase();
    return this.beers.filter((beer: Beer) => beer.name.toLocaleLowerCase().indexOf(filter) !== -1);
  }
}

