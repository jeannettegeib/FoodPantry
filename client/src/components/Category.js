import React, { useEffect, useState } from "react";
import { Form } from "react-router-dom";
import {
    Card,
    AccordionBody,
    AccordionHeader,
    AccordionItem,
} from 'reactstrap';
import { submitCategoryItems } from "../modules/Category-ItemManager";


export const Category = ({ category, familySize, submitState, orderId }) => {
    const [itemQuantity, setItemQuantity] = useState({})
   
    let max = 0;
 
    useEffect(() => {
        const burger = {}
        for (let i = 0; i < findMax(); i++) {
            burger[`item${i}`] = ""
   
        }
        setItemQuantity(burger)
   
    }, [])
    useEffect(()=>{
        for(let i=0; i<findMax(); i++ ){
        let orderItem={
            orderId:orderId,
            itemId: itemQuantity[i]
        }
        if(submitState==true){
            submitCategoryItems(orderItem)

        }}
    },[submitState])

    const findMax = () => {

        switch (familySize) {
            case 0:
                return null
            case 1:
                max = category.onePerson;
                return (category.onePerson)
            case 2:
                max = category.twoPeople
                return (category.twoPeople)
            case 3:
                max = category.threeToFourPeople
                return (category.threeToFourPeople)
            case 4:
                max = category.threeToFourPeople
                return (category.threeToFourPeople)
            case 5:
                max = category.fiveToSixPeople
                return (category.fiveToSixPeople)
            case 6:
                max = category.fiveToSixPeople
                return (category.fiveToSixPeople)
            case 7:
                max = category.sevenToEightPeople
                return (category.sevenToEightPeople)
            case 8:
                max = category.sevenToEightPeople
                return (category.sevenToEightPeople)
            case 9:
                max = category.ninePlusPeople
                return (category.ninePlusPeople)
            default:
                max = category.ninePlusPeople
                return (category.ninePlusPeople)
        }

    }

    return (<>
        <center>

            <AccordionItem style={{ width: '30rem' }}>

                <AccordionHeader targetId="{category.id}">
                    <h4>{category.name} &nbsp;</h4> <h6>&nbsp;pick &nbsp;{findMax()}
                    </h6>
                </AccordionHeader>
                <AccordionBody accordionId="{category.id}">
                    {
                        [...Array(max)].map((x, index) => {
                            return (<fieldset >
                                <select id="{item.id}" name={`item${index}`}
                                    onChange={(evt) => {
                                        const copy = { ...itemQuantity }
                                        copy[evt.target.name] = +evt.target.value
                                        setItemQuantity(copy)

                                    }}>
                                    <option value="0" >Select an Item</option>
                                    {category.items.map(y => { return <option value={y.id}>{y.name}</option>})}
                                </select><p>&nbsp;</p>
                            </fieldset>)

                        })
                    }
                </AccordionBody>
            </AccordionItem>
        </center>
        <br></br>
    </>
    )
}