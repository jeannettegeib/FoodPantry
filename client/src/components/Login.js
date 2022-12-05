import React, { useState } from "react";
import { login } from "../modules/UserManager";
import {Link,  useNavigate} from "react-router-dom";

const Login =({setIsLoggedIn})=>{
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const navigate =useNavigate();

    const submitLoginForm = (e) => {
        const newLogin = {
         username: username,
         password: password
        }
        e.preventDefault();
        login(newLogin)
        .then(()=>{setIsLoggedIn(true)
        navigate("/")
    });
  };

    return (
        <>
          <>
            <h2>Log In</h2>
            <form>
              <input
                type="text"
                onChange={(e) => setUsername(e.target.value)}
                name="username"
                placeholder="username"
              />
              <input
                type="password"
                onChange={(e) => setPassword(e.target.value)}
                name="password"
              />
              <button type="submit" onClick={submitLoginForm}>
                Log In
              </button>
            </form>
            
          </>
        </>
      );
}
export default Login;