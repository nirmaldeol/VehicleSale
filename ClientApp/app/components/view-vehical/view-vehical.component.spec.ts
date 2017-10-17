import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewVehicalComponent } from './view-vehical.component';

describe('ViewVehicalComponent', () => {
  let component: ViewVehicalComponent;
  let fixture: ComponentFixture<ViewVehicalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewVehicalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewVehicalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
