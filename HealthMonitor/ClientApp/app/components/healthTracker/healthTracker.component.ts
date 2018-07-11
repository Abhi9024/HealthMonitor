import { Component } from "@angular/core";
import { HTService } from "../../services/healthTracker.service";
import { IUser } from "../../interface/IUser";
import { Router } from "@angular/router";

@Component({
    selector: 'health',
    templateUrl: './healthTracker.component.html',
    styleUrls: ['./healthTracker.component.css'],
    providers: [HTService]
})
export class HealthTrackerComponent {
    users: IUser[];

    constructor(private htService: HTService,private router:Router) { }

    ngOnInit() {
        this.getUsers();
    }

    getUsers() {
        this.htService.getUsers()
            .subscribe(result => { this.users = result; console.log(result); }, err => console.log(err));
    }

    authenticate() {
        this.htService.authenticateUser()
            .subscribe(result => { console.log(result); }, err => console.log(err));
    }

    navToDashBoard(user: IUser) {
        this.router.navigate(['/dashboard', user.name]);
    }
}