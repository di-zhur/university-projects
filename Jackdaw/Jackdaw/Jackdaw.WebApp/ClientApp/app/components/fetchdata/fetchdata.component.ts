import { Component, Inject, OnInit  } from '@angular/core';
import { Http } from '@angular/http';
import { RegistrationService } from '../service/http.service'
import { Router } from '@angular/router';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    providers: [RegistrationService]
})
export class FetchDataComponent implements OnInit {
    registeredParticipants: any;
    contests: any;
    registeredContestId: number;

    constructor(
        private service: RegistrationService,
        private router: Router,
        http: Http,
        @Inject('BASE_URL') baseUrl: string) {
    }

    ngOnInit() {
        this.service.getRegisteredParticipants().subscribe(data => this.registeredParticipants = data);
        this.service.getRegisteredContest().subscribe(o => this.contests = o);
    }

    onRouterCriterion(item: any) {
        var tets = item;
        this.router.navigate(['/criterion', item.id]);
    }

    onRouterParticipant(item : any) {
        var tets = item;
        this.router.navigate(['/participant', item.id]);
    }

    onCalculation() {
        this.service.postCalculationMarks(1).subscribe();
    }

    onDelete() {

    }
}
