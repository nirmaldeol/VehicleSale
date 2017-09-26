import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class VehicalService {

  constructor(private http: Http) {
    
         }
        
         getMakes(){
             return this.http.get("/api/makes")
                      .map(res=> res.json());
         }

         getFeatures(){
          return this.http.get(('/api/features'))
                          .map(res=> res.json());
        }
}
