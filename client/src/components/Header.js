import React from "react";
import { Link } from "react-router-dom";

const Header =()=>{
    return (
      <nav className="navbar navbar-expand navbar-dark bg-info">
        <Link to="/" className="navbar-brand">
          Squirrel Hill Food Pantry
        </Link>
        <ul className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to="/" className="nav-link">
              Placeholder
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/" className="nav-link">
              Placeholder
            </Link>
          </li>
        </ul>
      </nav>
    );
  };
  
  export default Header;