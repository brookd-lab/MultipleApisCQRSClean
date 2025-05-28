import React from 'react';
import CardItem from './CardItem';

function CardGrid({ cards, onDelete }) {
  
  if (!cards || cards.length === 0) {
    return <div style={{ margin: '32px 0', textAlign: 'center', color: '#888' }}>No cards available.</div>;
  }
  
  return (
    <div style={{
      display: 'grid',
      gridTemplateColumns: 'repeat(auto-fit, minmax(260px, 1fr))',
      gap: 24,
      margin: '32px 0',
    }}>
      {cards.map(card => (
        <CardItem key={card.id} card={card} onDelete={onDelete} />
      ))}
    </div>
  );
}

export default CardGrid;
