import { useState } from 'react';

const TestMap = () => {
 const [items, setItems] = useState([
   { id: 1, name: 'Item 1' },
   { id: 2, name: 'Item 2' },
   { id: 3, name: 'Item 3' }
 ]);

 return (
    <div>
        <h1>Test Map Component</h1>
        <ul>
            {items.map(item => (
            <li key={item.id}>
                {item.name}
            </li>
            ))}
        </ul>
        <button onClick={() => setItems([...items, { id: items.length + 1, name: `Item ${items.length + 1}` }])}>
            Add Item
        </button>
    </div>
 )
    
}

export default TestMap;