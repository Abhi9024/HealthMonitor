import { Injectable, Inject } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { IUser } from "../interface/IUser";
import { IUserHealthTracker } from "../interface/IUserHealthTracker";

@Injectable()
export class HTService {
    //userHT: IUserHealthTracker[] = [{ bloodPressureRate: 1, bloodSugarRate: 2, creatineLevel: 3, heartBeatRate: 4, trackingDate:new Date() }];
    //user: IUser = { id: 1, age: 2, gender: 3, name: 'terst', userHealthTracker: this.userHT };
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    getUsers(): Observable<IUser[]> {
        return this.http.get(this.baseUrl + 'api/HealthTracker/Users')
            .map(res => {
                let users = res.json();
                return users;
            }).catch(this.handleError);
    };


    getUser(name: string): Observable<IUser> {
        console.log(this.baseUrl);
        return this.http.get(this.baseUrl + 'api/HealthTracker/User?name=' + name)
            .map((res:Response) => { return res.json(); });
    }

    authenticateUser(): Observable<any> {

        var body = { userName : "Abhi", password : "Welcome123$" };

        return this.http.post(this.baseUrl + "api/HealthTracker/Auth", body)
            .map((res) => { return res.json; }).catch(this.handleError);
    }


    handleError(err: any) {
        console.log('From service ' +err);
        return err;
    }
}