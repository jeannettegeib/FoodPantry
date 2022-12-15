import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getOrderById } from "../modules/OrderManager";

export const Order =()=>{
    const [order, setOrder]=useState({})
    const {orderId}=useParams();
    console.log(orderId);

    useEffect(()=>{
        getOrderByIdWithItems(orderId)
        .then((orderObject)=>{setOrder(orderObject)
        })                       
    },[])
console.log(order)
    return(
    <>
        <h1>Order # {order.id}</h1>
        <center>
        <div style={{ width: '20rem' }}>
        <ol>
            {order.items.map((item)=>{
                return(
                    <li style={{textAlign: 'left'}}>
                        {item.name}
                    </li>
                )
            })}
        </ol>
        </div>
        </center>
    </>
    )
}