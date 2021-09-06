import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { PersonPhone } from '../../../models/personphone.model';
import { PhonenumbertypeService } from '../../../services/phonenumbertype.service';
import { PhoneNumberType } from '../../../models/phonenumbertype.model';

@Component({
  selector: 'app-editphone',
  templateUrl: './editphone.component.html',
  styleUrls: ['./editphone.component.css']
})
export class EditphoneComponent implements OnInit {

  form: FormGroup = this.formBuilder.group({
    'phoneNumber': ['', Validators.required],
  });

  phoneNumberTypes: PhoneNumberType[];
  selected: number;

  constructor(
    private dialogRef: MatDialogRef<EditphoneComponent>,
    private formBuilder: FormBuilder,
    private phonenumbertypeService: PhonenumbertypeService,
    @Inject(MAT_DIALOG_DATA) public personPhone: PersonPhone
  ) { }

  ngOnInit(): void {
    this.phoneNumberTypes = this.phonenumbertypeService.phoneNumberTypes;
    this.selected = this.personPhone.phoneNumberTypeID;
    this.form.setValue({
      phoneNumber: this.personPhone.phoneNumber
    });
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
