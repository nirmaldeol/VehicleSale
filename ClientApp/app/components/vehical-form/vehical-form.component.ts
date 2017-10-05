import * as _ from 'underscore'; 
import { Vehical, SaveVehical } from './../model/Vehical';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VehicalService } from './../services/vehical.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router , ParamMap} from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';


@Component({
    selector: 'app-vehical-form',
    templateUrl: './vehical-form.component.html',
    styleUrls: ['./vehical-form.component.css']
})
export class VehicalFormComponent implements OnInit {
  
  title: string = "New Vehicle";
  makes: any[]; 
    models: any[];
    features: any[];
    vehical: SaveVehical = {
      id: 0,
      makeId: 0,
      modelId: 0,
      isRegistered: false,
      features: [],
      contact: {
        name: '',
        email: '',
        phone: '',
      }
    };
  
    constructor(
      private route: ActivatedRoute,
      private router: Router,
      private VehicalService: VehicalService,
      private toastyService: ToastyService) {
   
        route.paramMap.subscribe((p:ParamMap) =>{
            var vid=  p.get('id');
            if(vid != null)
            this.vehical.id = +vid;  
        })
    
      }
  
    ngOnInit() {
      var sources = [
        this.VehicalService.getMakes(),
        this.VehicalService.getFeatures(),
      ];
  
      if (this.vehical.id){
        this.title = "Edit Vehicle";
        sources.push(this.VehicalService.getVehical(this.vehical.id));
      }
     
  
      Observable.forkJoin(sources).subscribe(data => {
        this.makes = data[0];
        this.features = data[1];
  
        if (this.vehical.id) {
          this.setvehical(data[2]);
          this.populateModels();
        }
      }, err => {
        if (err.status == 404)
        console.log(err)
          this.router.navigate(['/home']);
      });
    }
  
    private setvehical(v: Vehical) {
      this.vehical.id = v.id;
      this.vehical.makeId = v.make.id;
      this.vehical.modelId = v.model.id;
      this.vehical.isRegistered = v.isRegistered;
      this.vehical.contact = v.contact;
      this.vehical.features = _.pluck(v.features, 'id');
    } 
  
    onMakeChange() {
      this.populateModels();
      delete this.vehical.modelId;
    }
  
    private populateModels() {
      var selectedMake = this.makes.find(m => m.id == this.vehical.makeId);
      this.models = selectedMake ? selectedMake.models : [];
    }
  
    onFeatureToggle(featureId:number, $event:any) {
      if ($event.target.checked)
        this.vehical.features.push(featureId);
      else {
        var index = this.vehical.features.indexOf(featureId);
        this.vehical.features.splice(index, 1);
      }
    }
  
    submit() {
      if (this.vehical.id) {
        
        this.VehicalService.update(this.vehical)
          .subscribe(x => {
            this.toastyService.success({
              title: 'Success', 
              msg: 'The vehical was sucessfully updated.',
              theme: 'bootstrap',
              showClose: true,
              timeout: 5000
            });
          });
      }
      else {
         this.VehicalService.create(this.vehical)
          .subscribe(x => console.log(x));
  
      }
    }

    delete(){
      if("Are You Sure")
      this.VehicalService.delete(this.vehical.id).subscribe(r => {
           this.router.navigate(['/home']);
      })
    }
}