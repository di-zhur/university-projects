import { Component, OnInit } from '@angular/core';
import { DataService } from '../service/data.service';

@Component({
    selector: 'ed-university',
    templateUrl: './ed.university.component.html',
    providers: [DataService]
})
export class EdUniversityComponent implements OnInit {
    citys: Array<{ id: string, name: string }> = [];
    errorMessage: string;

    constructor(private dataService: DataService){}

    ngOnInit() {
        this.dataService.getCitysWithObservable().subscribe(citys => this.citys = citys);
    }
}