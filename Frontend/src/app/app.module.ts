import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { AppComponent } from './app.component';
import { ContainerComponent } from './components/container/container.component';
import { PersonComponent } from './components/person/person.component';
import { PersonphoneComponent } from './components/personphone/personphone.component';
import { EditphoneComponent } from './components/dialogs/editphone/editphone.component';
import { InsertphoneComponent } from './components/dialogs/insertphone/insertphone.component';
import { DeletephoneComponent } from './components/dialogs/deletephone/deletephone.component';
import { HomeComponent } from './components/pages/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    PersonComponent,
    PersonphoneComponent,
    InsertphoneComponent,
    DeletephoneComponent,
    EditphoneComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule, 
    MatExpansionModule,
    MatButtonModule,
    MatDialogModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatSnackBarModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    EditphoneComponent,
    InsertphoneComponent,
    DeletephoneComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
