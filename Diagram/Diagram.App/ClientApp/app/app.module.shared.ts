import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Route } from '@angular/router';

import { AppComponent } from './components/app/app.component';

import { FindComponent } from './components/university/find.component';
import { UniversityComponent } from './components/university/university.component';
import { DescriptionComponent } from './components/university/description.component';
import { StatisticsComponent } from './components/university/statistics.component';

import { AnalyticsComponent } from './components/analytics/analytics.component';
import { AssessmentComponent } from './components/analytics/assessment.component';
import { ForecastComponent } from './components/analytics/forecast.component';
import { ClassificationComponent } from './components/analytics/classification.component';

import { RegistrationComponent } from './components/registration/registration.component';
import { EdFacultyComponent } from './components/registration/ed.faculty.component';
import { EdSetTotalComponent } from './components/registration/ed.settotal.component';
import { EdSpecialtyComponent } from './components/registration/ed.specialty.component';
import { EdUniversityComponent } from './components/registration/ed.university.component';

import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { UploadModule } from '@progress/kendo-angular-upload';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { PopupModule } from '@progress/kendo-angular-popup';
import { Observable } from 'rxjs/Observable';

import 'hammerjs';

const routes: Route[] = [
    { path: '', redirectTo: 'find', pathMatch: 'full' },
    { path: 'find', component: FindComponent },
    {
        path: 'university', component: UniversityComponent, children: [
            { path: '', component: DescriptionComponent },
            { path: 'description', component: DescriptionComponent },
            { path: 'statistics', component: StatisticsComponent }
        ]
    },
    {
        path: 'registration', component: RegistrationComponent, children: [
            { path: '', component: EdUniversityComponent },
            { path: 'ed-university', component: EdUniversityComponent },
            { path: 'ed-faculty', component: EdFacultyComponent },
            { path: 'ed-specialty', component: EdSpecialtyComponent },
            { path: 'ed-settotal', component: EdSetTotalComponent }
        ]
    },
    {
        path: 'analytics', component: AnalyticsComponent, children: [
            { path: '', component: ClassificationComponent },
            { path: 'analytics-classification', component: ClassificationComponent },
            { path: 'analytics-forecast', component: ForecastComponent },
            { path: 'analytics-assessment', component: AssessmentComponent }
        ]
    },
    { path: '**', redirectTo: 'find' }
]

@NgModule({
    declarations: [
        AppComponent,
        RegistrationComponent,
        EdFacultyComponent,
        EdSetTotalComponent,
        EdSpecialtyComponent,
        EdUniversityComponent,
        AnalyticsComponent,
        AssessmentComponent,
        ClassificationComponent,
        ForecastComponent,
        UniversityComponent,
        DescriptionComponent,
        StatisticsComponent,
        FindComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(routes),
        ButtonsModule,
        GridModule,
        DropDownsModule,
        InputsModule,
        LabelModule,
        UploadModule,
        ChartsModule,
        PopupModule
    ]
})

export class AppModuleShared {
}
