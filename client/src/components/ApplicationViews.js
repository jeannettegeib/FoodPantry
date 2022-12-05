import { useEffect, useState } from "react"
import { Route, Routes } from "react-router-dom";
import { getCurrentUser } from "../modules/UserManager";
import Login from "./Login";

export const ApplicationViews=()=>{

    const[isLoggedIn, setIsLoggedIn]=useState(false);

    useEffect(()=>{
        const localUser=getCurrentUser();
        if(localUser){
            setIsLoggedIn(true);
        }
    },[isLoggedIn])

    return(
        !isLoggedIn ?
        <Routes>
          <Route path="/login" element={<Login setIsLoggedIn={setIsLoggedIn}/>} />  
        </Routes>
        :
        <Routes>
        <Route path="*" element={<p>Whoops, nothing here YET...</p>} />
        </Routes>
    );
};