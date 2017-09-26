import { FormControl, FormGroup } from '@angular/forms';
import { VehicalService } from './../services/vehical.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehical-form',
  templateUrl: './vehical-form.component.html',
  styleUrls: ['./vehical-form.component.css']
})
export class VehicalFormComponent implements OnInit {

  features: any[];
  makes: any[];
  models: any[];
  vehical: any = {};

  constructor(
      private service: VehicalService) { }

  createForm = new FormGroup({
      makes: new FormControl(),
      models: new FormControl(),
      contactName: new FormControl(),
      contactPhone: new FormControl(),
      contactEmail: new FormControl(),

  })

  onMakeChange() {
      let selectedMake = this.makes.find(m => m.id == this.vehical.make);
      this.models = selectedMake ? selectedMake.models : [];
  }

  ngOnInit() {

      this.service.getFeatures().subscribe(features => {
          this.features = features;
          console.log(this.features);
      })

      this.service.getMakes().subscribe(make => {
          this.makes = make;
      })
  }
}
