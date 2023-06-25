import { Component, Input, OnInit } from '@angular/core';
import { UserCredentials } from "@modules-pages/account/account-content/personal-information/personal-information.component";
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'personal-credentials-block',
  templateUrl: './credentials.block.html',
  styleUrls: ['../personal-information.component.scss']
})
export class CredentialsBlock implements OnInit {
  @Input("userCredentials") userCredentials!: UserCredentials;

  isShowErrors: boolean = false;
  credentialsFormGroup: FormGroup = new FormGroup({
    isEdit: new FormControl(false),
    email: new FormControl('', [Validators.required, Validators.email])
  });

  ngOnInit(): void {
    this.credentialsFormGroup.controls['email'].setValue(this.userCredentials.email);
  }
}
