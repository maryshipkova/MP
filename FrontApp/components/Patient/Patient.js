// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';
import {sexType} from 'types/SexType';

export const Patient = (props: PatientModel) => {

    return (
        <div className="patient">
            <span className="nameAgeGender">
                {`${props.lastName} ${props.firstName} ${sexType[props.sexType]}, ${props.birthDate}`}
            </span>
        </div>
    )
};
