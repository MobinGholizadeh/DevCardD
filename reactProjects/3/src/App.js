import React, { useState } from "react";
import { Icon } from "react-icons-kit";
import { eyeOff } from "react-icons-kit/feather/eyeOff";
import { eye } from "react-icons-kit/feather/eye";
import data from "./data";

function App() {
  const [count, setCount] = useState(0);
  const [text, setText] = useState([]);
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    let amount = parseInt(count);
    console.log(typeof amount);
    if (amount < 0 || amount > 4) {
      setError("Number must be between 0 and 4");
      setText([]);
    } else {
      setText(data.slice(0, amount));
      setError("");
    }
  };

  return (
    <div className="section-center">
      <form className="lorem" onSubmit={handleSubmit}>
        <label htmlFor="total"> Number of paragraphs : </label>
        <input
          type="number"
          name="total"
          value={count}
          onChange={(e) => setCount(e.target.value)}
        />
        <button type="submit"> Create </button>
        <h4>Just a Lorem</h4>
      </form>
      {error && <p>{error}</p>}
      <article className="lorem-text">
        {text.map((item, index) => {
          return <p key={index}>{item}</p>;
        })}
      </article>
    </div>
  );
}

export default App;
