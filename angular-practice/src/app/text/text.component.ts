import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-text',
  standalone: true,
  imports: [],
  templateUrl: './text.component.html',
  styleUrl: './text.component.css'
})
export class TextComponent {

  @Input() item: string = ""; // decorate the property with @Input()
  @Input() myString: string = "";
  @Output() messageEvent = new EventEmitter<string>();

  sendMessage() {
    this.messageEvent.emit('Hello from text component child!')
  }
}
