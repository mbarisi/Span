import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { AppComponent } from './app.component';
import { DataTableComponent } from './data-table.component';
import { DataService } from './data.service';
import { Logger } from './logger.service';
import { MatTableModule } from '@angular/material/table';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    MatTableModule,
    HttpClientModule,
    MatButtonModule
  ],
  declarations: [
    AppComponent,
    DataTableComponent
  ],
  providers: [
    DataService,
    Logger
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
