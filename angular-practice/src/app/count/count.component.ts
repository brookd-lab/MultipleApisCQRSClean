import { Component, input, Input } from '@angular/core';
import { TextComponent } from '../text/text.component';

@Component({
  selector: 'app-count',
  standalone: true,
  imports: [TextComponent],
  templateUrl: './count.component.html',
  styleUrl: './count.component.css'
})
export class CountComponent {
  @Input() amount = 0;
  number = 10;
  message: any;

  receiveMessage($event: string) {
    this.message = $event;
  }

  inc() {
    this.number += this.amount;
  }

  dec(amount: number) {
    this.number -= amount;
  }
}
