import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-deletephone',
  templateUrl: './deletephone.component.html',
  styleUrls: ['./deletephone.component.css']
})
export class DeletephoneComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<DeletephoneComponent>) { }

  ngOnInit() {
  }

  cancel(): void {
    this.dialogRef.close(false);
  }

  confirm(): void {
    this.dialogRef.close(true);
  }

}
