import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "reactstrap";
import { OpenEmptyOrderForShopper } from "../modules/OrderManager";
import { getCurrentUser } from "../modules/UserManager";

export const ScheduleShop = ()=>{
    const [shopper, setShopper]=useState({});
    const [order, openOrder]=useState({
        ShopperUserId: 0,
        PickupDate: ""
    })
    const navigate =useNavigate();
    useEffect(()=>{
        setShopper(getCurrentUser())
            
    },[])
 
    let shopperId=shopper.id;
    const handleSaveButtonClick=(clickEvent)=>{
        
        OpenEmptyOrderForShopper(order)
        .then((r)=>{
            console.log(r);
            navigate(`/shop/${r.id}`)});
    }


    return(
        <>
        <center>
        <h1>Welcome, {shopper.firstName} {shopper.lastName}!</h1>
       
        <div>Would you like to schedule a pickup for your family of {shopper.familySize} at the Squirrel Hill Food Pantry?</div>
        <p></p>
        <div className="form-group">
                    <label>Select a pickup date to get started with your order. </label>
                    <div style={{width:'15rem'}}>
                    <input
                        required autoFocus
                        type="datetime-local"
                        className="form-control"
                        value={order.PickupDate}
                        onChange={
                            (evt)=>{
                                const copy={...order}
                                copy.PickupDate=evt.target.value
                                copy.ShopperUserId=shopperId
                                openOrder(copy)
                            }
                        } />
                        </div> 
                <Button 
                onClick={(clickEvent)=>handleSaveButtonClick(clickEvent)} className="orderDate">
                Save Date
            </Button>
            </div>
        </center>
        </>
    )
}