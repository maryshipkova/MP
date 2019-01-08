// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';
import {sexType} from 'types/SexType';

export const Patient = (props: PatientModel) => {

    function getFullDate(date) {
        let newDate = new Date(date);
        return `${newDate.getDate()}.${newDate.getMonth() + 1}.${newDate.getFullYear()}`
    }

    return (
        <li className="patient">
            <span className="nameAgeGender">
                {`${props.lastName} ${props.firstName} ${props.genderType.name}, ${getFullDate(props.birthDate)}`}
            </span>
        </li>
    )
};
