import { Inject, NgZone } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import { ErrorHandler } from "@angular/core";



export class AppErrorHandler implements ErrorHandler {
    constructor(
        @Inject(ToastyService) private toastyService:ToastyService,
        @Inject(NgZone) private zone: NgZone
    ) {
        
    }
    handleError(error: any): void {
      this.zone.run(()=>{
          if(typeof(window) !== 'undefined')
            this.toastyService.error({
            title:'Error',
            msg:"An Unexpected Error happened",
            theme:'bootstrap',
            showClose:true,
            timeout:5000,
            
        });
      })

       
     
    }


}