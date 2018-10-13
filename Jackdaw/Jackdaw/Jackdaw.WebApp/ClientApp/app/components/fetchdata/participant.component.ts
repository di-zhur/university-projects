import { Component, Inject, OnInit  } from '@angular/core';
import { Http } from '@angular/http';
import { RegistrationService} from '../service/http.service'
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'participant',
    templateUrl: './participant.component.html',
    providers: [RegistrationService]
})
export class ParticipantComponent implements OnInit {
    currentParticipant: any;

    constructor(
        private service: RegistrationService,
        private router: Router,
        private route: ActivatedRoute,
        http: Http,
        @Inject('BASE_URL') baseUrl: string) {
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            let id = params['id'];
            this.service.getRegisteredParticipant(id)
                .subscribe(o => this.currentParticipant = o[0]);
        });
    }

    onBack() {
        this.router.navigate(['/featch-data']);
    }
}
