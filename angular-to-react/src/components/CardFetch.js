import React, { useState } from 'react';
import CardItem from './CardItem';

function CardFetch({ onFetchCard, fetchedCard, onDelete }) {
  const [input, setInput] = useState('');

  const handleFetch = () => {
    if (input) onFetchCard(input);
  };

  return (
    <div>
      <div style={{ display: 'flex', alignItems: 'center', marginBottom: 8 }}>
        <input
          type="text"
          placeholder="Enter Card ID"
          value={input}
          onChange={e => setInput(e.target.value)}
          style={{ marginRight: 10, padding: 8, borderRadius: 4, border: '1px solid #ccc', width: 120 }}
        />
        <button onClick={handleFetch} style={{
          background: '#1976d2',
          color: '#fff',
          border: 'none',
          borderRadius: 4,
          padding: '8px 16px',
          cursor: 'pointer',
          display: 'flex',
          alignItems: 'center'
        }}>
          <span style={{ marginRight: 8 }}>🔍</span>
          Get Card
        </button>
      </div>
      {fetchedCard && (
        <div style={{ marginTop: 8, display: 'inline-block' }}>
          <CardItem card={fetchedCard} onDelete={onDelete} />
        </div>
      )}
    </div>
  );
}

export default CardFetch;
