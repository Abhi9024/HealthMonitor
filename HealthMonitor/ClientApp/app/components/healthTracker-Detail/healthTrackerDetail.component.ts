import { Component, OnInit } from "@angular/core";
import { HTService } from "../../services/healthTracker.service";
import { ActivatedRoute, Router } from "@angular/router";
import { IUser } from "../../interface/IUser";
import { IUserHealthTracker } from "../../interface/IUserHealthTracker";

@Component({
    selector: 'healthTracker-detail',
    templateUrl: './healthTrackerDetail.component.html',
    styleUrls: ['./healthTrackerDetail.component.css'],
    providers: [HTService]
})
export class HTDeatialComponent implements OnInit {
    name: string;
    user: IUser;
    userDeatails: IUserHealthTracker[];

    constructor(
        private htService: HTService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.route.params.subscribe(par => {
            this.name = par.name;
            this.htService.getUser(this.name)
                .subscribe(result =>
                { this.user = result; });
                //, err => console.log(err));
        });

        this.userDeatails = this.user.userHealthTracker;
    }

}