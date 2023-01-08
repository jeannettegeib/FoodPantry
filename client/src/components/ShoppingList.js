import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, UncontrolledAccordion } from "reactstrap";
import { getAllCategories, submitCategoryItems } from "../modules/Category-ItemManager";
import { getOrderById, SubmitOrder } from "../modules/OrderManager";
import { getCurrentUser, getUserById } from "../modules/UserManager";
import { Category } from "./Category";

export const ShoppingList=()=>{
    //state#1: ARRAY:all the categories with the included items
    const [categoryList, setCategoryList]=useState([]);
    //state#2: OBJECT: the order that the shopper just scheduled on the previous page
    const [order, setOrder]=useState({});    
    //state#3: ARRAY: nested array of selected orderItem objects from all the categories
    const [ready4ship, setReady4Ship] = useState([])

    const shopper = getCurrentUser();
    const {orderId}=useParams();
    const navigate=useNavigate();
  
    useEffect(()=>{
        getAllCategories()
        .then((CategoryArray)=>{setCategoryList(CategoryArray)})
    },[])

    useEffect(()=>{
        getOrderById(orderId)
        .then((order)=>{setOrder(order)})
        
    },[])


    // useEffect(()=>{
        
    // },[ready4ship])


    const handleSubmitOrder=(event)=>{
        event.preventDefault()
        return Promise.all(
            [
                ///update this order id in the database to set orderSubmitted to current datetime (hopefully!)
                SubmitOrder(order), 
                //map through the array of orderItems to submit each one to the orderItems bridge table.
                ready4ship.flatMap(orderItemObject=>orderItemObject).map(orderItem=>submitCategoryItems(orderItem)) 
            ]
        )
        .then(window.alert("Order Submitted!"))        
        .then(navigate("/MyOrders"))
    }


    return(
    <>
        <h1>Hi {shopper.firstName} {shopper.lastName}</h1>
        <div>Please select the items you would like to order from each category.</div>
        <p>&nbsp;</p>
      
        {categoryList.map((category)=>
            {
                return(
                    <div className="categoryList">
                        
                    <UncontrolledAccordion>
                    <Category
                    key = {`category--${category.id}`}
                    category = {category}
                    familySize = {shopper.familySize}                   
                    orderId={order.id}
                    readyPackage={setReady4Ship}
                    box={ready4ship}
                     />
                    </UncontrolledAccordion>
                    </div>         
            )
            }
            )}
            <Button onClick={(event)=>handleSubmitOrder(event)}>Submit Order</Button>
        {/* </form> */}
        
    </>
    )
};