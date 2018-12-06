// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';

export const Patient = (props: PatientModel) => {

    return (
        <div className="patient">
            {/* <img className="photo" src={require(`Assets/${props.image}`)}/> */}
            <span className="nameAgeGender">
                {`${props.secondName} ${props.firstName} ${props.middleName}, ${props.age} ${props.gender}`}
            </span>
        </div>
    )
};
