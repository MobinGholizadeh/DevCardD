import { useState } from "react";
import { Icon } from "react-icons-kit";
import { eyeOff } from "react-icons-kit/feather/eyeOff";
import { eye } from "react-icons-kit/feather/eye";
import SingleQuestion from "./question";
import data from "./data";
import questions from "./data";

function App() {
  const [question, setQuestions] = useState(data);

  return (
    <div className="container">
      <h3>Have a quesion?</h3>
      <div className="info">
        {questions.map((question, index) => {
          return <SingleQuestion key={index} {...question} />;
        })}
      </div>
    </div>
  );
}

export default App;
