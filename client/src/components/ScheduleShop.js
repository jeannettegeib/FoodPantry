import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Card, CardBody, CardHeader, CardImg, CardImgOverlay, CardTitle } from "reactstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
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
    console.log(new Date())
    let shopperId=shopper.id;
    const handleSaveButtonClick=(clickEvent)=>{
        
        OpenEmptyOrderForShopper(order)
        .then((r)=>{
            console.log(r);
            navigate(`/shop/${r.id}`)});
    }


    return(<center>
        <div className="content-container" style={{
            display: 'block', width: "60%", maxWidth: 650, padding: 30
        }}>
        
            <Card>
                <CardImg  src="https://jfcspittsburgh.wpenginepowered.com/wp-content/uploads/2017/10/Food-Pantry-1.jpg"></CardImg>
                <CardBody>
                <CardImgOverlay>
                <CardTitle className="scheduleShopTitle">
                Welcome, {shopper.firstName}!
                </CardTitle>
                </CardImgOverlay>
        <div>Would you like to schedule a food pickup for your family of {shopper.familySize} at the Squirrel Hill Food Pantry?</div>
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
            </CardBody>
            </Card>
        
        </div></center>
    )
}