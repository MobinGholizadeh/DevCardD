import React, { useState } from "react";
import { AiOutlineMinus, AiOutlinePlus } from "react-icons/ai";

const Question = ({ title, info }) => {
  const [showInfo, setShowInfo] = useState(false);

  return (
    <div className="question">
      <header style={{ display: "flex" }}>
        <div>
          <h4>{title}</h4>
        </div>
        <div style={{ height: "100%" }}>
          {/* whenever you want to use setState inside js codes , you should write an empty Function before using it so your browser doesn`t set it again and again again! if you don`t , you gonna fall into a problem */}
          <button onClick={() => setShowInfo(!showInfo)}>
            {showInfo ? <AiOutlineMinus /> : <AiOutlinePlus />}
          </button>
        </div>
      </header>
      {showInfo && <p>{info}</p>}
    </div>
  );
};

export default Question;
