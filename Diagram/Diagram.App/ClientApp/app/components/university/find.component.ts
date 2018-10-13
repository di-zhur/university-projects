import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Http } from '@angular/http';
import { University, UniversityService } from './university.service';
import { DataService } from "../service/data.service";

@Component({
    selector: 'university-find',
    templateUrl: './find.component.html',
    providers: [UniversityService, DataService]
})

export class FindComponent implements OnInit {
    private universitys: Array<University> = [];
    private dropdownCitys: Array<{ id: string, name: string }> = [];
    private dropdownSpecializations: Array<{ id: string, name: string }> = [];
    private conditionDropdownUniversitys: boolean = false;
    private value: Array<{ id: string, name: string }> = [{ id: '0', name: 'Все'}];

    constructor(private dataService: DataService,
                private service: UniversityService,
                private router: Router,
                private http: Http,
                @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.dataService.getCitysWithObservable()
            .subscribe(citys => this.dropdownCitys = citys);

        this.dataService.getSpecializationsWithObservable()
            .subscribe(spec => this.dropdownSpecializations = spec);

        this.dataService.getUniversitysWithObservable()
            .subscribe(universitys => this.universitys = universitys as Array<University>);
    }

    selectedCity(city: any) {
        if (city.id == null) {
            this.conditionDropdownUniversitys = false;
            this.http.get(this.baseUrl + 'api/Diagram/GetUniveristy').subscribe(result => {
                this.universitys = result.json() as Array<University>;
            }, error => console.error(error));
        }
        else {
            this.conditionDropdownUniversitys = true;
        }
    }

    selectedUniversity(university: any) {
        if (university.id != null) {
            this.http.get(this.baseUrl + 'api/Diagram/GetUniveristyById/?id=' + university.id).subscribe(result => {
                this.universitys = result.json() as Array<University>;
            }, error => console.error(error));
        }
    }

    onFind(v: any) {
        
    }

    onLook(university: University) {
        this.service.setCurrentUniversity(university);
        this.router.navigate(['/university']);
    }
}

