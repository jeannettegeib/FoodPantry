import { useEffect, useState } from "react"
import { Navigate, Route, Routes } from "react-router-dom";
import { getCurrentUser } from "../modules/UserManager";
import Login from "../components/Login";
import { AdminViews } from "./AdminViews";
import { VolunteerViews } from "./VolunteerViews";
import { ShopperViews } from "./ShopperViews";

export const ApplicationViews=()=>{
    const [isLoggedIn, setIsLoggedIn]=useState(false)
    const pantryUser = getCurrentUser();
    const pantryUserObject=JSON.parse(pantryUser);

    if(!pantryUserObject){
        return(
            <Routes>
            <Route path="*" element={<Navigate to ="/login" />} />
            <Route path="/login" element={<Login 
            setIsLoggedIn={setIsLoggedIn}
            />} />
            </Routes>
        ) 
        }
    if(pantryUserObject.userType === 1){
        return <AdminViews />
    }
    if (pantryUserObject.userType === 2){
        return <VolunteerViews />
    }
    if (pantryUserObject.userType === 3){
        return <ShopperViews />
    }
    
};