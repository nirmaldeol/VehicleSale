import { KeyValuePair, Vehical } from './../model/Vehical';
import { VehicalService } from './../services/vehical.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicals',
  templateUrl: './vehicals.component.html',
  styleUrls: ['./vehicals.component.css']
})
export class VehicalsComponent implements OnInit {

  public readonly PAGE_SIZE = 3;

  queryResult: any = {};
  makes: KeyValuePair[];
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Id' },
    { title: 'Make', key: 'make', isSortbale: true },
    { title: 'Model', key: 'model', isSortbale: true },
    { title: 'Contact Name', key: 'contactName', isSortbale: true },
    {}
  ]



  constructor(private vehicalService: VehicalService) { }

  ngOnInit() {
    this.vehicalService.getMakes().subscribe(m => {
      this.makes = m;
    })
    this.populateVehicals();

  }

  populateVehicals() {
    this.vehicalService.getAllVehicals(this.query).subscribe(result => {
      this.queryResult = result;
    })
  }

  onFilterChange() {
    this.query.page = 1;
    console.log(this.query)
    this.populateVehicals();

  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateVehicals();
  }
  sortBy(columnName: any) {
    if (this.query.sortBy === columnName) {
      this.query.IsSortAscending = !this.query.IsSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.IsSortAscending = true;
    }
    this.populateVehicals();
  }
  onPageChanged(page: any) {
    this.query.page = page;
    this.populateVehicals();
  }

}
