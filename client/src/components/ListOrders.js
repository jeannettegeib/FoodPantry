import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import { Card } from "reactstrap"
import { ListActiveOrders } from "../modules/OrderManager"
import { format, parseJSON, parseISO, parse  } from 'date-fns'


export const ListOrders=()=>{
    const [orders, setOrders]=useState([])

    useEffect(()=>{
        ListActiveOrders()
        .then((r)=>{
            console.log("Active Orders",r)
            setOrders(r)})
    },[])

    return(
        <>
        <h1> Upcoming Orders</h1>
       
        {orders.map((order)=>{
            return(
                <>
                <center>
                <Link to={`/order/${order.id}`}>
                <Card style={{ width: '30rem', margin: '10px' }}>pickup date: {format(parseJSON(order.pickupDate), 'MM/dd/yyyy H:mm b..bb')}</Card>
                </Link>
                </center>
                </>
                )
        })}
        </>
    )
}