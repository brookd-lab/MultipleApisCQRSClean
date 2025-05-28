import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get('http://localhost:3000/items');
  }

  addItem(data:any){
    return this.http.post('http://localhost:3000/items', data)
  }

  deleteItem(id:any){
    return this.http.delete('http://localhost:3000/items/'+id);
  }
}
