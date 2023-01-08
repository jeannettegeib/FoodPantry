import { isFuture, parseJSON } from "date-fns";
import { useEffect, useState } from "react";
import { Button, ListGroupItem } from "reactstrap"
import { getCurrentUser } from "../modules/UserManager";
import { SwapOrderItem } from "./SwapOrderItem";

export const OrderItem=({item, order, setRefresh})=>{
    const loggedInUser=getCurrentUser();
    
    const [buttonClick, setButtonClick]=useState(false)
    useEffect(()=>{},[])
    const updateItem=(itemObject)=>{
        if (loggedInUser.id==order.shopperUserId && isFuture(parseJSON(order.pickupDate)))
        {
            return(
                <>
                <Button size="sm" onClick={()=>{setButtonClick(true)}}>Change Item</Button>
                {
                    buttonClick
                    ?
                    <SwapOrderItem OrderItem={itemObject} ButtonSetter={setButtonClick} setRefresh={setRefresh}/>
                    :
                    ""
                }
                </>
            )
        }
        else{
            return ( "" )
        }
    }
    

    return(
        <>
        
        <ListGroupItem style={{textAlign: 'left'}}>
            {item.name}
           <div style={{textAlign: 'right'}}> {updateItem(item)}</div>
            
        </ListGroupItem></>
    )
}