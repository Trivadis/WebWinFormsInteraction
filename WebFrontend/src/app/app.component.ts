import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Person } from './models/person.model';
import { PersonService } from './services/person.service';
import { HubService } from './services/hub.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  loggedIn = false;

  constructor(
    private personService: PersonService,
    private hubService: HubService,
    private cdr: ChangeDetectorRef
  ) {}

  animate = false;
  persons: Person[];
  selectedPerson: Person;

  ngOnInit(): void {
    this.hubService.connect(action => this.onActionRequested(action));
    this.loadPersons();
  }

  onActionRequested(action: any) {
    switch (action.Name) {
      case 'login':
        if (!this.loggedIn) {
          this.loggedIn = true;
          this.loadPersons();
        }
        break;

      case 'logout':
        this.loggedIn = false;

        break;

      case 'changePerson':
        this.selectedPerson = this.persons.find(p => p.id.toString() === action.Arguments);
        break;

      case 'dataChanged':
        this.loadPersons(this.selectedPerson ? this.selectedPerson.id : null);
        break;

      default:
        break;
    }
    this.cdr.detectChanges();
    console.log('>>> onActionRequested', action);
  }

  onSelected(person) {
    this.selectedPerson = person;
    this.cdr.detectChanges();
    if (person) {
      this.hubService.dispatchAction({
        name: 'changePerson',
        arguments: person.id
      });
    }
    this.animate = true;
  }

  onEdit(person) {
    // Edit Person is a feature, which is not yet implemented in the new app.
    // -> request the editPerson action from the old app using the signalR hub.
    this.hubService.dispatchAction({ name: 'editPerson', arguments: person.id });
  }

  private loadPersons(selectedId?: number) {
    this.personService.getPersons().subscribe(persons => {
      this.persons = persons;
      if (selectedId) {
        this.onSelected(this.persons.find(p => p.id === selectedId));
      } else {
        this.selectedPerson = null;
      }
      this.cdr.detectChanges();
    });
  }
}
