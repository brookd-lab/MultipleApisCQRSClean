import axios from 'axios';
const API = axios.create({ baseURL: 'http://localhost:3010' });

export const getCards = () => API.get('/cards');
export const addCard = (data) => API.post('/cards', data);
export const deleteCard = (id) => API.delete(`/cards/${id}`);
export const getCard = (id) => API.get(`/cards/${id}`);
