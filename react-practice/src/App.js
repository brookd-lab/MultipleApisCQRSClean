import './App.css';
import Counter from './components/counter/Counter';
import DisplayList from './components/display-list/DisplayList';
import FetchList from './components/fetch-list/FetchList';

function App() {
  return (
    <div className="App">
      <Counter amount={10} />
      <DisplayList />
      <FetchList />
    </div>
  );
}

export default App;
