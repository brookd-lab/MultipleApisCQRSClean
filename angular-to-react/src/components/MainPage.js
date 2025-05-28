import React, { useEffect, useState } from "react";
import CardGrid from "./CardGrid";
import CardForm from "./CardForm";
import CardFetch from "./CardFetch";
import { getCards, addCard, getCard, deleteCard } from "./api";
import CardItem from "./CardItem";
import TestMap from "./TestMap";
import axios from 'axios';

function MainPage() {
  const [cards, setCards] = useState([]);
  const [fetchedCard, setFetchedCard] = useState(null);
  const [snackbar, setSnackbar] = useState("");

  // useEffect(() => {
  //   getCards().then((data) => {
  //     console.log(data);
  //     setCards(data);
  //   });
  // }, []);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await getCards();
        console.log(response.data);
        setCards(response.data);
      } catch (err) {
        console.error("Error fetching cards:", err);
      } finally {
      }
    };

    fetchData();
  }, []);

  const handleAddCard = async (title, author) => {
    const newCard = await addCard(title, author);
    // Fallback to input if response is missing fields
    const cardData = {
      id: newCard?.data?.id || Date.now(),
      title: newCard?.data?.title || title,
      author: newCard?.data?.author || author,
    };
    setCards((prev) => [...prev, cardData]);
    setSnackbar("Card added successfully!");
    setTimeout(() => setSnackbar(""), 2000);
  };

  const handleFetchCard = async (id) => {
    try {
      const card = await getCard(id);
      if (card && card.data) {
        setFetchedCard(card.data);
      } else {
        setFetchedCard(null);
        setSnackbar("Card not found!");
        setTimeout(() => setSnackbar(""), 2000);
      }
    } catch (error) {
      setFetchedCard(null);
      setSnackbar("Card not found!");
      setTimeout(() => setSnackbar(""), 2000);
    }
  };

  const handleDeleteCard = async (id) => {
    await deleteCard(id);
    setCards((prev) => prev.filter((card) => card.id !== id));
    if (fetchedCard && fetchedCard.id === id) setFetchedCard(null);
    setSnackbar("Card deleted!");
    setTimeout(() => setSnackbar(""), 2000);
  };

  console.log('Cards to render:', cards);
  const validCards = cards.filter(card => card && card.id && card.title && card.author);

  return (
    // <div>
    //      {cards.map(card => (
    //     <CardItem key={card.id} card={card}  />
    //   ))}
    // </div>

    <div style={{ maxWidth: 900, margin: '0 auto', padding: 24 }}>
      <h1 style={{ textAlign: 'center', marginBottom: 24 }}>Card Manager</h1>
      <div style={{ marginLeft: 10 }}>
        <CardForm onAddCard={handleAddCard} />
      </div>
      <div style={{ marginLeft: 10 }}>
        <CardFetch onFetchCard={handleFetchCard} fetchedCard={fetchedCard} onDelete={handleDeleteCard} />
      </div>
      <CardGrid cards={validCards} onDelete={handleDeleteCard} />
      {snackbar && (
        <div style={{
          position: 'fixed',
          bottom: 32,
          left: '50%',
          transform: 'translateX(-50%)',
          background: '#323232',
          color: '#fff',
          padding: '12px 32px',
          borderRadius: 8,
          zIndex: 1000,
        }}>{snackbar}</div>
      )}
    </div>
  );
}

export default MainPage;
