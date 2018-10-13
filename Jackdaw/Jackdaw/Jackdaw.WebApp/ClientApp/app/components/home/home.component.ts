import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    constructor(private router: Router) { }

    onRouteContest() {
        this.router.navigate(['/contest']);
    }

}
