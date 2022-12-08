import React, { useState } from "react";
import { Form } from "react-router-dom";
import {   
    Card,
    AccordionBody,
    AccordionHeader,
    AccordionItem,
  } from 'reactstrap';


export const Category=({category, familySize, itemList})=>{
    const [itemQuantity, setItemQuantity]=useState({
        name: "",
        quantity: 0
    })
    let max=0;
    

    return(<>
        <center>
            
        <AccordionItem style={{ width: '30rem' }}>
        
        
            <AccordionHeader targetId="{category.id}">
                <h4>{category.name} &nbsp;</h4> <h6>&nbsp;pick &nbsp;  
            {(() => {
                switch(familySize) {
                    case 0: 
                        return null  
                    case 1:
                        max=category.onePerson;
                        return ( category.onePerson)
                    case 2:
                        max=category.twoPeople
                        return ( category.twoPeople)
                    case 3:
                        max=category.threeToFourPeople
                        return ( category.threeToFourPeople)
                    case 4:
                        max=category.threeToFourPeople
                        return ( category.threeToFourPeople)
                    case 5:
                        max=category.fiveToSixPeople
                        return ( category.fiveToSixPeople)
                    case 6:
                        max=category.fiveToSixPeople
                        return ( category.fiveToSixPeople)
                    case 7:
                        max=category.sevenToEightPeople
                        return ( category.sevenToEightPeople)
                    case 8:
                        max=category.sevenToEightPeople
                        return ( category.sevenToEightPeople)
                    case 9:
                        max=category.ninePlusPeople
                        return ( category.ninePlusPeople)
                    default:
                        max=category.ninePlusPeople
                        return ( category.ninePlusPeople)
        }
        })()}</h6>
        </AccordionHeader>
        <AccordionBody accordionId="{category.id}">
            {
                category.items.map((item)=>{return(
                    <fieldset id="{item.id}">
                    {item.name} &nbsp;
                    {
                        <select onChange={
                            (evt) => {
                                setItemQuantity({
                                    name: item.name,
                                    quantity: +evt.target.value})

                            }
                         }><option value="0">0</option>                            
                            {
                                [...Array(max)].map((_, index)=>{return(<option value="0">{index + 1}</option>)})
                                
                            }
                        </select>
                    }</fieldset>
                
                )})                
            }           
            
        </AccordionBody>
   
    </AccordionItem>
    
    </center>
    <br></br>
    </>
    )
    }