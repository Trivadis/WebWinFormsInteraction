import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PersonListComponent } from './person-list.component/person-list.component';
import { PersonComponent } from './person.component/person.component';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [AppComponent, PersonListComponent, PersonComponent],
  imports: [BrowserModule, HttpModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
