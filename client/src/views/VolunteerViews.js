import { Outlet, Route, Routes } from "react-router-dom"
export const VolunteerViews=()=>{
    return (
        <Routes>
		<Route path="/" element={
            <>
            <h1>You are an Volunteer!</h1>
            <Outlet />
            </>
        }>
        </Route>
        </Routes>
    )
}