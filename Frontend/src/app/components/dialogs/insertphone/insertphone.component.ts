import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { PersonPhone } from '../../../models/personphone.model';
import { PhonenumbertypeService } from '../../../services/phonenumbertype.service';
import { PhoneNumberType } from '../../../models/phonenumbertype.model';

@Component({
  selector: 'app-insertphone',
  templateUrl: './insertphone.component.html',
  styleUrls: ['./insertphone.component.css']
})
export class InsertphoneComponent implements OnInit {

  form: FormGroup = this.formBuilder.group({
    'phoneNumber': ['', Validators.required],
  });

  phoneNumberTypes: PhoneNumberType[];

  constructor(
    private dialogRef: MatDialogRef<InsertphoneComponent>,
    private formBuilder: FormBuilder,
    private phonenumbertypeService: PhonenumbertypeService,
    @Inject(MAT_DIALOG_DATA) public personPhone: PersonPhone
  ) { }

  ngOnInit(): void {
    this.phoneNumberTypes = this.phonenumbertypeService.phoneNumberTypes;
  }

  cancel(): void {
    this.dialogRef.close(false);
  }

  confirm(): void {
    this.personPhone.phoneNumber = this.form.get('phoneNumber').value;

    if (this.personPhone.phoneNumber.length != 0 && this.personPhone.phoneNumberTypeID !== 0) {
      this.dialogRef.close(true);
    }
  }

  selectOption(id: number): void {
    this.personPhone.phoneNumberTypeID = id;
  }
  
}
