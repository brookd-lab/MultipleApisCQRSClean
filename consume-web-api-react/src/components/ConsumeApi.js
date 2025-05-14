import React, { useState, useEffect } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";

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
      await axios
        .put(`${API_URL}`, updatedForm)
        .then((res) => {
          setEditingId(null);
          setForm({ name: "", age: "" });
        })
        .catch((err) => console.error(err));
    } else {
      // Create
      await axios
        .post(API_URL, form)
        .then((res) => {
          setEmployees([...Employees, res.data]);
          setForm({ name: "", age: "" });
        })
        .catch((err) => console.error(err));
    }
  };

  // Start editing
  const startEdit = (Employee) => {
    setEditingId(Employee.id);
    setForm({ name: Employee.name, age: Employee.age });
  };

  // Delete Employee
  const deleteEmployee = async (id) => {
    await axios
      .delete(`${API_URL}/${id}`)
      .then(() => setEmployees(Employees.filter((u) => u.id !== id)))
      .catch((err) => console.error(err));
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Employee Management</h2>
      <form className="row g-3 mb-4" onSubmit={handleSubmit}>
        <div className="col-md-5">
          <input
            name="name"
            className="form-control"
            placeholder="Name"
            value={form.name}
            onChange={handleChange}
            required
          />
        </div>
        <div className="col-md-3">
          <input
            name="age"
            type="number"
            className="form-control"
            placeholder="Age"
            value={form.age}
            onChange={handleChange}
            required
          />
        </div>
        <div className="col-md-2">
          <Button type="submit" variant={editingId ? "warning" : "primary"} className="w-100">
            {editingId ? "Update" : "Add"}
          </Button>
        </div>
        {editingId && (
          <div className="col-md-2">
            <Button variant="secondary" className="w-100" onClick={() => {
              setEditingId(null);
              setForm({ name: "", age: "" });
            }}>
              Cancel
            </Button>
          </div>
        )}
      </form>
      <table className="table table-striped">
        <thead className="table-dark">
          <tr>
            <th>Name</th>
            <th>Age</th>
            <th style={{width: "180px"}}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {Employees.map(u => (
            <tr key={u.id}>
              <td>{u.name}</td>
              <td>{u.age}</td>
              <td>
                <Button
                  variant="info"
                  size="sm"
                  className="me-2"
                  onClick={() => startEdit(u)}
                >
                  Edit
                </Button>
                <Button
                  variant="danger"
                  size="sm"
                  onClick={() => deleteEmployee(u.id)}
                >
                  Delete
                </Button>
              </td>
            </tr>
          ))}
          {Employees.length === 0 && (
            <tr>
              <td colSpan="3" className="text-center text-muted">No Employees found.</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}


export default EmployeeCRUD;
