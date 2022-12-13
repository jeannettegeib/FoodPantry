import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { UncontrolledAccordion } from "reactstrap";
import { getAllCategories } from "../modules/Category-ItemManager";
import { getOrderById, SubmitOrder } from "../modules/OrderManager";
import { getCurrentUser, getUserById } from "../modules/UserManager";
import { Category } from "./Category";

export const ShoppingList=()=>{
    const [categoryList, setCategoryList]=useState([]);
    const [order, setOrder]=useState({});
    const [submit, setSubmit]=useState(false)
    const shopper = getCurrentUser();
    const orderId=useParams();


  
    useEffect(()=>{
        getAllCategories()
        .then((CategoryArray)=>{setCategoryList(CategoryArray)})
    },[])

    useEffect(()=>{
        getOrderById(orderId)
        .then((order)=>{setOrder(order)})
    },[])

    const handleSubmitOrder=()=>{
        SubmitOrder(order);
        setSubmit(true)

    }


    return(
    <>
        <h1>Hi {shopper.firstName} {shopper.lastName}</h1>
        <form>
        {categoryList.map((category)=>
            {
                return(
                    <>
                    <UncontrolledAccordion stayOpen>
                    <Category
                    key = {`category--${category.id}`}
                    category = {category}
                    familySize = {shopper.familySize}
                    submitState={submit}
                    orderId={order.id}
                     />
                    </UncontrolledAccordion>
                    </>         
            )
            }
            )}
            <button onClick={handleSubmitOrder}>Submit Order</button>
        </form>
        
    </>
    )
};