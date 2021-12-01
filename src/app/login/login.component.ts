import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../shared/user';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { Jwtresponse } from '../shared/jwtresponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //declare variables
  loginForm: FormGroup;
  isSubmitted = false;
  loginUser: User = new User;
  error = '';
  jwtResponse:any = new Jwtresponse();

  constructor(private formBuilder: FormBuilder,
    private router: Router, private authService: AuthService) { }

  ngOnInit(): void {

    //FormGroup
    this.loginForm = this.formBuilder.group(
      {
        UserName: ['', [Validators.required, Validators.minLength(2)]],
        UserPassword: ['', [Validators.required]]
      }
    );
  }
  get formControls() {
    return this.loginForm.controls;
  }
  //login verify
  loginCredentials() {


    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //invalid
    if (this.loginForm.invalid)
      return;

      
    //valid
    if (this.loginForm.valid) {
      //calling mathod from AuthService  --Authorization
      this.authService.loginVerify(this.loginForm.value)
        .subscribe(data => {
          console.log(data);

          //token with roleid and name
        this.jwtResponse=data;

        //store in local/session storage
        sessionStorage.setItem("jwtToken",this.jwtResponse.token);


         //Check the role--based on RoleId, it redirect the respective component
        if (this.jwtResponse.rId === 1) {
          //logged as admin
          console.log("ADMIN");
          //storing in localstorage/sessionstorage 
          localStorage.setItem("username", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.rId.toString());
          sessionStorage.setItem("username", this.jwtResponse.uName);
          this.router.navigateByUrl('/admin');
        }
        else if (this.jwtResponse.rId === 2) {
          //logged as Manager
          console.log("MANAGER");
          localStorage.setItem("username", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.rId.toString());
          sessionStorage.setItem("username", this.jwtResponse.uName);
          this.router.navigateByUrl('/manager');
        }
        else if (this.jwtResponse.rId === 3) {
          //logged as cordinator
          console.log("Cordinator");
          localStorage.setItem("username", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.rId.toString());
          sessionStorage.setItem("username", this.jwtResponse.uName);
          this.router.navigateByUrl('/cordinator');
        }
        else if (this.jwtResponse.rId === 4) {
          //logged as user
          console.log("USER");
          localStorage.setItem("username", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.rId.toString());
          sessionStorage.setItem("username", this.jwtResponse.uName);
          this.router.navigateByUrl('');
        }
          else {
            this.error = "sorry not allowed...Invalid authorization"
          }
        },
          errors => {
            this.error = "invalid username or password. try again"
          }
        );

    }
  }
   //lpgin verift test
   loginVerifyTest(){
    if(this.loginForm.valid){
      this.authService.getUserByPassword(this.loginForm.value).subscribe(
        (data)=>{
          console.log(data);
        },
        (error)=>{
          console.log(error);
        }
      )
    }
  }
}