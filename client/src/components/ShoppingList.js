import React, { useEffect, useState } from "react";
import { Form, useParams } from "react-router-dom";
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



    return(
    <>
        <h1>Hi {shopper.firstName} {shopper.lastName}</h1>
        
        {categoryList.map((category)=>
            {
                return(
                    <>
                    <UncontrolledAccordion stayOpen>
                    <Category
                    key = {`category--${category.id}`}
                    category = {category}
                    familySize = {shopper.familySize}
                    itemList = {category.items} />
                    </UncontrolledAccordion>
                    </>         
            )
            }
            )}
        
    </>
    )
};