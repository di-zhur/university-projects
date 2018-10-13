import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { ContestComponent } from './components/contest/contest.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CriterionComponent } from './components/fetchdata/criterion.component';
import { ParticipantComponent } from './components/fetchdata/participant.component';
import { RegistrationComponent } from './components/registration/registration.component';

@NgModule({
    declarations: [
        AppComponent,
        RegistrationComponent,
        ContestComponent,
        FetchDataComponent,
        CriterionComponent,
        ParticipantComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'registration', component: RegistrationComponent },
            { path: 'contest', component: ContestComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'criterion/:id', component: CriterionComponent },
            { path: 'participant/:id', component: ParticipantComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
