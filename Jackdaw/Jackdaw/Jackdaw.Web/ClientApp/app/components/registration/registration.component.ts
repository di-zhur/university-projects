import { Component, OnInit } from '@angular/core';
import { RegistrationService, RegisteredParticipant } from '../service/http.service'

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    providers: [RegistrationService]
})

export class RegistrationComponent implements OnInit {
    participant: RegisteredParticipant = new RegisteredParticipant();
    institutions: any;
    contests: any;
    isNewParticipant: boolean = true;
    constructor(private service: RegistrationService) {}

    ngOnInit() {
        this.service.getInstitutions().subscribe(o => this.institutions = o);
        this.service.getRegisteredContest().subscribe(o => this.contests = o);
    }
    
    onSubmit() {
        this.service.postRegisteredParticipant(this.participant).subscribe();
        this.participant = new RegisteredParticipant();
    }
}

