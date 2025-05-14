// src/app/Employee-list.component.ts
import { Component, OnInit } from '@angular/core';
import { EmployeeService, Employee } from '../employee.service';
import { FormsModule } from '@angular/forms';
import { NgIf, NgFor } from '@angular/common';

@Component({
  selector: 'app-employee-list',
  imports: [NgIf, NgFor, FormsModule],
  templateUrl: './employee-list.component.html',
})
export class EmployeeListComponent implements OnInit {
  newEmployee: Employee = { name: '', age: '' };
  editingEmployee: Employee | null = null;

  constructor(public employeeService: EmployeeService) { }

  async ngOnInit() {
    await this.employeeService.loadEmployees();
  }

  async addEmployee() {
    if (!this.newEmployee.name || !this.newEmployee.age) return;
    await this.employeeService.createEmployee(this.newEmployee);
    this.newEmployee = { name: '', age: '' };
  }

  startEdit(employee: Employee) {
    this.editingEmployee = { ...employee };
  }

  async saveEdit() {
    if (this.editingEmployee && this.editingEmployee.id) {
      await this.employeeService.updateEmployee(this.editingEmployee);
      this.editingEmployee = null;
    }
  }

  async deleteEmployee(id: number) {
    await this.employeeService.deleteEmployee(id);
  }

  cancelEdit() {
    this.editingEmployee = null;
  }
}
