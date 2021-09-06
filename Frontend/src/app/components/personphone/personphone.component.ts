import { Component, Input, OnInit } from '@angular/core';

import { PersonphoneService } from '../../services/personphone.service';
import { PhonenumbertypeService } from '../../services/phonenumbertype.service';
import { PersonPhone } from '../../models/personphone.model';

@Component({
  selector: 'app-personphone',
  templateUrl: './personphone.component.html',
  styleUrls: ['./personphone.component.css']
})
export class PersonphoneComponent implements OnInit {

  @Input() personPhone: PersonPhone;

  phoneNumberType: string;

  constructor(
    private personphoneService: PersonphoneService,
    private phonenumbertypeService: PhonenumbertypeService
  ) { }

  ngOnInit(): void {
    this.phonenumbertypeService.read().subscribe(response => {
      if (response.data.success) {
        this.phonenumbertypeService.phoneNumberTypes = response.data.phoneNumberTypeObjects;
        this.phoneNumberType = this.phonenumbertypeService.phoneNumberTypes
          .find(x => x.phoneNumberTypeID == this.personPhone.phoneNumberTypeID).name;
      }
      else {
        this.phonenumbertypeService.showSnackbarMessage(response.data.errors.join("\n"), true);
      }
    });
  }

  private editPersonPhone(oldPersonPhone: PersonPhone): void {
    this.personphoneService.update(oldPersonPhone, this.personPhone).subscribe(response => {
      if (response.data.success) {
        this.personphoneService.showSnackbarMessage('Phone number modified successfully!');
        window.location.reload();
      } 
      else {
        this.personphoneService.showSnackbarMessage(response.data.errors.join("\n"), true);
      }
    });
  }

  edit(): void {
    const oldPersonPhone: PersonPhone = {
      businessEntityID: this.personPhone.businessEntityID,
      phoneNumber: this.personPhone.phoneNumber,
      phoneNumberTypeID: this.personPhone.phoneNumberTypeID
    };

    this.personphoneService.openEditPersonPhoneDialog(this.personPhone).subscribe(confirmation => {
      if (confirmation) {
        this.editPersonPhone(oldPersonPhone);
      }
    });
  }

  private deletePersonPhone(): void {
    this.personphoneService.delete(this.personPhone).subscribe(response => {
      if (response.data.success) {
        this.personphoneService.showSnackbarMessage('Phone number deleted successfully!');
        window.location.reload();
      } 
      else {
        this.personphoneService.showSnackbarMessage(response.data.errors.join("\n"), true);
      }
    });
  }

  delete(): void {
    this.personphoneService.openDeletePersonPhoneDialog().subscribe(confirmation => {
      if (confirmation) {
        this.deletePersonPhone();
      }
    });
  }
  
}
