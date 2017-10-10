import { Vehical, SaveVehical } from './../model/Vehical';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';



@Injectable()
export class VehicalService {

  private readonly VehicleEndpoint = '/api/vehicals';
  constructor(private http: Http) {

  }


  getFeatures() {
    return this.http.get('/api/features')
      .map(res => res.json());
  }

  getMakes() {
    return this.http.get('/api/makes')
      .map(res => res.json());
  }
  getAllVehicals(filter:any) {
    var queryPrams = this.createQueryString(filter);
    return this.http.get(this.VehicleEndpoint +'?'+queryPrams)
      .map(res => res.json());
  }
  createQueryString(obj:any){
    var parts=[];
    for(var prop in obj){
      var value = obj[prop];
      if(value!=null && value != undefined )
      parts.push( encodeURIComponent(prop)+'='+ encodeURIComponent(value));
    }
    return parts.join('&');

  }


  create(vehical: SaveVehical) {
    return this.http.post(this.VehicleEndpoint, vehical)
      .map(res => res.json());
  }

  getVehical(id: number) {
    return this.http.get(this.VehicleEndpoint + '/' + id)
      .map(res => res.json());
  }

  update(vehical: SaveVehical) {
    return this.http.put(this.VehicleEndpoint + '/' + vehical.id, vehical)
      .map(res => res.json());
  }
  delete(id: Number) {
    return this.http.delete(this.VehicleEndpoint + '/' + id)
      .map(res => res.json());
  }


}
