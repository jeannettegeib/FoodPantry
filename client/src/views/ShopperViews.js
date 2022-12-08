import { Outlet, Route, Routes } from "react-router-dom";
import {ShoppingList} from "../components/ShoppingList"

export const ShopperViews=({thisUser})=>{
    
    return (
        <Routes>
		<Route path="/shop/:shopperId" element={<ShoppingList />}>
        </Route>
        </Routes>
    )
}