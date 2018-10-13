import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { RegistrationService } from '../service/http.service'

@Component({
    selector: 'contest',
    templateUrl: './contest.component.html',
    providers: [RegistrationService]
})

export class ContestComponent implements OnInit {
    registeredParticipants: any;
    contests: any;
    registeredContestId: number;

    constructor(private service: RegistrationService, http: Http, @Inject('BASE_URL') baseUrl: string) {
    }

    ngOnInit() {
        this.service.getRegisteredParticipants().subscribe(data => this.registeredParticipants = data);
        this.service.getRegisteredContest().subscribe(o => this.contests = o);
    }
}


