import React from "react";
import { Link, useNavigate } from "react-router-dom";

const Header =()=>{
  const navigate =useNavigate();
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
          {
                localStorage.getItem("pantryUser")
                    ? <li className="navbar__item navbar__logout">
                        <Link className="navbar__link" to="" onClick={() => {
                            localStorage.removeItem("pantryUser")
                            navigate("/login", {replace: true})
                        }}>Logout</Link>
                    </li>
                    : ""
            }
        </ul>
      </nav>
    );
  };
  
  export default Header;