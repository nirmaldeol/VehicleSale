import { PaginationComponent } from './components/shared/pagination/pagination.component';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppErrorHandler } from './app.error-handler';
import { ErrorHandler } from '@angular/core';
import { ToastyService, ToastyModule } from 'ng2-toasty';
import { VehicalService } from './components/services/vehical.service';

import { VehicalFormComponent } from './components/vehical-form/vehical-form.component';
import { VehicalsComponent } from './components/vehicals/vehicals.component';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VehicalFormComponent,
        VehicalsComponent,
        PaginationComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'vehicals', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'vehicals', component: VehicalsComponent},               
            { path: 'vehical/new', component: VehicalFormComponent},   
            { path: 'vehical/:id', component: VehicalFormComponent},               
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[
        { provide:ErrorHandler, useClass:AppErrorHandler},
        VehicalService, ToastyService]
})
export class AppModuleShared {
}
