import { Component, Inject, OnInit  } from '@angular/core';
import { Http } from '@angular/http';
import { RegistrationService} from '../service/http.service'
import { Router } from '@angular/router';

@Component({
    selector: 'criterion',
    templateUrl: './criterion.component.html',
    providers: [RegistrationService]
})
export class CriterionComponent implements OnInit {
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

    onBack() {
        this.router.navigate(['/featch-data']);
    }
}
