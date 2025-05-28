import React from 'react';

function CardItem({ card, onDelete }) {
  if (!card) return null;
  return (
    <div style={{
      background: '#fff',
      borderRadius: 12,
      boxShadow: '0 2px 8px rgba(0,0,0,0.07)',
      padding: 16,
      margin: 'auto',
      maxWidth: 260,
      minHeight: 140,
      display: 'flex',
      flexDirection: 'column',
      justifyContent: 'space-between'
    }}>
      <div>
        <div style={{ fontSize: '1.1rem', fontWeight: 600, color: '#1976d2' }}>Card #{card.id}</div>
        <div style={{ color: '#757575', fontSize: 14 }}>{card.author}</div>
        <div style={{ fontSize: '1rem', marginTop: 8 }}>{card.title}</div>
      </div>
      <div style={{ textAlign: 'right', marginTop: 8 }}>
        <button onClick={() => onDelete(card.id)} style={{
          background: 'none',
          border: 'none',
          color: '#d32f2f',
          cursor: 'pointer',
          fontSize: 20
        }} title="Delete card">🗑️</button>
      </div>
    </div>
  );
}

export default CardItem;
