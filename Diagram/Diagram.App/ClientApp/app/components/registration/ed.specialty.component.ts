import { Component, OnInit } from '@angular/core';
import { DataService } from '../service/data.service';

@Component({
    selector: 'ed-specialty',
    templateUrl: './ed.specialty.component.html',
    providers: [DataService]
})
export class EdSpecialtyComponent implements OnInit {
    facultys: Array<{ id: string, name: string }> = [];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getFacultysWithObservable().subscribe(e => this.facultys = e);
    }
}