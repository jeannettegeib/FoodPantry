import { Outlet, Route, Routes } from "react-router-dom"
import { ListOrders } from "../components/ListOrders"

export const VolunteerViews=()=>{
    return (
        <Routes>
		
        <Route path="/" element={<ListOrders/>}></Route>
        <Route path="/order/:orderId" element={ListOrders}></Route>
        </Routes>
    )
}