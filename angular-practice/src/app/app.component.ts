import { CountComponent } from './count/count.component';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TextComponent } from './text/text.component';
import { DisplayListComponent } from "./display-list/display-list.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CountComponent, DisplayListComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = "angular-practice";
  studentData: any[] = [];

  constructor() { }


}
