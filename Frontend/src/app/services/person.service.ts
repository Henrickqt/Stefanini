import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { PersonListResponse } from '../models/personListResponse.model';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

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

  read(): Observable<PersonListResponse> {
    return this.http.get<PersonListResponse>('/api/person')
      .pipe(map(object => object), 
      catchError(error => this.errorHandler(error))
    );
  }

}
