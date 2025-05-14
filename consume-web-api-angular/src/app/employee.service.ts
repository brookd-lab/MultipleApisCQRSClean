// src/app/user.service.ts
import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';

export interface Employee {
  id?: number;
  name: string;
  age: string;
}

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private apiUrl = 'https://localhost:7083/employees';

  employees = signal<Employee[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);

  constructor(private http: HttpClient) {}

  async loadEmployees() {
    this.loading.set(true);
    this.error.set(null);
    try {
      const result = await firstValueFrom(this.http.get<Employee[]>(this.apiUrl));
      this.employees.set(result);
    } catch (err) {
      this.error.set('Failed to load employees');
    }
    this.loading.set(false);
  }

  async createEmployee(employee: Employee) {
    try {
      const created = await firstValueFrom(this.http.post<Employee>(this.apiUrl, employee));
      await this.loadEmployees();
    } catch {
      this.error.set('Failed to create user');
    }
  }

  async updateEmployee(employee: Employee) {
    try {
      const updated = await firstValueFrom(this.http.put<Employee>(`${this.apiUrl}`, employee));
      // this.employees.update(employees =>
      //   employees.map(u => (u.id === updated.id ? updated : u))
      // );
      await this.loadEmployees();
    } catch {
      this.error.set('Failed to update employee');
    }
  }

  async deleteEmployee(id: number) {
    try {
      await firstValueFrom(this.http.delete(`${this.apiUrl}/${id}`));
      this.employees.update(employes => employes.filter(u => u.id !== id));
    } catch {
      this.error.set('Failed to delete employee');
    }
  }
}
