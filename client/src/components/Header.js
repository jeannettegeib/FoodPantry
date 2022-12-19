import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { getCurrentUser } from "../modules/UserManager";

const Header =()=>{
  const navigate =useNavigate();
  let user=""
  user=getCurrentUser();
    return (
      <nav className="navbar navbar-expand navbar-color">
        <Link to="/" className="navbar-brand" ><font color={"white"}>
          <img src="https://jfcspittsburgh.wpenginepowered.com/wp-content/themes/jfcs/img/favicon.ico" width={25}></img>Squirrel Hill Food Pantry
        </font></Link>
        <ul className="navbar-nav mr-auto">
          {
            user?.userType==3
              ?
              <>
              <li className="nav-item">
                <Link to="/MyOrders" className="nav-link"><font color={"white"}>
                  My Orders</font>
                </Link>
              </li>

              <li className="nav-item">
              <Link to="/" className="nav-link"><font color={"white"}>
                New Order</font>
              </Link>
              </li>
              </>
              
              :
              ""
          }
          {
            user?.userType==2
            ?
              <li className="nav-item">
                <Link to="/" className="nav-link">
                  Upcoming Orders
                </Link>
              </li>
            :
              ""
          }
         
          
          {
                localStorage.getItem("pantryUser")
                    ? <li className="nav-item " >
                        <Link className="nav-link" to="" onClick={() => {
                            localStorage.removeItem("pantryUser")
                            .then(()=>{navigate("/login")})
                           
                        }}><font color={"white"} size={'3em'}>Logout</font></Link>
                    </li>
                    : ""
            }
        </ul>
      </nav>
    );
  };
  
  export default Header;