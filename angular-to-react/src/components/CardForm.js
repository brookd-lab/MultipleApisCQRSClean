import React, { useState } from 'react';

function CardForm({ onAddCard }) {
  const [title, setTitle] = useState('');
  const [author, setAuthor] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (title && author) {
      onAddCard(title, author);
      setTitle('');
      setAuthor('');
    }
  };

  return (
    <form onSubmit={handleSubmit} style={{ display: 'flex', alignItems: 'center', gap: 10 }}>
      <input
        type="text"
        placeholder="Title"
        value={title}
        required
        onChange={e => setTitle(e.target.value)}
        style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', marginRight: 5 }}
      />
      <input
        type="text"
        placeholder="Author"
        value={author}
        required
        onChange={e => setAuthor(e.target.value)}
        style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', marginRight: 10 }}
      />
      <button type="submit" style={{
        background: '#1976d2',
        color: '#fff',
        border: 'none',
        borderRadius: 4,
        padding: '8px 16px',
        cursor: 'pointer',
        display: 'flex',
        alignItems: 'center'
      }}>
        <span style={{ marginRight: 8 }}>➕</span>
        Add Card
      </button>
    </form>
  );
}

export default CardForm;
