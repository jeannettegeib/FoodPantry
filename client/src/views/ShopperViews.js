import { Outlet, Route, Routes } from "react-router-dom";
import { ScheduleShop } from "../components/ScheduleShop";
import {ShoppingList} from "../components/ShoppingList"

export const ShopperViews=({thisUser})=>{
    
    return (
        <Routes>
            <Route path="/" element={<ScheduleShop/>}></Route>
		    <Route path="/shop/:shopperId" element={<ShoppingList />}></Route>
        </Routes>
    )
}