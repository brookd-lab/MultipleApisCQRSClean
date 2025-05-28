import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ItemService } from '../services/item-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-display-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './display-list.component.html',
  styleUrl: './display-list.component.css'
})
export class DisplayListComponent implements OnInit {

  constructor(private itemService: ItemService) { }

  names: string[] = ["joe", "mike", "fred", "sam"];
  items: any = [];
  name: string="";
  age: any;


  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.itemService.getItems().subscribe((res: any) => {
      this.items = res;
    })
  }

  deleteItem(id:any) {
    this.itemService.deleteItem(id).subscribe(res => {
      if (res) {
        this.getItems();
      } else {
      }
    })
  }

  addItem() {
    //if no card is there in the array then assign 1 to the id
    var id = (this.items.length) ? this.items[this.items.length - 1].id + 1 : 1;
    var data = {
      id: id,
      name: this.name,
      age: this.age,
    }
    this.itemService.addItem(data).subscribe(res => {
      if (res) {
        this.getItems();
      } else {
      }
    })
  }

  // items = [
  //   { id: 1, name: 'Johnny Whiting', age: 35 },
  //   { id: 2, name: 'Samson Johnson', age: 25 },
  //   { id: 3, name: 'Mikey Blackwell', age: 45 }
  // ];
}


