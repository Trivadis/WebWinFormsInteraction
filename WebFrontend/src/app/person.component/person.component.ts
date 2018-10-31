import { Component, Output, EventEmitter, Input } from '@angular/core';
import { Person } from '../models/person.model';

@Component({
  selector: 'app-person',
  template: `
  <div *ngIf="person" [class.change]="change" class="box">
    <div class="person-name">{{person.firstname}} {{person.lastname}}</div>
    <button (click)="onEdit()" class="btn  btn-outline-secondary">Edit</button>
  </div>
    `
})
export class PersonComponent {
  @Input()
  person: Person;

  @Output()
  edit = new EventEmitter<Person>();

  change = false;
  onEdit() {
    this.edit.emit(this.person);
    this.change = true;
  }
}
