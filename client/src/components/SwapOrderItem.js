import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { Button } from "reactstrap"
import { getCategoryByIdWithItems } from "../modules/Category-ItemManager"
import { updateOrderItem } from "../modules/OrderManager"

export const SwapOrderItem=({OrderItem, ButtonSetter})=>{
    const [relatedItems, setRelatedItems]=useState([])
    const [newItemId, setNewItemId]=useState({})
    const navigate=useNavigate();
  

    useEffect(()=>{
        getCategoryByIdWithItems(OrderItem.categoryId)
        .then((categoryObject)=>{
            setRelatedItems(categoryObject.items)            
        })
        .then(console.log(relatedItems))
    },[])

    const updateItemChoice=(event)=>{
        console.log(OrderItem)
        event.preventDefault();
        updateOrderItem(OrderItem, newItemId)
        .then(ButtonSetter(false))
        .then(window.alert("Selection Updated!"))        
        .then(navigate(`/order/${OrderItem.orderId}`))
    };

    return(
        <>
        <fieldset>
        <select id={OrderItem.id} onChange={(evt) => {setNewItemId(+evt.target.value)}}>
            <option value="0" >Select a different item</option> 
            {relatedItems.map((newItem)=>{return <option value={newItem.id}>{newItem.name}</option>})}
        </select>
        <Button size ='sm' onClick={(e)=>{updateItemChoice(e)}}>Save Change</Button>
        </fieldset>
        </>
    )

}