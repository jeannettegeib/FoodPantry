import { Outlet, Route, Routes } from "react-router-dom"
export const ShopperViews=()=>{
    return (
        <Routes>
		<Route path="/" element={
            <>
            <h1>You are an Shopper!</h1>
            <Outlet />
            </>
        }>
        </Route>
        </Routes>
    )
}