import React, { useEffect, useState } from "react";

const FetchList = () => {
  const [data, setData] = useState(null);

  const Display = () => {
    return (
      <div>
        <h1>{data.title}</h1>
        <p>{data.description}</p>
        {data.items.map((item) => (
          <div key={item.id}>
            Name: {item.name} and age: {item.age}
          </div>
        ))}
      </div>
    );
  };

  useEffect(() => {
    fetch("/data.json")
      .then((response) => response.json())
      .then((data) => setData(data))
      .catch((error) => console.error("Error fetching data:", error));
  }, []);

  if (!data) {
    return <div>Loading...</div>;
  }

  return (
    <Display />
  );
};

export default FetchList;
