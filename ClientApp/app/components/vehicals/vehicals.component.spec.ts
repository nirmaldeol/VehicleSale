import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicalsComponent } from './vehicals.component';

describe('VehicalsComponent', () => {
  let component: VehicalsComponent;
  let fixture: ComponentFixture<VehicalsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicalsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
