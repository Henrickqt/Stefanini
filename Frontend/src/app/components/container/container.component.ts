import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { Person } from '../../models/person.model';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {

  persons: Person[];
  
  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.personService.read().subscribe(response => {
      if (response.data.success) {
        this.persons = response.data.personObjects;
      } 
      else {
        this.personService.showSnackbarMessage(response.data.errors.join("\n"), true);
      }
    });
  }

}
