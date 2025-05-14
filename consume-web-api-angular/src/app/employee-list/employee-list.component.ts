// src/app/user-list.component.ts
import { Component, OnInit, signal } from '@angular/core';
import { EmployeeService, Employee } from '../employee.service';
import { FormsModule } from '@angular/forms';
import { NgIf, NgFor } from '@angular/common';

@Component({
    selector: 'app-employee-list',
    imports: [NgIf, NgFor, FormsModule],
    template: `
    <h2>Employee List</h2>
    <div *ngIf="employeeService.loading()">Loading...</div>
    <div *ngIf="employeeService.error()" style="color: red">{{ employeeService.error() }}</div>
    <ul>
      <li *ngFor="let employee of employeeService.employees()">
        <span *ngIf="!editingEmployee || editingEmployee.id !== employee.id">
          {{ employee.name }} ({{ employee.age }})
          <button (click)="startEdit(employee)">Edit</button>
          <button (click)="deleteEmployee(employee.id!)">Delete</button>
        </span>
        <span *ngIf="editingEmployee && editingEmployee.id === employee.id">
          <input [(ngModel)]="editingEmployee.name" placeholder="Name">
          <input [(ngModel)]="editingEmployee.age" placeholder="Age">
          <button (click)="saveEdit()">Save</button>
          <button (click)="cancelEdit()">Cancel</button>
        </span>
      </li>
    </ul>
    <h3>Add Employee</h3>
    <input [(ngModel)]="newEmployee.name" placeholder="Name">
    <input [(ngModel)]="newEmployee.age" placeholder="Age">
    <button (click)="addEmployee()">Add</button>
  `
})
export class EmployeeListComponent implements OnInit {
  newEmployee: Employee = { name: '', age: '' };
  editingEmployee: Employee | null = null;

  constructor(public employeeService: EmployeeService) {}

  ngOnInit() {
    this.employeeService.loadEmployees();
  }

  addEmployee() {
    if (!this.newEmployee.name || !this.newEmployee.age) return;
    this.employeeService.createEmployee(this.newEmployee);
    this.newEmployee = { name: '', age: '' };
  }

  startEdit(employee: Employee) {
    this.editingEmployee = { ...employee };
  }

  saveEdit() {
    if (this.editingEmployee && this.editingEmployee.id) {
      this.employeeService.updateEmployee(this.editingEmployee);
      this.editingEmployee = null;
    }
  }

  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(id);
  }

  cancelEdit() {
    this.editingEmployee = null;
  }
}
