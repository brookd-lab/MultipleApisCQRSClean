import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { EmployeeListComponent } from './app/employee-list/employee-list.component';

bootstrapApplication(EmployeeListComponent, appConfig)
  .catch((err) => console.error(err));
