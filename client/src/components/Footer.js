import React, { useState } from 'react';

import 'bootstrap/dist/css/bootstrap.min.css';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  NavbarText,
} from 'reactstrap';

export const Footer =()=>{
  
    return (
      <div className='footer--pin'>
        <Navbar className='footer' dark='true'>
          

        <NavbarText className="navText">
            Food Pantry Hours<br/>
            Monday: 9AM-12:15PM, 5-7PM (by appointment only)<br/>
            Tuesday & Thursday: 9AM-12:15PM, 1:30-2:45PM<br/>
            Wednesday & Friday: 9AM-12:15PM<br/>
        </NavbarText>
        <NavbarText className="navText">
            Feeding families in our community with nutritious, healthy, life-sustaining food.
        </NavbarText>
            <NavbarBrand href="https://www.jfcspgh.org/services/squirrel-hill-food-pantry/"><img src="https://jfcspittsburgh.wpenginepowered.com/wp-content/uploads/2017/11/JFCS_Logo_SquirrelHillFoodPantry_White.svg" style={{
          height: 25
        }}/></NavbarBrand>
          
        </Navbar>
      </div>
    );
}