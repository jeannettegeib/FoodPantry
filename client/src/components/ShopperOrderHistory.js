import { format, parseJSON } from "date-fns";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Card, CardText, CardTitle } from "reactstrap";
import { getOrdersByShopper } from "../modules/OrderManager";
import { getCurrentUser  } from "../modules/UserManager";

export const ShopperOrderHistory=()=>{
    const [orderHistory, setOrderHistory]=useState([]);
    
    const shopper=getCurrentUser();
    const navigate =useNavigate();

    useEffect(()=>{
        getOrdersByShopper(shopper.id)
        .then((array)=>{setOrderHistory(array)})
    },[])

    return (
        <>
            <h1>{shopper.lastName} Family Order History</h1>
            <center>
            <div>
                {orderHistory.map((orderObject)=>{
                    return(
                        <Card style={{ width: '30rem', margin: '15px' }}>
                            <center><table>
                                <thead><th>Order #</th><th><center>Order Placed</center></th><th>Order Pickup</th></thead>
                                <tbody>
                                <tr>
                                    <td>{orderObject.id}</td>
                                    <td style={{width: '10rem'}}><center>{format(parseJSON(orderObject.orderSubmitted), 'MM/dd/yyyy')}</center></td>
                                    {
                                        orderObject.complete?
                                            <td><center>&#x2713;</center></td>
                                        :
                                            <td>{format(parseJSON(orderObject.pickupDate), 'MM/dd/yyyy')}</td>                                        
                                    }
                                    <td><Button size='sm' onClick={()=>{navigate(`/order/${orderObject.id}`)}}>Order Details</Button></td>
                                    
                                </tr>
                                </tbody>
                            </table></center>
                        </Card>
                    )
                })}
                
            </div>
            </center>
        </>
    )
}