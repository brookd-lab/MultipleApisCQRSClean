const DisplayList = () => {
  const names = ["joe", "mike", "sam"];
  const data = [
    { id: 1, name: "Alice", age: 30 },
    { id: 2, name: "Bob", age: 25 },
    { id: 3, name: "Charlie", age: 35 },
  ];

  function ObjectList() {
    return (
      <div>
        {data.map((item) => (
          <div key={item.id}>
            {Object.entries(item).map(([key, value]) => (
              <div key={key}>
                {key}: {value}
              </div>
            ))}
            <br />
          </div>
        ))}
      </div>
    );
  }

  return (
    <div className="mt-5">
      <h3>Display List</h3>
      <ObjectList />
      <p></p>
      {names.map((name, index) => (
        <div key={index}>{name}</div>
      ))}
    </div>
  );
};

export default DisplayList;
