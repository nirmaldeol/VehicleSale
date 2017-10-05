import {  Vehical,SaveVehical } from './../model/Vehical';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';



@Injectable()
export class VehicalService {

  constructor(private http: Http) {
    
         }
        
         getAllVehicals(){
           return this.http.get('/api/vehicals')
                       .map(res=> res.json());
         }
         getFeatures() {
          return this.http.get('/api/features')
            .map(res => res.json());
        }
      
        getMakes() {
          return this.http.get('/api/makes')
            .map(res => res.json());
        }
      
        create(vehical:SaveVehical) {
          return this.http.post('/api/vehicals', vehical)
            .map(res => res.json());
        }
      
        getVehical(id:number) {
          return this.http.get('/api/vehicals/' + id)
            .map(res => res.json());
        }
      
        update(vehical:SaveVehical) {
          return this.http.put('/api/vehicals/' + vehical.id, vehical)
            .map(res => res.json());
        }
        delete(id:Number) {
          return this.http.delete('/api/vehicals/' + id)
            .map(res => res.json());
        }

        
      }
