
import { IUserHealthTracker } from "./IUserHealthTracker";

export interface IUser {
    id: number,
    name: string,
    age: number,
    gender: number,
    userHealthTracker: IUserHealthTracker[]
}

