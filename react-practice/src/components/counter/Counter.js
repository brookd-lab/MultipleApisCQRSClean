import { useState } from 'react';

const Counter = ({amount}) => {
    const [number, setNumber] = useState(5);

    const inc = () => {
        setNumber(prevNumber => prevNumber + amount);
    }

    function dec(amount) {
        setNumber(prevNumber => prevNumber - amount);
    }

    return (
        <div className="container mt-5">
            <div className="mb-2">Number: {number}</div>
            <button className="btn btn-sm btn-primary me-2" onClick={() => inc()}>Inc</button>
            <button className="btn btn-sm btn-info" onClick={() => dec(3)}>Dec</button>
        </div>
    )
}

export default Counter;