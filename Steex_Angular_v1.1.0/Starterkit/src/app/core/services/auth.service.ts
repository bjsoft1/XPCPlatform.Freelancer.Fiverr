import { Injectable } from '@angular/core';
import { getFirebaseBackend } from '../../authUtils';
import { User } from '../models/auth.models';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { GlobalComponent } from "../../global-component";

const AUTH_API = GlobalComponent.AUTH_API;
const CLIENT_ID = GlobalComponent.CLIENT_ID;
const CLIENT_SECRET = GlobalComponent.CLIENT_SECRET;


const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
  };
  

@Injectable({ providedIn: 'root' })

/**
 * Auth-service Component
 */
export class AuthenticationService {

    user!: User;
    currentUserValue: any;

    private currentUserSubject: BehaviorSubject<User>;
    // public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')!));
        // this.currentUser = this.currentUserSubject.asObservable();
     }

    /**
     * Performs the register
     * @param email email
     * @param password password
     */
    // register(email: string, first_name: string, password: string) {        
    //     // return getFirebaseBackend()!.registerUser(email, password).then((response: any) => {
    //     //     const user = response;
    //     //     return user;
    //     // });

    //     // Register Api
    //     return this.http.post(AUTH_API + 'signup', {
    //         email,
    //         first_name,
    //         password,
    //       }, httpOptions);
    // }

    /**
     * Performs the auth
     * @param email email of user
     * @param password password of user
     */
    login(email: string, password: string) {
        // return getFirebaseBackend()!.loginUser(email, password).then((response: any) => {
        //     const user = response;
        //     return user;
        // });
        const body = new URLSearchParams();
        body.set('grant_type', 'password');
        body.set('client_id', CLIENT_ID);
        body.set('username', email);
        body.set('password', password);
        body.set('client_secret', CLIENT_SECRET);
        
        return this.http.post(AUTH_API + 'connect/token', body , httpOptions);
    }

    /**
     * Returns the current user
     */
    public currentUser(): any {
        return getFirebaseBackend()!.getAuthenticatedUser();
    }

    /**
     * Logout the user
     */
    logout() {
        // logout the user
        // return getFirebaseBackend()!.logout();
        localStorage.removeItem('currentUser');
        localStorage.removeItem('token');
        this.currentUserSubject.next(null!);
    }

    /**
     * Reset password
     * @param email email
     */
    resetPassword(email: string) {
        return getFirebaseBackend()!.forgetPassword(email).then((response: any) => {
            const message = response.data;
            return message;
        });
    }

}

