import React, { useState, useEffect } from "react";
import axios from "axios";

const API_URL = "https://localhost:7083/employees"; // Change to your API endpoint

function UserCRUD() {
  const [users, setUsers] = useState([]);
  const [form, setForm] = useState({ name: "", age: "" });
  const [editingId, setEditingId] = useState(null);

  // Fetch users (Read)
  useEffect(() => {
    axios.get(API_URL)
      .then(res => setUsers(res.data))
      .catch(err => console.error(err));
  }, []);

  // Handle input changes
  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  // Create or Update user
  const handleSubmit = (e) => {
    e.preventDefault();
    if (editingId) {
      console.log(form)
      axios.put(`${API_URL}`, form)
        .then(res => {
          setUsers(users.map(u => u.id === editingId ? res.data : u));
          setEditingId(null);
          setForm({ name: "", age: "" });
        })
        .catch(err => console.error(err));
    } else {
      axios.post(API_URL, form)
        .then(res => {
          setUsers([...users, res.data]);
          setForm({ name: "", age: "" });
        })
        .catch(err => console.error(err));
    }
  };

  // Start editing
  const startEdit = (user) => {
    setEditingId(user.id);
    setForm({ name: user.name, age: user.age });
  };

  // Delete user
  const deleteUser = (id) => {
    axios.delete(`${API_URL}/${id}`)
      .then(() => setUsers(users.filter(u => u.id !== id)))
      .catch(err => console.error(err));
  };

  return (
    <div>
      <h2>User Management</h2>
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
      <ul>
        {users.map(u => (
          <li key={u.id}>
            {u.name} ({u.age} years)
            <button onClick={() => startEdit(u)}>Edit</button>
            <button onClick={() => deleteUser(u.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default UserCRUD;
