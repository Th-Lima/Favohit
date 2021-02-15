import { PersistenceService } from './../../../../services/persistence.service';
import { UserService } from './../../../../services/user.service';
import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { FuseConfigService } from "@fuse/services/config.service";
import swal from "sweetalert2";

@Component({
    selector: "login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"],
    encapsulation: ViewEncapsulation.None,
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    constructor(
        private fuseConfigService: FuseConfigService,
        private formBuilder: FormBuilder,
        private service: UserService,
        private router: Router,
        private persistence: PersistenceService
    ) {
        this.fuseConfigService.config = {
            layout: {
                navbar: {
                    hidden: true,
                },
                toolbar: {
                    hidden: true,
                },
                footer: {
                    hidden: true,
                },
                sidepanel: {
                    hidden: true,
                },
            },
        };
    }

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            email: ["", [Validators.required, Validators.email]],
            password: ["", Validators.required],
        });
    }

    login(loginForm): void{
        if (loginForm.isValid === false){
            return;
        }
        let email = this.loginForm.get('email').value;
        let password = this.loginForm.get('password').value;

        this.service.authenticate({
            email, 
            password
        }).subscribe((data) =>{

            this.persistence.set('authenticate_user', data);
            this.router.navigate(['/']);
            this.showMenus();

        }, (error) => {
            if (error.status === 422){
                swal.fire('Ops', 'Email ou senha invalido', 'error');
            }
        });
    }

    showMenus(): void{
        this.fuseConfigService.config = {
            layout: {
                navbar:{
                    hidden: false,
                },
                toolbar:{
                    hidden: false,
                },
            },
        };
    }
}
