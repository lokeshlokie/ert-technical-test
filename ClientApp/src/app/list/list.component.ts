import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Beer } from '../beer.model';
import { BrewDogBeerService } from '../brewDogBeers.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [BrewDogBeerService],
})
export class ListComponent implements AfterViewInit, OnInit {

  displayedColumns: string[] = ['name', 'tagline', 'firstbrewed', 'abv'];
  beers: Beer[] = [];
  dataSource = new MatTableDataSource<Beer>();

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private beerService: BrewDogBeerService) { }

  ngOnInit() {
    this.loadBeers();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  private loadBeers(searchByNameString?: string) {
    this.beerService.getBeers(searchByNameString).subscribe((data: Beer[]) => this.beers = data)
  }

  onSearch(searchString){
    this.loadBeers(searchString);
  }
}
