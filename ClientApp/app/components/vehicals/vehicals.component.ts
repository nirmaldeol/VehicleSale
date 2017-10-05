import { KeyValuePair, Vehical } from './../model/Vehical';
import { VehicalService } from './../services/vehical.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicals',
  templateUrl: './vehicals.component.html',
  styleUrls: ['./vehicals.component.css']
})
export class VehicalsComponent implements OnInit {

  allVehicals: Vehical[];
  vehicals: Vehical[];
  makes: KeyValuePair[];
  filter: any = {};

  constructor(private vehicalService: VehicalService) { }

  ngOnInit() {
    this.vehicalService.getMakes().subscribe(m => {
      this.makes = m;
    })
    this.vehicalService.getAllVehicals().subscribe(v => {
      this.vehicals = this.allVehicals = v;
    })

  }

  onFilterChange() {
    var vehicals = this.allVehicals;

    if (this.filter.makeId)
      vehicals = vehicals.filter(v => v.make.id == this.filter.makeId);

    this.vehicals = vehicals;
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }

}
