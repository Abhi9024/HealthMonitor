import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { HealthTrackerComponent } from "./components/healthTracker/healthTracker.component";
import { HTDashBoardComponent } from "./components/healthTracker-Dashboard/healthTrackerDashboard.component";
import { HTDeatialComponent } from "./components/healthTracker-Detail/healthTrackerDetail.component";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        HealthTrackerComponent,
        HTDashBoardComponent,
        HTDeatialComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'health', component: HealthTrackerComponent },
            { path: 'dashboard', component: HTDashBoardComponent, children: [{ path: ':name', component: HTDeatialComponent }] },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
