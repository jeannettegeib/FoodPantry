import { Outlet, Route, Routes } from "react-router-dom"

export const AdminViews=()=>{
    return (
        <Routes>
		<Route path="/" element={
            <>
            <h1>You are an Admin!</h1>
            <Outlet />
            </>
        }>
        </Route>
        </Routes>
    )
}