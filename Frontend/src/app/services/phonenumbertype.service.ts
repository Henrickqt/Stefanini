import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { PhoneNumberTypeListResponse } from '../models/phoneNumberTypeListResponse.model';
import { PhoneNumberType } from '../models/phonenumbertype.model';

@Injectable({
  providedIn: 'root'
})
export class PhonenumbertypeService {

  phoneNumberTypes: PhoneNumberType[];

  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar,
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

  read(): Observable<PhoneNumberTypeListResponse> {
    return this.http.get<PhoneNumberTypeListResponse>('/api/phonenumbertype')
      .pipe(map(object => object), 
      catchError(error => this.errorHandler(error))
    );
  }

}
