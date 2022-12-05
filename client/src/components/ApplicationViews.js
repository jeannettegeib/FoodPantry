import { useEffect, useState } from "react"

export const ApplicationViews=()=>{

    const[isLoggedIn, setIsLoggedIn]=useState(false);
    useEffect(()=>{
        const localUser=getCurrentUser();
        if(localUser){
            setIsLoggedIn(true);
        }
    },[isLoggedIn])

    return(
        ""
    )
}