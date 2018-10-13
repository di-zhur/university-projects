import { Component, OnInit } from '@angular/core';
import { DataService } from '../service/data.service';

@Component({
    selector: 'ed-faculty',
    templateUrl: './ed.faculty.component.html',
    providers: [DataService]
})

export class EdFacultyComponent implements OnInit {
    universitys: Array<{ id: string, name: string }> = [];
    specializations: Array<{ id: string, name: string }> = [];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getUniversitysWithObservable().subscribe(e => this.universitys = e);
        this.dataService.getSpecializationsWithObservable().subscribe(e => this.specializations = e);
    }
}