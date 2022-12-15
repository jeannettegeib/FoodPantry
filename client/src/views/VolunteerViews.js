import { Outlet, Route, Routes } from "react-router-dom"
import { ListOrders } from "../components/ListOrders"
import { Order } from "../components/Order"

export const VolunteerViews=({thisUser})=>{
    return (
        <Routes>
		
        <Route path="/" element={<ListOrders/>}></Route>
        <Route path="/order/:orderId" element={<Order/>}></Route>
        </Routes>
    )
}