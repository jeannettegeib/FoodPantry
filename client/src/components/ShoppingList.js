import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { UncontrolledAccordion } from "reactstrap";
import { getAllCategories } from "../modules/Category-ItemManager";
import { getCurrentUser, getUserById } from "../modules/UserManager";
import { Category } from "./Category";

export const ShoppingList=()=>{
    const [categoryList, setCategoryList]=useState([]);
    const [shopper, setShopper]=useState({});
    const {shopperId} = useParams();

    useEffect(()=>{
        getUserById(shopperId)
        .then((shopperObject)=>{setShopper(shopperObject)})
    },[])

    useEffect(()=>{
        getAllCategories()
        .then((CategoryArray)=>{setCategoryList(CategoryArray)})
    },[])

    const handleSubmitOrder=()=>{
        
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