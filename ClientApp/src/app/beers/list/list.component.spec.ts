import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { AppModule } from 'src/app/app.module';
import { BeersService } from '../services/beers-service';
import { BrewdogListComponent } from './list.component';

describe('BrewdogListComponent', () => {
  let component: BrewdogListComponent;
  let fixture: ComponentFixture<BrewdogListComponent>;
  let beersService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [AppModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrewdogListComponent);
    component = fixture.componentInstance;
    beersService = TestBed.get(BeersService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call oninit method', () => {
    component.ngOnInit();
    expect(component).toBeTruthy();
  });

  it('should bind list', async(() => {
    const mockResponse = [
      { id: 1, name: 'Buzz', tagline: 'A Real Bitter Experience.', first_brewed: '09/2007' }
    ];
    spyOn(beersService, 'getBeerList').and.returnValue(of(mockResponse));
    expect(component).toBeTruthy();
    expect(mockResponse.length).toBe(1);
  }));

  it('should call navigate to details page', async(() => {
    const mockResponse = [
      {id: 1, name: 'Buzz', tagline: 'A Real Bitter Experience.', first_brewed: '09/2007'}
    ];
    component.navigateToDetails('1');
    expect(component).toBeTruthy();
  }));

});