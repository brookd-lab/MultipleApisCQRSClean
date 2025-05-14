import React, { useState, useEffect } from "react";
import axios from "axios";

const API_URL = "https://localhost:7083/employees"; // Change to your API endpoint

function EmployeeCRUD() {
  const [Employees, setEmployees] = useState([]);
  const [form, setForm] = useState({ name: "", age: "" });
  const [editingId, setEditingId] = useState(null);

 // Fetch Employees (Read)
  useEffect(() => {
    const fetchEmployees = async () => {
      try {
        const res = await axios.get(API_URL);
        setEmployees(res.data);
      } catch (err) {
        console.error(err);
      }
    };
    fetchEmployees();
  }, [Employees]);

  // Handle input changes
  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  // Create or Update Employee
  const handleSubmit = async (e) => {
    e.preventDefault();
    if (editingId) {
      // Update
      const updatedForm = { ...form, id: editingId };
      await axios.put(`${API_URL}`, updatedForm)
        .then(res => {
          setEditingId(null);
          setForm({ name: "", age: "" });       
        })
        .catch(err => console.error(err));
    } else {
      // Create
      await axios.post(API_URL, form)
        .then(res => {
          setEmployees([...Employees, res.data]);
          setForm({ name: "", age: "" });         
        })
        .catch(err => console.error(err));
    }
  };

  // Start editing
  const startEdit = (Employee) => {
    setEditingId(Employee.id);
    setForm({ name: Employee.name, age: Employee.age });
  };

  // Delete Employee
  const deleteEmployee = async (id) => {
    await axios.delete(`${API_URL}/${id}`)
      .then(() => setEmployees(Employees.filter(u => u.id !== id)))
      .catch(err => console.error(err));
  };

  return (
    <div>
      <h2>Employee Management</h2>
      <form onSubmit={handleSubmit}>
        <input
          name="name"
          placeholder="Name"
          value={form.name}
          onChange={handleChange}
          required
        />
        <input
          name="age"
          type="number"
          placeholder="Age"
          value={form.age}
          onChange={handleChange}
          required
        />
        <button type="submit">{editingId ? "Update" : "Add"}</button>
      </form>
        <p></p>
        {Employees.map(u => (
          <div key={u.id}>
            {u.name} ({u.age} years)
            <button onClick={() => startEdit(u)}>Edit</button>
            <button onClick={() => deleteEmployee(u.id)}>Delete</button>
          </div>
        ))}
    </div>
  );
}

export default EmployeeCRUD;
