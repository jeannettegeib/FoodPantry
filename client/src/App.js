import { BrowserRouter as Router } from "react-router-dom";

import './App.css';
import { ApplicationViews } from "./views/ApplicationViews";
import Header from "./components/Header";
import { Footer } from "./components/Footer";

function App() {
  return (
    <div className="App">
      <Router>
          <Header />
          <ApplicationViews />
          <Footer />
      </Router>
    </div>
  );
}

export default App;
