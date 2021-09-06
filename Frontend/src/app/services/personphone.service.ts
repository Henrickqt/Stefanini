import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { EditphoneComponent } from '../components/dialogs/editphone/editphone.component';
import { InsertphoneComponent } from '../components/dialogs/insertphone/insertphone.component';
import { DeletephoneComponent } from '../components/dialogs/deletephone/deletephone.component';
import { PersonPhone } from '../models/personphone.model';
import { PersonPhoneListResponse } from '../models/personPhoneListResponse.model';
import { PersonPhoneResponse } from '../models/personPhoneResponse.model';

@Injectable({
  providedIn: 'root'
})
export class PersonphoneService {

  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
  ) { }

  showSnackbarMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "center",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-success']
    });
  }

  private errorHandler(e: any): Observable<any> {
    this.showSnackbarMessage('An error occurred while performing this operation.', true);
    return EMPTY;
  }

  read(businessEntityID: number): Observable<PersonPhoneListResponse> {
    return this.http.get<PersonPhoneListResponse>(`/api/personphone/${businessEntityID}`)
      .pipe(map(object => object), 
      catchError(error => this.errorHandler(error))
    );
  }

  openEditPersonPhoneDialog(personPhone: PersonPhone): Observable<EditphoneComponent> {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = personPhone;
    return this.dialog.open(EditphoneComponent, dialogConfig).afterClosed();
  }

  update(oldPersonPhone: PersonPhone, personPhone: PersonPhone): Observable<PersonPhoneResponse> {
    return this.http.put<PersonPhoneResponse>(`/api/personphone` +
        `/person/${oldPersonPhone.businessEntityID}` +
        `/phonenumber/${oldPersonPhone.phoneNumber}` +
        `/phonenumbertype/${oldPersonPhone.phoneNumberTypeID}`, 
        personPhone
      )
      .pipe(map(object => object), 
      catchError(error => this.errorHandler(error))
    );
  }

  openInsertPersonPhoneDialog(personPhone: PersonPhone): Observable<InsertphoneComponent> {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = personPhone;
    return this.dialog.open(InsertphoneComponent, dialogConfig).afterClosed();
  }

  create(personPhone: PersonPhone): Observable<PersonPhoneResponse> {
    return this.http.post<PersonPhoneResponse>('/api/personphone', personPhone)
      .pipe(map(object => object), 
      catchError(error => this.errorHandler(error))
    );
  }

  openDeletePersonPhoneDialog(): Observable<DeletephoneComponent> {
    const dialogConfig = new MatDialogConfig();
    return this.dialog.open(DeletephoneComponent, dialogConfig).afterClosed();
  }

  delete(personPhone: PersonPhone): Observable<PersonPhoneResponse> {
    return this.http.delete<PersonPhoneResponse>(`/api/personphone` +
        `/person/${personPhone.businessEntityID}` +
        `/phonenumber/${personPhone.phoneNumber}` +
        `/phonenumbertype/${personPhone.phoneNumberTypeID}`
      )
      .pipe(map(object => object), 
      catchError(error => this.errorHandler(error))
    );
  }

}
