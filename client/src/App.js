import { BrowserRouter as Router } from "react-router-dom";

import './App.css';
import { ApplicationViews } from "./views/ApplicationViews";
import Header from "./components/Header";

function App() {
  return (
    <div className="App">
      <Router>
          <Header />
          <ApplicationViews />
      </Router>
    </div>
  );
}

export default App;
