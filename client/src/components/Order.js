import { getDate, isFuture, parseJSON } from "date-fns";
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { Button, ListGroup, ListGroupItem } from "reactstrap";
import { getOrderById, getOrderByIdWithItems } from "../modules/OrderManager";
import { getCurrentUser } from "../modules/UserManager";
import { OrderItem } from "./OrderItem";
import { SwapOrderItem } from "./SwapOrderItem";

export const Order =()=>{
    const [order, setOrder]=useState({})
    const [refresh, setRefresh]=useState(false)
    const {orderId}=useParams();
    const user=getCurrentUser();

    
    
    useEffect(()=>{
        getOrderByIdWithItems(orderId)
        .then((orderObject)=>{setOrder(orderObject)
        })                       
    },[orderId, refresh])
console.log("Order Items", order.items)
    return(
    <>
        <h1>Order # {order.id}</h1>
        <center>
        <div style={{ width: '20rem' }}>
        <ListGroup>
            {order.items?.map((item)=>{
                
                return(
                    <>
                    <OrderItem key={item.id} item={item} order={order} setRefresh={setRefresh}/>
                   
                    </>
                )
            })}
        </ListGroup>
        {
            user.userType==3
            ?
            ""
            :
            <Button>Order Fullfilled</Button>
        }

        </div>
        </center>
    </>
    )
}