import { Outlet, Route, Routes } from "react-router-dom";
import { Order } from "../components/Order";
import { ScheduleShop } from "../components/ScheduleShop";
import { ShopperOrderHistory } from "../components/ShopperOrderHistory";
import {ShoppingList} from "../components/ShoppingList"

export const ShopperViews=({thisUser})=>{
    
    return (
        <Routes>
            <Route path="/" element={<ScheduleShop/>}></Route>
		    <Route path="/shop/:orderId" element={<ShoppingList />}></Route>
            <Route path="/MyOrders" element={<ShopperOrderHistory/>}></Route>
            <Route path="/order/:orderId" element={<Order/>}></Route>
        </Routes>
    )
}