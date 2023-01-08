import React, { useState } from "react";
import { login } from "../modules/UserManager";
import {Link,  useNavigate} from "react-router-dom";
import { Button } from "reactstrap";

const Login =({setIsLoggedIn})=>{
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    

    const navigate =useNavigate();

    const submitLoginForm = (e) => {
        e.preventDefault(); 
        const newLogin = {
         username: username,
         password: password
        }
        login(newLogin)
        .then(()=>{setIsLoggedIn(true)})
        .then(()=>{navigate("/")});
  };

    return (
        <>
          <div className="login content-container">
          <div className="login-text">
            <h2>Log In</h2>
            <form>
                <div>
              <input
                type="text"
                onChange={(e) => setUsername(e.target.value)}
                name="username"
                placeholder="username"
              />
              </div>
              <div>
              <input
                type="password"
                onChange={(e) => setPassword(e.target.value)}
                name="password"
                placeholder="password"
              /></div>            
              <Button type="submit" onClick={submitLoginForm}>
                Log In
              </Button>
            </form>
            </div>
          </div>
        </>
      );
}
export default Login;