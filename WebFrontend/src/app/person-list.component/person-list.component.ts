import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Person } from '../models/person.model';

@Component({
  selector: 'app-person-list',
  template: `
    <div class="box table-responsive">
      <table class="table table-striped table-sm">
        <tr *ngFor="let person of persons" (click)="select(person)" [class.selected]="selectedPerson === person">
          <td>{{person.lastname}}</td><td>{{person.firstname}}</td>
        </tr>
      </table>
    </div>
    `
})
export class PersonListComponent implements OnInit {
  @Input()
  persons: Person[];

  @Output()
  selected = new EventEmitter<Person>();

  selectedPerson: Person;

  ngOnInit(): void {}

  select(person: Person) {
    this.selectedPerson = person;
    this.selected.emit(person);
  }
}
